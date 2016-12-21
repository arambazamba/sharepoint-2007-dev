using System;
using System.Runtime.InteropServices;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Serialization;

using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebPartPages;


namespace Integrations
{
    [Guid("205d27ef-9fe4-4b54-9d6c-14c1afdb163e")]
    public class AjaxPart : System.Web.UI.WebControls.WebParts.WebPart
    {
        public AjaxPart()
        {
        }

        protected Table tbl;
        protected Label lblInstructions;
        protected Label lblStatus;
        protected Button btnAction;
        protected TextBox txtMessage;

        protected override void CreateChildControls()
        {
            base.CreateChildControls();

            // if you have not installed SharePoint SP1 then uncomment the line below
            //EnsureUpdatePanelFixups();
            
            UpdatePanel up = new UpdatePanel();
            up.ID = "upContent";
            up.ChildrenAsTriggers = true;
            up.UpdateMode = UpdatePanelUpdateMode.Conditional;
            Controls.Add(up);
            
            tbl = new Table();

            lblInstructions = new Label();
            lblInstructions.Text = "Enter your message below";
            AddRow(lblInstructions);

            txtMessage = new TextBox();
            txtMessage.ID = "TextBox";
            AddRow(txtMessage);
            
            btnAction = new Button();
            btnAction.ID = "btnAction";
            btnAction.Text = "Show Message";
            btnAction.Click += new EventHandler(HandleButtonClick);
            AddRow(btnAction);

            lblStatus = new Label();
            lblStatus.Text = string.Empty;
            AddRow(lblStatus);

            up.ContentTemplateContainer.Controls.Add(tbl);
        }

        private void AddRow(Control ctrl)
        {
            TableRow row = new TableRow();
            TableCell cell = new TableCell();
            cell.Controls.Add(ctrl);
            row = new TableRow();
            row.Controls.Add(cell);
            tbl.Controls.Add(row);
        }

        private void HandleButtonClick(object sender, EventArgs eventArgs)
        {
            lblStatus.Text = "Your Message was:<br>" + txtMessage.Text;
        }

        private void EnsureUpdatePanelFixups()
        {
            if (this.Page.Form != null)
            {
                string formOnSubmitAtt = this.Page.Form.Attributes["onsubmit"];
                if (formOnSubmitAtt == "return _spFormOnSubmitWrapper();")
                {
                    this.Page.Form.Attributes["onsubmit"] = "_spFormOnSubmitWrapper();";
                }
            }
            ScriptManager.RegisterStartupScript(this, typeof(AjaxPart), "UpdatePanelFixup", "_spOriginalFormAction = document.forms[0].action; _spSuppressFormOnSubmitWrapper=true;", true);
        }

    }
}
