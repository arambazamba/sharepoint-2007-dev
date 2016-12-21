using System;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;

public partial class UserInfo : System.Web.UI.UserControl
{
    protected Label lblInfo;

    protected void Page_Load(object sender, EventArgs e)
    {
        SPWeb web = SPContext.Current.Web;
        SPUser user = web.CurrentUser;

        lblInfo.Text = string.Format("{0}, welcome to {1}", user.LoginName, web.Title);
    }
}
