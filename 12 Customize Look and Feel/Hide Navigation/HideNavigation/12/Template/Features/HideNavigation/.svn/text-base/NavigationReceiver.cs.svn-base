#region

using Microsoft.SharePoint;

#endregion

namespace Integrations
{
    public class NavigationReceiver : SPFeatureReceiver
    {
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            SPSite site = properties.Feature.Parent as SPSite;
            if (site != null)
                foreach (SPWeb web in site.AllWebs)
                {

                    //if using on moss hidenav should be included in 
                    //Fetures/HideNavigation/Styles
                    //otherwise use the Layouts dir

                    //Variante MOSSS

                    web.AlternateCssUrl = "/Style Library/hidenav.css";

                    //Variante WSS
                
                    //web.AlternateCssUrl = "_layouts/1033/styles/hidenav.css";
                    web.Update();
                }
        }

        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            SPSite site = properties.Feature.Parent as SPSite;
            foreach (SPWeb web in site.AllWebs)
            {
                web.AlternateCssUrl = string.Empty;
                web.Update();
            }
        }

        public override void FeatureInstalled(SPFeatureReceiverProperties properties)
        {
        }

        public override void FeatureUninstalling(SPFeatureReceiverProperties properties)
        {
        }
    }
}
