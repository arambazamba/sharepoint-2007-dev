using System;
using System.Runtime.InteropServices;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Integrations
{
    [Guid("955dd416-3875-4371-b054-5f8c62b20ca2")]
    public class SPGridViewWP : WebPart
    {
        // implement the public properties of the webpart

        // initializes the connection string   
        private string constr = "Data Source=Chiron;Initial Catalog=AdventureWorks;Integrated Security=True";

        // decorate all properties that you want to expose with the "WebBrowsable" attribute
        [Personalizable(PersonalizationScope.Shared), WebBrowsable(true),
         WebDisplayName("Conn String"), WebDescription("DB Verbindung")]
        public string DBConnString
        {
            get { return constr; }
            set { constr = value; }
        }

        // initializes the sql statement
        private string sqlstring =
            "SELECT TOP 10 Production.Product.ProductID, Production.Product.Name, Production.Product.ProductNumber, Production.ProductSubcategory.Name AS Subcategory FROM Production.Product INNER JOIN Production.ProductSubcategory ON Production.Product.ProductSubcategoryID = Production.ProductSubcategory.ProductSubcategoryID";

        [Personalizable(PersonalizationScope.User), WebBrowsable(true),
         WebDisplayName("SQL String"), WebDescription("SQL Statement")]
        public string SQLString
        {
            get { return sqlstring; }
            set { sqlstring = value; }
        }


        private int tblwidth = 500;

        [Personalizable(PersonalizationScope.Shared), WebBrowsable(true),
         WebDisplayName("Table Width"), WebDescription("The width of the table")]
        public int TableWidth
        {
            get { return tblwidth; }
            set { tblwidth = value; }
        }

        // define controls used in your webpart
        protected Table tbl;
        protected Label lblDescr;
        protected Label lblSelection;
        protected SPGridView spgv;

        protected override void Render(HtmlTextWriter writer)
        {
            foreach (Control c in Controls)
            {
                c.RenderControl(writer);
            }
        }

        // populate your webpart
        protected override void OnLoad(EventArgs e)
        {
            tbl = new Table();
            tbl.ID = "tblControls";
            tbl.Width = new Unit(TableWidth);

            TableCell cell;
            TableRow row;

            // lable showing the sql
            lblDescr = new Label();
            lblDescr.ID = "lblDescr";
            lblDescr.Text = "Sharepoint Data Webpart using SQL Statement:<p/>" + SQLString + "<p/>";
            cell = new TableCell();
            cell.ID = "tcDescr1";
            cell.Controls.Add(lblDescr);
            row = new TableRow();
            row.Cells.Add(cell);
            row.ID = "rDescr";
            tbl.Rows.Add(row);

            // the gridview
            spgv = new SPGridView();
            spgv.ID = "gvProducts";
            //spgv.AutoGenerateSelectButton = true;        

            // hook the event handler
            // spgv.SelectedIndexChanging += RowSelected;

            // bind the data
            DataTable dt = GetProductsTable();
            spgv.DataSource = dt;

            // SPGridView does not support auto generate columns
            spgv.AutoGenerateColumns = false;
            BoundField fld = null;
            foreach (DataColumn dc in dt.Columns)
            {
                fld = new BoundField();
                fld.DataField = dc.ColumnName;
                fld.HeaderText = dc.ColumnName;
                fld.HtmlEncode = false;
                spgv.Columns.Add(fld);
            }

            // SPGridView supports grouping
            spgv.AllowGrouping = true;
            spgv.GroupField = "Subcategory";
            spgv.GroupFieldDisplayName = "Subcategory";

            spgv.DataBind();

            cell = new TableCell();
            cell.ID = "tcGVCell";
            cell.Controls.Add(spgv);
            row = new TableRow();
            row.ID = "rGVRow";
            row.Cells.Add(cell);
            tbl.Rows.Add(row);

            // lable showing the selection from the gridview
            lblSelection = new Label();
            cell = new TableCell();
            cell.ID = "tcSelection";
            cell.Controls.Add(lblSelection);
            row = new TableRow();
            row.ID = "rSelection";
            row.Cells.Add(cell);
            tbl.Rows.Add(row);


            Controls.Add(tbl);
        }

        /// <summary>
        /// request the data for the grid view from a given database connenction using a configurable sql statement
        /// </summary>
        /// <returns></returns>
        protected DataTable GetProductsTable()
        {
            SqlConnection con = new SqlConnection(DBConnString);
            SqlCommand cmd = new SqlCommand(SQLString, con);
            DataTable dt = new DataTable("ProductsTable");
            con.Open();
            dt.Load(cmd.ExecuteReader());
            con.Close();
            return dt;
        }

        protected void RowSelected(object sender, GridViewSelectEventArgs e)
        {
            if (e.NewSelectedIndex >= 0)
            {
                GridViewRow row = spgv.Rows[e.NewSelectedIndex];
                lblSelection.Text = string.Format("</p>You selected {0} with ID {1}", row.Cells[2].Text,
                                                  row.Cells[1].Text);
            }
        }
    }
}
