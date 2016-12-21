using System;
using System.Runtime.InteropServices;
using System.Web.UI;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Serialization;

using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebPartPages;

using System.Web; 

namespace Integrations
{
    [Guid("4effc947-19e5-4ba6-8ad5-818f41634ddd")]
    public class SimpleWebpart : System.Web.UI.WebControls.WebParts.WebPart
    {
        protected override void Render(HtmlTextWriter writer)
        {
            HttpContext context = HttpContext.Current;
            SPWeb  site = SPControl.GetContextWeb(context);  
            SPUser user = site.CurrentUser;
            string output = string.Format("Hi {0} - Welcome to the site {1}", user.Name, site.Name);
            writer.Write(output);

        }
    }
}
