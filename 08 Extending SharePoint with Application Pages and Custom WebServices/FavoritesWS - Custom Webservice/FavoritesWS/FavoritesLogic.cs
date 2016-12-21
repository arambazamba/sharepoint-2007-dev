using System;
using System.Collections.Generic;

using System.Collections.Generic;
using Microsoft.SharePoint;
using Integrations;

namespace Integrations
{
    public class FavoritesLogic
    {

        private  SPWeb ConnectToWeb(string SiteCollection, string Site)
        {
            SPWeb result = null;
            SPSite siteCol = new SPSite(SiteCollection);
            foreach (SPWeb web in siteCol.AllWebs)
            {
                if(web.Title == Site)
                {
                    result = web;
                    break;
                }
            }
            return result;
        }

        public string[] GetSites(string SiteCollection)
        {
            List<string> result = new List<string>();
            SPSite col = new SPSite(SiteCollection);
            result.Add(col.RootWeb.Title);
            foreach (SPWeb web in col.RootWeb.Webs)
            {
                result.Add(web.Title);
            }
            return result.ToArray();

        }

        public string[] GetListsForFeatureID(string SiteCollection, string Site, string ID)
        {
            SPWeb web = ConnectToWeb(SiteCollection, Site);
            List<string> result = new List<string>();
            Guid featureID = new Guid(ID);

            foreach (SPList list in web.Lists)
            {
                if(list.TemplateFeatureId==featureID)
                {
                 result.Add(list.Title);   
                }
            }
            return result.ToArray();
        }

        public List<FavoritesEntry> GetRemoteFavorites(string SiteCollection, string Site, string List)
        {
            List<FavoritesEntry> result = new List<FavoritesEntry>();

            SPWeb web = ConnectToWeb(SiteCollection, Site);
            SPList list = web.Lists[List];
            FavoritesEntry entry;

            foreach (SPListItem item in list.Items)
            {
                entry = new FavoritesEntry();
                SPFieldUrlValue url = new SPFieldUrlValue(item["URL"].ToString());
                entry.Url = url.Url;
                entry.Display = url.Description;

                if (item["Favorites Topic"] != null)
                {
                    entry.Topic = item["Favorites Topic"].ToString();
                }

                entry.SPID = item.UniqueId;
                entry.Modified = DateTime.Parse(item["Modified"].ToString());
                result.Add(entry);
            }
            return result;
        }

        public void UploadItems(string SiteCollection, string Site, string List, FavoritesEntry[] ClientFavs)
        {
            SPWeb web = ConnectToWeb(SiteCollection, Site);
            SPList list = web.Lists[List];
            List<FavoritesEntry> SPFavs = GetRemoteFavorites(SiteCollection, Site, List);

            foreach (FavoritesEntry ClientEntry in ClientFavs)
            {
                foreach (FavoritesEntry SPEntry in SPFavs)
                {
                    if (SPEntry.Url == ClientEntry.Url)
                    {
                        DeleteItem(list, SPEntry);
                        break;
                    }
                }

                CreateItem(list, ClientEntry);
            }
        }

        private void DeleteItem(SPList List, FavoritesEntry SPEntry)
        {
            SPListItem item = List.Items[SPEntry.SPID];
            item.Delete();
        }

        private void CreateItem(SPList List, FavoritesEntry ClientEntry)
        {
            SPListItem item = List.Items.Add();
            item["Title"] = ClientEntry.Display;

            //sp structure to store urls
            SPFieldUrlValue url = new SPFieldUrlValue();
            url.Url = ClientEntry.Url;
            url.Description = ClientEntry.Display;

            item["URL"] = url;
            item["Favorites Topic"] = ClientEntry.Topic;
            item.Update();
        }

    }
}
