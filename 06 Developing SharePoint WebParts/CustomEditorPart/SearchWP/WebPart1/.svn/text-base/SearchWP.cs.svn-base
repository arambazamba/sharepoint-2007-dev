using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;

namespace Integrations
{
    [Guid("c43904f3-08b0-4f8f-bd55-3f6b4462005a")]
    public class SearchWP : WebPart
    {
        public SearchWP()
        {
            ListName = "Customers";
        }

        public string ListName { get; set; }
        
        protected Table tbl;
        protected DropDownList ddTitleSelection;
        protected GridView gvResult;
        protected Label lblMessage;
 
        protected override void CreateChildControls()
        {           
            base.CreateChildControls();
            try // sorry - no other way to check if the list exists
            {
                tbl = new Table();

                ddTitleSelection = new DropDownList();
                ddTitleSelection.AutoPostBack = true;
                BindListDD();
                AddToTable(ddTitleSelection);
                Controls.Add(tbl);
            }
            catch (Exception)
            {
                lblMessage = new Label();
                lblMessage.Text = "Please configure this webpart to display a list";
                Controls.Add(lblMessage);
            }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            writer.Write("<div id=\"mainbody\" style=\"width:500px;hight:300;overflow:auto;\">");
            foreach (Control c in Controls)
            {
                c.RenderControl(writer);
            }

            writer.Write("</div>");
        }

        public void BindListDD()
        {
            if (ddTitleSelection != null)
            {
                ddTitleSelection.DataSource = GetFilterValues();
                ddTitleSelection.SelectedIndexChanged += CustomerSelected;
                ddTitleSelection.DataBind();
            }
        }

        private void CustomerSelected(object sender, EventArgs e)
        {
            string titleVal = ddTitleSelection.SelectedValue;
            string camlQuery = @"<Where><Eq><FieldRef Name=""Title"" /><Value Type=""Text"">" + titleVal + "</Value></Eq></Where>";

            SPWeb web = SPContext.Current.Web;
            SPList list = web.Lists[ListName];

            if (list != null)
            {
                SPQuery query = new SPQuery();
                query.Query = camlQuery;

                SPListItemCollection filteredItems = list.GetItems(query);

                DataTable dt = filteredItems.GetDataTable();

                gvResult = new GridView();
                gvResult.DataSource = dt;
                gvResult.DataBind();

                AddToTable(gvResult);
            }
        }

        protected void AddToTable(Control C)
        {
            TableCell cell = new TableCell();
            cell.Controls.Add(C);
            TableRow row = new TableRow();
            row.Controls.Add(cell);
            if (tbl != null)
            {
                tbl.Rows.Add(row);
            }
        }

        protected List<string> GetFilterValues()
        {
            SPWeb web = SPContext.Current.Web;
            SPList list = web.Lists[ListName];
            List<string> result = null;

            if (list != null)
            {
                result = new List<string>();
                foreach (SPListItem c in list.Items)
                {
                    if (result.Contains(c.Title) == false)
                    {
                        result.Add(c.Title);
                    }
                }
            }

            return result;
        }

        public override EditorPartCollection CreateEditorParts()
        {
            ArrayList partsArray = new ArrayList();
            CustomEditorPart ce = new CustomEditorPart();
            ce.ID = ID + "_editorPart1";
            ce.Title = "List";
            partsArray.Add(ce);
            EditorPartCollection parts = new EditorPartCollection(partsArray);
            return parts;
        }

    }
}
