using System.Runtime.InteropServices;
using System.Web.UI;
using System.Web.UI.WebControls.WebParts;

namespace Integrations
{
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
            if (data!=null)
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