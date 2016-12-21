using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.SharePoint;
using System.Net.Mail;

namespace Integrations
{
    public class ChangeReceiver : SPItemEventReceiver
    {
        private List<SPUser> notified;
        private SPListItem item;
        private SPList optionslist;

        private string opt_subject;
        private string opt_message;
        private string opt_host;
        private int opt_port;

        public override void ItemAdded(SPItemEventProperties properties)
        {
            Notify(properties);
        }

        public override void ItemUpdated(SPItemEventProperties properties)
        {
            Notify(properties);
        }

        private void Notify(SPItemEventProperties properties)
        {
            SPWeb web = properties.OpenWeb();
            item = properties.ListItem;
            notified = new List<SPUser>();
            List<string> actions = new List<string>();
            List<string> groups = new List<string>();

            ReadConfig(web, actions, groups);

            if ((properties.EventType == SPEventReceiverType.ItemAdded && actions.Contains("insert")) ||
                (properties.EventType == SPEventReceiverType.ItemUpdated && actions.Contains("update")))
            {
                string Event=string.Empty;
                if (properties.EventType == SPEventReceiverType.ItemAdded)
                {
                    Event = "hinzugefügt";
                }
                else if (properties.EventType == SPEventReceiverType.ItemUpdated)
                {
                    Event = "geändert";
                }
                ExpandGroups(web, groups.ToArray(), Event);
            }
        }

        private void ReadConfig(SPWeb web, List<string> actions, List<string> groups)
        {
            optionslist = web.Lists["Notify"];
            string opt_actions = GetOptionValue("Events");
            string opt_groups = GetOptionValue("Groups");
            opt_subject = GetOptionValue("Subject");
            opt_message = GetOptionValue("Message");
            opt_host = GetOptionValue("SMTPHost");
            opt_port = Convert.ToInt32( GetOptionValue("Port"));

            SplitValues(opt_actions, actions);
            SplitValues(opt_groups, groups);
        }

        private SPListItem GetOption(string OptionName)
        {
            SPListItem result=null;
            foreach (SPListItem li in optionslist.Items)
            {
                if (li.Title == OptionName)
                {
                    result = li;
                    break;
                }
            }
            return result;
        }

        private string GetOptionValue(string OptionName)
        {
            return GetOption(OptionName)["Value"].ToString();
        }

        private void SplitValues(string Options, List<string> OList)
        {
            int sep = Options.IndexOf("\r\n");

            if (sep != -1)
            {
                string option = Options.Substring(0, sep);
                if (option.Trim().Length > 0)
                {
                    OList.Add(option.Trim());
                    SplitValues(Options.Substring(sep + 2), OList);
                }
            }
        }

        private void ExpandGroups(SPWeb web, string[] Groups, string Event)
        {
            foreach (string s in Groups)
            {

                foreach (SPGroup grp in web.Site.RootWeb.Groups    )
                {
                    if (grp.Name == s)
                    {
                        foreach (SPUser u in grp.Users)
                        {
                            SendMail(u,Event);
                        }
                    }
                }
            }
        }

        protected void SendMail(SPUser User, string Event )
        {
            //Check if user has been already notified
            if (notified.Contains(User) == false)
            {
                notified.Add(User);
                MailMessage mail = new MailMessage();
                mail.Subject = opt_subject;
                opt_message = opt_message.Replace("(Item)", item.Name);
                opt_message = opt_message.Replace("(changetype)", Event);
                mail.Body = opt_message;
                mail.Sender = new MailAddress(User.Email); 
                SmtpClient client = new SmtpClient(opt_host,opt_port);
                client.Send(mail);
            
            }
        }
    }

    //public class MailNotificationActivated : SPFeatureReceiver
    //{

    //    public override void FeatureActivated(SPFeatureReceiverProperties properties)
    //    {

    //    }

    //    public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
    //    {
    //        /* no op */
    //    }

    //    public override void FeatureInstalled(SPFeatureReceiverProperties properties)
    //    {
    //        /* no op */
    //    }
    //    public override void FeatureUninstalling(SPFeatureReceiverProperties properties)
    //    {
    //        /* no op */
    //    }
    //}
}