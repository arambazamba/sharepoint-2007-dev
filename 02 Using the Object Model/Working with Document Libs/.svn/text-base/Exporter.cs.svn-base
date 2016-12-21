using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Microsoft.SharePoint;

namespace Integrations
{
    public partial class Exporter : Form
    {
        public Exporter()
        {
            InitializeComponent();
        }

        private string URL;
        private SPSite SiteCollection;
        private SPWeb Web;
        private SPList List;


        private void ConnectToSite(object sender, EventArgs e)
        {
            URL = txtSiteCollection.Text;
            SiteCollection = new SPSite(URL);

            foreach (SPWeb web in SiteCollection.AllWebs)
            {
                lbWebs.Items.Add(web);
            }
        }

        private void SiteSelected(object sender, EventArgs e)
        {
            Web = (SPWeb) lbWebs.SelectedItem;

            lbDocLib.Items.Clear();

            // we only want lists that are document library because we want to export files 
            SPListCollection doclibs = Web.GetListsOfType(SPBaseType.DocumentLibrary);
            foreach (SPList list in doclibs)
            {
                lbDocLib.Items.Add(list);
            }
        }

        private void DocumentLibrarySelected(object sender, EventArgs e)
        {
            List = (SPList) lbDocLib.SelectedItem;

            // as the ToString-methode of the SPListItem does not return the name we have made up a wrapper class
            // to avoid iterating the collection later on and at the same time are able to bind it to the listbox
            // and get a meaningful display name

            lbItems.Items.Clear();

            foreach (SPListItem item in List.Items)
            {
                var cw = new ControlWrapper(item.Name, item.UniqueId);
                lbItems.Items.Add(cw);
            }
        }

        private void ExportSingleFileClicked(object sender, EventArgs e)
        {
            var cw = (ControlWrapper) lbItems.SelectedItem;
            dSelectFolder.ShowDialog();
            string path = dSelectFolder.SelectedPath;
            ExportFile(cw, path);
            MessageBox.Show("Export done", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExportAllClicked(object sender, EventArgs e)
        {
            dSelectFolder.ShowDialog();
            string path = dSelectFolder.SelectedPath;
            foreach (ControlWrapper cw in lbItems.Items)
            {
                ExportFile(cw, path);
            }

            MessageBox.Show("Export done", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ExportFile(ControlWrapper wrapper, string folder)
        {
            SPListItem item = List.GetItemByUniqueId(wrapper.UniqueID);

            if (item.FileSystemObjectType == SPFileSystemObjectType.File)
            {
                string destFile = folder + "\\" + item.File.Name;
                Stream input = item.File.OpenBinaryStream();
                ExportStream(destFile, input);
            }
        }

        private void ExportStream(string destFile, Stream input)
        {
            Stream target = File.Create(destFile);

            var reader = new BinaryReader(input);
            var writer = new BinaryWriter(target);

            writer.Write(reader.ReadBytes((int) input.Length));
            writer.Flush();
            writer.Close();
            reader.Close();
        }

        private void btnShowFiles_Click(object sender, EventArgs e)
        {
            SPFolderCollection folders = Web.Folders;
            foreach (SPFolder fld in folders)
            {
                Debug.WriteLine(string.Format("Folder: {0}, URL: {1} ", fld.Name, fld.ServerRelativeUrl));

                foreach (SPFile f in fld.Files)
                {
                    Debug.WriteLine(string.Format("File: {0}, Version: {1}.{2}", f.Name, f.MajorVersion, f.MinorVersion));

                    if (f.Versions.Count > 1)
                    {
                        SPFileVersionCollection versions = f.Versions;
                        foreach (SPFileVersion v in versions)
                        {
                            Debug.WriteLine("Version: " + v.VersionLabel);
                            Stream stm = new MemoryStream(v.OpenBinary());
                            ExportStream(@"d:\" + v.VersionLabel + "-" + f.Name, stm);
                        }
                    }
                }
            }
        }
    }
}