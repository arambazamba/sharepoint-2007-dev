using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		if (User.Identity.IsAuthenticated)
		{
			MembershipUser CurrentUser = Membership.GetUser();

			StringBuilder UserInfo = new StringBuilder();
			UserInfo.AppendFormat("User Name: {0}<br>", CurrentUser.UserName);
			UserInfo.AppendFormat("Email: {0}<br>", CurrentUser.Email);
			UserInfo.AppendFormat("Last Login: {0}<br>", CurrentUser.LastLoginDate);
			UserInfo.AppendFormat("Registered: {0}<br>", CurrentUser.CreationDate);

			UserInfoLabel.Text = UserInfo.ToString();
		}
		else
		{
			UserInfoLabel.Text = "Not logged in!";
		}
    }
 
}
