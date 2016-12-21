using Microsoft.SharePoint;

namespace Integrations
{
    public class AutoTitle : SPItemEventReceiver
    {
        public override void ItemAdded(SPItemEventProperties properties)
        {
            SPListItem item = properties.ListItem;
            if (item.Title == string.Empty)
            {
                item["Title"] = item.Name.Substring(0, item.Name.LastIndexOf("."));
            }

            item.Update();
        }

        public override void ItemUpdating(SPItemEventProperties properties)
        {
            string bTitle = properties.BeforeProperties["Title"].ToString();
            string aTitle = properties.AfterProperties["Title"].ToString();

            if (bTitle != aTitle)
            {
                properties.ErrorMessage = "Title change is not allowed";
                properties.Cancel = true;
            }
        }
    }
}
