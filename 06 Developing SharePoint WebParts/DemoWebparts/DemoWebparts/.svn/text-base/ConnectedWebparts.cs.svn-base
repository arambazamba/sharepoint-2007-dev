using System;
using System.Runtime.InteropServices;
using System.Web.UI;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.WebControls;
using System.Xml.Serialization;

using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebPartPages;

namespace Integrations
{
    
    // define the interfact used for data exchage
    public interface IStringContent
    {
        string StringValue { get;}
    }

    // implement the sending webpart
    [Guid("1427bd12-bd1f-4a7c-8c93-9071edff9b02")]
    public class SendingWebPart : System.Web.UI.WebControls.WebParts.WebPart, IStringContent
    {

        // define the controls used in the webpart
        protected TextBox tb=null;
        protected LinkButton lb=null;

        protected override void OnLoad(EventArgs e)
        {
            tb = new TextBox();
            tb.Text = "Sample Value";
            Controls.Add(tb);

            lb = new LinkButton();
            lb.Text = "Click me";
            lb.Click += lb_Click;
            
            Controls.Add(lb);
        }

        // an internal field to store the values
        protected string stringValue = string.Empty;

        [ConnectionProvider("String Provider")]
        public IStringContent SharedData()
        { return this; }

        public string StringValue
        {
            get { return stringValue; }
        }

        void lb_Click(object sender, EventArgs e)
        {
            stringValue = tb.Text;
        }
         
      
    }

    // implement the consuming webpart
    [Guid("1427bd12-bd1f-4a7c-8c93-9071edff9b03")]
    public class ConsumingWebPart : System.Web.UI.WebControls.WebParts.WebPart
    {

        IStringContent data = null;

        [ConnectionConsumer("String Consumer")]
        public void GetConnectionInterface(IStringContent ExchangedData)
        {
            data = ExchangedData;
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            if (data!=null && data.ToString()!=string.Empty)
            {
                writer.Write(data.StringValue);

            }
            else
            {
                writer.Write("No Value passed");
            }
        }
    }

}
