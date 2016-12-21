using Microsoft.SharePoint;

namespace Integrations
{
    public class SimpleFeatureReceiver : SPFeatureReceiver
    {
        public override void FeatureInstalled(SPFeatureReceiverProperties properties)
        {
        }

        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            SPWeb web = (SPWeb) properties.Feature.Parent;
            web.Title += " - with Simple Feature";
            web.Update();
        }

        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            SPWeb web = (SPWeb) properties.Feature.Parent;
            web.Title = web.Title.Substring(0, web.Title.IndexOf(" -"));
            web.Update();
        }


        public override void FeatureUninstalling(SPFeatureReceiverProperties properties)
        {
        }
    }
}