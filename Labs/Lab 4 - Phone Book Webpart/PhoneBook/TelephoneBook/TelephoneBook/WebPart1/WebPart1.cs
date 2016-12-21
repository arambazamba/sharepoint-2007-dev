using System;
using System.Runtime.InteropServices;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Serialization;
using System.Data;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebPartPages;
using Microsoft.Office.Server.UserProfiles;
using Microsoft.Office.Server;

namespace TelephoneBook
{
    [Guid("5407bbc5-a059-47d7-b862-ed2438067967")]
    public class TelephoneBook : System.Web.UI.WebControls.WebParts.WebPart
    {
        public TelephoneBook()
        {
        }

        protected GridView gvResult;

        protected override void CreateChildControls()
        {
            base.CreateChildControls();
            
            DataTable dt = new DataTable();
            dt.Columns.Add("PreferredName");
            dt.Columns.Add("UserName");
            dt.Columns.Add("WorkEmail");

            SPSecurity.CatchAccessDeniedException = false;
            SPSite site = new SPSite("http://chiron");
            UserProfileManager pm = new UserProfileManager(ServerContext.GetContext(site));
            

            foreach (UserProfile profile in pm)
            {
                string[] values = new string[3];
                values[0] = profile[PropertyConstants.PreferredName].Value as string;
                values[1] = profile[PropertyConstants.UserName].Value as string;
                values[2] = profile[PropertyConstants.WorkEmail].Value as string;
                dt.Rows.Add(values);
            }

            gvResult = new GridView();
            gvResult.Width = new Unit(500);
            gvResult.DataSource = dt;
            gvResult.DataBind();

            Controls.Add(gvResult);
        }
    }
}
