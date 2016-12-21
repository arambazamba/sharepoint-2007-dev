using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using WebPart=Microsoft.SharePoint.WebPartPages.WebPart;

namespace Integrations
{
    public class PhoneEditor : EditorPart
    {
        private TextBox property;
        private Label messages;

        protected override void CreateChildControls()
        {
            property = new TextBox();
            Controls.Add(property);
            messages = new Label();
            Controls.Add(messages);
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            property.RenderControl(writer);
            writer.Write("<br/>");
            messages.RenderControl(writer);
        }

        public override bool ApplyChanges()
        {
            try
            {
                var expression = new Regex(@"\(\d\d\d\)\s\d\d\d-\d\d\d\d");
                Match match = expression.Match(property.Text);
                if (match.Success)
                {
                    ((PhoneLabel) WebPartToEdit).Phone = property.Text;
                    messages.Text = "";
                }
                else
                {
                    ((PhoneLabel) WebPartToEdit).Phone = "Invalid phone number";
                }
            }
            catch (Exception x)
            {
                messages.Text += x.Message;
            }
            return true;
        }

        public override void SyncChanges()
        {
            try
            {
                property.Text = ((PhoneLabel) WebPartToEdit).Phone;
            }
            catch
            {
            }
        }
    }

    public class PhoneLabel : WebPart
    {
        protected string m_phone;

        [Personalizable(PersonalizationScope.Shared), WebBrowsable(false),
         WebDisplayName("Phone"),
         WebDescription("Phone number")]
        public string Phone
        {
            get { return m_phone; }
            set { m_phone = value; }
        }

        public override EditorPartCollection CreateEditorParts()
        {
            var partsArray = new ArrayList();
            var phonePart = new PhoneEditor();
            phonePart.ID = ID + "_editorPart1";
            phonePart.Title = "Phone Number";
            phonePart.GroupingText = "(xxx) xxx-xxxx";
            partsArray.Add(phonePart);
            var parts = new EditorPartCollection(partsArray);
            return parts;
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            writer.Write("<p>" + m_phone + "</p>");
        }
    }
}
