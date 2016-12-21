using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Integrations.Objects;
using Microsoft.SharePoint;

namespace Integrations.Winforms
{
    public partial class wfContentTypes : Form
    {
        public wfContentTypes()
        {
            InitializeComponent();
        }

        private SPWeb selectedWeb;
        private SPList selectedList;

        private SPContentType SelectedCT;
        private SPField SelectedSC;

        // as the ToString-methode of the SPListItem does not return the name we have made up a wrapper class
        // to avoid iterating the collection later on and at the same time are able to bind it to the listbox
        // and get a meaningful display name

        private ControlWrapper<SPContentType> ctDD;
        private ControlWrapper<SPField> scDD;

        private void btnConnect_Click(object sender, EventArgs e)
        {
            SPSite col = new SPSite(txtSPSite.Text);
            SPWeb tls = col.RootWeb;

            tvStructure.Nodes.Clear();
            TreeNode rootNode = new TreeNode(tls.Title, 0, 0);
            rootNode.Tag = tls;
            tvStructure.Nodes.Add(rootNode);

            AddChildWebs(tls, rootNode);
            AddLibraries(tls, rootNode);
            tvStructure.ExpandAll();
        }

        private void AddChildWebs(SPWeb web, TreeNode parent)
        {
            foreach (SPWeb w in web.Webs)
            {
                TreeNode child = new TreeNode(w.Title, 0, 0);
                child.Tag = w;
                AddChildWebs(w, child);
                AddLibraries(w, child);
                parent.Nodes.Add(child);
            }
        }

        private void AddLibraries(SPWeb web, TreeNode parent)
        {
            foreach (SPList lib in web.GetListsOfType(SPBaseType.DocumentLibrary))
            {
                TreeNode listnode = new TreeNode(lib.Title, 1, 1);
                listnode.Tag = lib;
                parent.Nodes.Add(listnode);
            }
        }

        private void TreeNodeSelected(object sender, TreeViewEventArgs e)
        {
            if (tvStructure.SelectedNode.Tag is SPWeb)
            {
                selectedWeb = tvStructure.SelectedNode.Tag as SPWeb;
                PopulateSCDD(selectedWeb);
                PopulateContentTypeDD(selectedWeb);
            }
            else if (tvStructure.SelectedNode.Tag is SPList)
            {
                selectedList = tvStructure.SelectedNode.Tag as SPList;
                RefreshBoundContentTypesTable();
            }
        }

        #region Content Type Related

        private void PopulateSCDD(SPWeb web)
        {
            cbSiteCols.Items.Clear();

            SPFieldCollection scs = web.Fields;

            foreach (SPField sc in scs)
            {
                scDD = new ControlWrapper<SPField>(sc.Title, sc);
                cbSiteCols.Items.Add(scDD);
            }

            if (scs.Count > 0)
            {
                cbSiteCols.SelectedIndex = 0;
            }
        }

        private void SelectSiteCol(object sender, EventArgs e)
        {
            SelectedSC = ((ControlWrapper<SPField>) cbSiteCols.SelectedItem).Item;
        }

        private void PopulateContentTypeDD(SPWeb web)
        {
            cbContentTypes.Items.Clear();

            SPContentTypeCollection types = web.ContentTypes;

            foreach (SPContentType ct in types)
            {
                ctDD = new ControlWrapper<SPContentType>(ct.Name, ct);
                cbContentTypes.Items.Add(ctDD);
            }
            if (types.Count > 0)
            {
                cbContentTypes.SelectedIndex = 0;
            }
        }

        private void ContentTypeSelected(object sender, EventArgs e)
        {
            SelectedCT = ((ControlWrapper<SPContentType>) cbContentTypes.SelectedItem).Item;
            lblCT.Text = String.Format("ContentType {0} defined in Web {1}", SelectedCT.Name, SelectedCT.ParentWeb);
            DataTable dt = GetMetadataForCT(SelectedCT);
            gvCT.DataSource = dt;
        }

        public DataTable GetMetadataForCT(SPContentType ct)
        {
            // Create ID-Value DataTable for Metadata
            DataTable dtMetadata = new DataTable(ct.Name);
            dtMetadata.Columns.Add("ID");
            dtMetadata.Columns.Add("Value");
            dtMetadata.Columns[0].ReadOnly = true;

            foreach (SPField field in ct.Fields)
            {
                if (!(field.ReadOnlyField || field.Hidden))
                {
                    if (field.InternalName == "ContentType")
                    {
                        dtMetadata.Rows.Add(field.InternalName, ct.ToString());
                    }
                    else
                    {
                        dtMetadata.Rows.Add(field.InternalName);
                    }
                }
            }

            return dtMetadata;
        }

