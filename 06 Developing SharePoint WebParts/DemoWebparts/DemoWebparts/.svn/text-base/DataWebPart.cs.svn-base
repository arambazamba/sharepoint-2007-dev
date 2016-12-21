using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Integrations
{
    [Guid("955dd416-3875-4371-b054-5f8c62b20ca2")]
    public class DataWebPart : WebPart
    {
        // implement the public properties of the webpart

        // initializes the connection string   
        protected string constr = "Data Source=Chiron;Initial Catalog=AdventureWorks;Integrated Security=True";

        // decorate all properties that you want to expose with the "WebBrowsable" attribute
        [Personalizable(PersonalizationScope.Shared), WebBrowsable(true),
         WebDisplayName("Conn String"), WebDescription("DB Verbindung")]
        public string DBConnString
        {
            get { return constr; }
            set { constr = value; }
        }

        // initializes the sql statement
        protected string sqlstring = "Select TOP 10 ProductID, Name, ProductNumber from Production.Product";

        [Personalizable(PersonalizationScope.Shared), WebBrowsable(true),
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
        protected Table layoutTable;
        protected Label lblDescr;
        protected Label lblSelection;
        protected GridView gv;

        // populate your webpart
        protected override void OnLoad(EventArgs e)
        {
            layoutTable = new Table();
            layoutTable.ID = "tblControls";
            layoutTable.Width = new Unit(TableWidth);

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
            layoutTable.Rows.Add(row);

            // the gridview
            gv = new GridView();
            gv.ID = "gvProducts";
            gv.AutoGenerateSelectButton = true;

            // hook the event handler
            gv.SelectedIndexChanging += RowSelected;

            // bind the data
            gv.DataSource = GetProductsTable();
            gv.DataBind();

            cell = new TableCell();
            cell.ID = "tcGVCell";
            cell.Controls.Add(gv);
            row = new TableRow();
            row.ID = "rGVRow";
            row.Cells.Add(cell);
            layoutTable.Rows.Add(row);

            // lable showing the selection from the gridview
            lblSelection = new Label();

            cell = new TableCell();
            cell.ID = "tcSelection";
            cell.Controls.Add(lblSelection);
            row = new TableRow();
            row.ID = "rSelection";
            row.Cells.Add(cell);
            layoutTable.Rows.Add(row);
            
            Controls.Add(layoutTable);
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
                GridViewRow row = gv.Rows[e.NewSelectedIndex];
                lblSelection.Text = string.Format("</p>You selected {0} with ID {1}", row.Cells[2].Text,
                                                  row.Cells[1].Text);
            }
        }
    }
}
