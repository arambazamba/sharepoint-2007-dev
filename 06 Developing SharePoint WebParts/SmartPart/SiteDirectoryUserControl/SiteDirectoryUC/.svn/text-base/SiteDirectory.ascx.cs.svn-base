using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Diagnostics;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Microsoft.SharePoint;

public partial class SiteDirectory : System.Web.UI.UserControl
{
    private SPSite col = null;
    private DataTable sites = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        GetWebs();
    }

    protected void GetWebs()
    {
        col = new SPSite("http://chiron");
        
        sites = new DataTable("SiteDir");
        sites.Columns.Add(new DataColumn("ID"));
        sites.Columns.Add(new DataColumn("Sitename"));
        DataRow row = null;

        foreach (SPWeb w in col.AllWebs)
        {
            row = sites.NewRow();
            row[0] = w.ID;
            row[1] = w.Title;
            sites.Rows.Add(row);
        }

        gvSites.DataSource = sites;
        gvSites.DataBind();

        gvSites.SelectedIndex = 0;
    }
    protected void GetSelectedWeb(object sender, GridViewSelectEventArgs e)
    {
        if (e.NewSelectedIndex >= 0 && col!=null)
        {
            DataRow row = sites.Rows[e.NewSelectedIndex];
            Guid id = new Guid(row[0].ToString());

            SPWeb web = col.AllWebs[id];
            lblDescr.Text = web.Description;
            GetSiteDetails(web);
        }
    }

    protected void GetSiteDetails(SPWeb web)
    {
        DataTable dt = new DataTable("WebContent");
        dt.Columns.Add(new DataColumn("Listname"));
        dt.Columns.Add(new DataColumn("Listtype"));
        DataRow row = null;

        foreach (SPList list in web.Lists)
        {
            if (list.OnQuickLaunch)
            {
                row = dt.NewRow();
                row[0] = list.Title;
                row[1] = "List";
                dt.Rows.Add(row);
            }
        }

        gvLists.DataSource = dt;
        gvLists.DataBind();

    }
}