        private void RefreshBoundContentTypesTable()
        {
            lvBoundCT.Items.Clear();
            foreach (SPContentType ct in selectedList.ContentTypes)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.SubItems.Add(ct.Name);
                lvi.Tag = ct;
                lvBoundCT.Items.Add(lvi);
            }
        }

        private void CreateSiteCol(object sender, EventArgs e)
        {
          // create a choice called kbtopic which can be used in a knowledge base – name is the return value
            string fld = selectedWeb.Fields.Add("KBTopic", SPFieldType.Choice, true);

            // populate the choice field with values 
            SPFieldChoice TopicChoices = (SPFieldChoice) selectedWeb.Fields[fld];
            TopicChoices.Choices.Add("Sharepoint 2007");
            TopicChoices.Choices.Add("SQL Server 2005/2008");
            TopicChoices.Choices.Add("Reporting Services");
            TopicChoices.Choices.Add("Integration Services");
            TopicChoices.Choices.Add(".NET General");

            //set the default value
            TopicChoices.DefaultValue = "Sharepoint 2007";
            TopicChoices.Update();

            PopulateSCDD(selectedWeb);
        }

        private void CreateContentType(object sender, EventArgs e)
        {
            // Create new content type 
            SPContentType baseCT = selectedWeb.AvailableContentTypes["Document"];
            SPContentType newCT = new SPContentType(baseCT, selectedWeb.ContentTypes, "KB File");
            selectedWeb.ContentTypes.Add(newCT);

            // Add FieldLink to content type 
            SPField fld = selectedWeb.AvailableFields["KBTopic"];
            SPFieldLink fldLink = new SPFieldLink(fld);
            newCT.FieldLinks.Add(fldLink);
            newCT.Update(true);

            PopulateContentTypeDD(selectedWeb);
        }

        private void BindContentType(object sender, EventArgs e)
        {
            if (selectedList != null)
            {
                selectedList.ContentTypes.Add(SelectedCT);
                RefreshBoundContentTypesTable();
            }
        }

        private void UnbindContentType(object sender, EventArgs e)
        {
            if (selectedList != null)
            {
                SPListItemCollection items = selectedList.Items;
                SPContentType searched = null;

                if (lvBoundCT.SelectedItems.Count > 0)
                {
                    searched = (SPContentType) lvBoundCT.SelectedItems[0].Tag;
                }
                else
                {
                    MessageBox.Show("Please select a content type to unbind");
                    return;
                }


                foreach (SPListItem item in items)
                {
                    if (item.ContentType == searched)
                    {
                        MessageBox.Show("Content Type is in use. Please delete entries first");
                        return;
                    }
                }

                selectedList.ContentTypes.Delete(searched.Id);
                RefreshBoundContentTypesTable();
            }
        }

        #endregion

        private void SelectFolder(object sender, EventArgs e)
        {
            dialFile.ShowDialog();
            lblSelectedFile.Text = dialFile.FileName;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable) gvCT.DataSource;
            if (dialFile.FileName != string.Empty && selectedList != null)
            {
                byte[] file = File.ReadAllBytes(dialFile.FileName);
                string fileName = dialFile.FileName.Substring(dialFile.FileName.LastIndexOf("\\")+1 );

                UploadItem(selectedList, dt, SelectedCT, fileName, file);
            }
            else
            {
                MessageBox.Show("Please select a library and a file to upload and try again.");
            }
        }

        public void UploadItem(SPList Lib, DataTable dt, SPContentType ct, string FileName, byte[] file)
        {
            Lib.ParentWeb.AllowUnsafeUpdates = true;

            Hashtable properties = new Hashtable();

            if (dt != null && dt.TableName == ct.Name)
            {
                properties.Add("ContentType", ct.Name);
                foreach (DataRow row in dt.Rows)
                {
                    if (string.IsNullOrEmpty(row["Value"].ToString()) == false)
                    {
                        string id = row["ID"].ToString();
                        string val = row["Value"].ToString();
                        properties.Add(id, val);
                    }
                }
            }

            SPFolder folder = Lib.RootFolder;

            try
            {
                folder.Files.Add(FileName, file, properties, true);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error uploading File {0}", FileName), ex.InnerException);
            }

            MessageBox.Show(string.Format("{0} uploaded successfully to {1}", FileName, Lib.Title));
        }

        private void CopySchemaToClipboard(object sender, EventArgs e)
        {
            string name = ((Button) sender).Name;

            if (name == "btnCTSchema")
            {
                Clipboard.SetText(SelectedCT.SchemaXml);
            }
            else if (name == "btnSCSchema")
            {
                Clipboard.SetText(SelectedSC.SchemaXml);
            }
        }
    }
}