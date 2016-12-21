using Microsoft.SharePoint;

namespace Integrations
{
    public class CustomMasterReceiver : SPFeatureReceiver
    {
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            SPWeb web = ((SPSite) properties.Feature.Parent).RootWeb;
            web.MasterUrl = "/_catalogs/masterpage/default.master";
            web.CustomMasterUrl = "/_catalogs/masterpage/reverse_green.master";
            web.Update();
        }

        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            SPWeb web = ((SPSite) properties.Feature.Parent).RootWeb;
            web.MasterUrl = "/_catalogs/masterpage/default.master";
            web.CustomMasterUrl = "/_catalogs/masterpage/default.master";
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
