using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;

namespace Alerts_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            SPSite site = new SPSite("http://chiron");
            SPWeb web = site.AllWebs["CodeDemo"];
            SPUser user = web.CurrentUser;

            foreach (SPAlert alert in user.Alerts)
            {
                Debug.WriteLine(alert.AlertType);

                if (alert.AlertType == SPAlertType.List)
                {
                    //user.Alerts.Delete(alert.ID);
                }
            }

            SPAlertCollection alerts = web.Alerts;
            SPList list = web.Lists["Documents"];

            // get the lists alert template and apply that to the new alert
            SPAlertTemplate alertTemplate = list.AlertTemplate;
            alertTemplate.Name = list.AlertTemplate.Name;

            // setup the alert
            SPAlert a = alerts.Add();
            a.AlertType = SPAlertType.List;
            a.AlertTemplate = alertTemplate;
            a.Title = "Demo Title";
            a.EventType = SPEventType.Add;
            a.AlertFrequency = SPAlertFrequency.Immediate;
            a.AlwaysNotify = false;
            a.User = user;
            a.List = list;
            a.Update(true);
        }
    }
}
