using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebPartPages;
using Microsoft.SharePoint.Navigation;
using Microsoft.SharePoint.Administration;

namespace MyCustomTheme {
  public class FeatureReceiver : SPFeatureReceiver {

    public override void FeatureActivated(SPFeatureReceiverProperties properties) {
        FeatureThemesJob.InstallThemes(properties.Definition);
    }

    public override void FeatureDeactivating(SPFeatureReceiverProperties properties) {
        FeatureThemesJob.DeleteThemes(properties.Definition);
    }

    public override void FeatureInstalled(SPFeatureReceiverProperties properties) {
        /* no op */
    }
    public override void FeatureUninstalling(SPFeatureReceiverProperties properties) {
        /* no op */
    }
  }
}
