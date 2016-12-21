using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

	protected void Login1_LoginError(object sender, EventArgs e)
	{
		// Get the MembershipUser
		int i;
		MembershipUser user = Membership.GetUser(Login1.UserName);

		try
		{
			i = Int32.Parse(user.Comment);
			user.Comment = (++i).ToString();

			if (i > 3)
			{
				user.IsApproved = false;
				Response.Write("You have been locked out!");
			}
		}
		catch
		{
			user.Comment = "1";
		}

		Membership.UpdateUser(user);
	}
}
