using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Net.Mail;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace Integrations
{
    /// <summary> 
    /// This class deines a custom Windows Workflow Activity that sends emails 
    /// </summary> 
    public partial class CustomEmailActivity : Activity
    {

        //Create a variable to access the Event Log when errors need to be logged 
        private EventLog _eventLog;

        #region DepedencyProperties for the Activity

        public static DependencyProperty BCCProperty = DependencyProperty.Register("BCC", typeof(ArrayList), typeof(CustomEmailActivity));

        public static DependencyProperty BodyProperty = DependencyProperty.Register("Body", typeof(string), typeof(CustomEmailActivity));

        public static DependencyProperty CCProperty = DependencyProperty.Register("CC", typeof(ArrayList), typeof(CustomEmailActivity));

        public static DependencyProperty SubjectProperty = DependencyProperty.Register("Subject", typeof(string), typeof(CustomEmailActivity));

        public static DependencyProperty ToProperty = DependencyProperty.Register("To", typeof(ArrayList), typeof(CustomEmailActivity));

        public static DependencyProperty FromEmailAddressProperty = DependencyProperty.Register("FromEmailAddress", typeof(string), typeof(CustomEmailActivity));

        public static DependencyProperty SMTPServerNameProperty = DependencyProperty.Register("SMTPServerName", typeof(string), typeof(CustomEmailActivity));

        #endregion

        #region Properties

        [ValidationOption(ValidationOption.Required)]
        public string FromEmailAddress
        {
            get
            {
                return (string)base.GetValue(FromEmailAddressProperty);
            }
            set
            {
                base.SetValue(FromEmailAddressProperty, value);
            }
        }

        [ValidationOption(ValidationOption.Required)]
        public string SMTPServerName
        {
            get
            {
                return (string)base.GetValue(SMTPServerNameProperty);
            }
            set
            {
                base.SetValue(SMTPServerNameProperty, value);
            }
        }

        [ValidationOption(ValidationOption.Optional)]
        public string Body
        {
            get
            {
                return (string)base.GetValue(BodyProperty);
            }
            set
            {
                base.SetValue(BodyProperty, value);
            }
        }

        [ValidationOption(ValidationOption.Optional)]
        public ArrayList CC
        {
            get
            {
                return (ArrayList)base.GetValue(CCProperty);
            }
            set
            {
                base.SetValue(CCProperty, value);
            }
        }

        [ValidationOption(ValidationOption.Required)]
        public string Subject
        {
            get
            {
                return (string)base.GetValue(SubjectProperty);
            }
            set
            {
                base.SetValue(SubjectProperty, value);
            }
        }

        [ValidationOption(ValidationOption.Required)]
        public ArrayList To
        {
            get
            {
                return (ArrayList)base.GetValue(ToProperty);
            }
            set
            {
                base.SetValue(ToProperty, value);
            }
        }

        #endregion

        #region Contructor

        public CustomEmailActivity()
        {
            InitializeComponent();
        }

        #endregion

        #region Overidden Methods

        protected override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext)
        {
            //Set up the Event Logging object 
            _eventLog = new EventLog("Workflow");
            _eventLog.Source = "SharePoint Workflow";

            try
            {
                //Send the email 
                SendEmail();
            }
            finally
            {
                //Dispose of the Event Logging object 
                _eventLog.Dispose();
            }

            //Indicate the activity has closed 
            return ActivityExecutionStatus.Closed;
        }

        #endregion

        #region Private Methods

        private void SendEmail()
        {
            try
            {
                //Create a new object that will send the email 
                MailMessage msg = new MailMessage();
                //Create an object to specify the from address for the email 
                MailAddress fromAddress = new MailAddress(FromEmailAddress);
                //Set the from email address on the message object 
                msg.From = fromAddress;
                //Add the email addresses stored in the To property to the email message object 
                for (int i = 0; i < To.Count; i++)
                {
                    msg.To.Add(To[i].ToString());
                }
                //Add the email addresses stored in the CC property to the email message object 
                for (int i = 0; i < CC.Count; i++)
                {
                    msg.CC.Add(CC[i].ToString());
                }

                //Mark the message body as HTML 
                msg.IsBodyHtml = true;
                //Populate the subject for the message 
                msg.Subject = Subject;
                //Populate the body for the message 
                msg.Body = Body;
                //Create an object to represent the mail server that will send the message 
                SmtpClient client = new SmtpClient(SMTPServerName);
                //Set the credentials used to authenticate to the email server 
                client.UseDefaultCredentials = true;
                //Send the message 
                client.Send(msg);
            }
            catch (System.Exception Ex)
            {
                //Log exceptions in the Event Log 
                _eventLog.WriteEntry("SMTP Server Name: " + SMTPServerName +
                Environment.NewLine +
                "From: " + FromEmailAddress +
                Environment.NewLine +
                "To: " + To +
                Environment.NewLine +
                "CC: " + CC +
                Environment.NewLine +
                "Subject: " + Subject +
                Environment.NewLine +
                "Body: " + Body +
                Environment.NewLine +
                "Error: " + Ex.InnerException.ToString()
                , EventLogEntryType.Information);
            }
        }

        #endregion

    }
}

