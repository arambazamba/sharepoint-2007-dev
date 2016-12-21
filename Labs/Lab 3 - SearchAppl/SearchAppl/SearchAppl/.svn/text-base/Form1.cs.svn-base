using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Microsoft.SharePoint;
using Microsoft.Office.Server.Search.Administration;
using Microsoft.Office.Server.Search.Query;
using Microsoft.Office.Server;

namespace Integrations
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Scopes SCScopes = GetScopesForSiteCollection();
            foreach (Scope s in SCScopes.GetSharedScopes())
            {
                DropDownHelper<Scope> dds = new DropDownHelper<Scope>(s.Name, s);
                cbScope.Items.Add(dds);
            }
        }

        public Scopes GetScopesForSiteCollection()
        {
            SPSite col = new SPSite(txtSC.Text);
            ServerContext ctxServer = ServerContext.GetContext(col);
            SearchContext sc = SearchContext.GetContext(ctxServer);
            return new Scopes(sc);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SPSite col = new SPSite(txtSC.Text);
            ServerContext ctx = ServerContext.GetContext(col);
            DropDownHelper<Scope> dds = (DropDownHelper<Scope>)cbScope.SelectedItem;
            string ScopeName = dds.Item.Name;

            string query = "Select title, url FROM Scope() where \"Scope\" = '" + ScopeName + "' AND Freetext('" + txtPhrase.Text + " ')";


            FullTextSqlQuery ftq = new FullTextSqlQuery(ctx);
            ftq.ResultTypes = ResultType.RelevantResults;
            ftq.EnableStemming = true;
            ftq.TrimDuplicates = true;
            ftq.QueryText = query;

            ResultTableCollection allresults = ftq.Execute();

            ResultTable relevant = allresults[ResultType.RelevantResults];

            DataTable dt = null;
            if (relevant.RowCount > 0)
            {
                dt = new DataTable("Search Result");
                dt.Columns.Add("Title");
                dt.Columns.Add("URL");
                while (relevant.Read())
                {
                    DataRow row = dt.NewRow();
                    row[0] = relevant.GetString(0);
                    row[1] = relevant.GetString(1);
                    dt.Rows.Add(row);
                }

                gvResult.DataSource = dt;
                gvResult.AutoResizeColumns();
                
            }

        }

      

    }
}