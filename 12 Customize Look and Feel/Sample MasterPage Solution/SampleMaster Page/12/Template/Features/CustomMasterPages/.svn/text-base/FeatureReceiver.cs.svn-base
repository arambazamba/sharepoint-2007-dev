using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.SharePoint;

namespace Integrations
{
    public class CustomMasterReceiver : SPFeatureReceiver
    {
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            SPWeb web = ((SPSite) properties.Feature.Parent).RootWeb;
            web.AlternateCssUrl = "/Style Library/hidenav.css";
            web.Update();
        }

        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            SPWeb web = ((SPSite)properties.Feature.Parent).RootWeb;
            web.AlternateCssUrl = string.Empty;
            web.Update();

        }

        public override void FeatureInstalled(SPFeatureReceiverProperties properties)
        {

        }

        public override void FeatureUninstalling(SPFeatureReceiverProperties properties)
        {

        }
    }
}
