using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

using Integrations;
using System.Collections.Generic;

namespace Integrations
{
    [WebService(Namespace = "http://integrations.at/favorites")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class FavoritesWS : System.Web.Services.WebService
    {
        public FavoritesWS()
        {
        }

        [WebMethod]
        public string[] GetSites(string siteCollection)
        {
            FavoritesLogic fs = new FavoritesLogic();
            return fs.GetSites(siteCollection);
        }

        [WebMethod]
        public string[] GetFavoritesListsForWeb(string SiteCollection, string Web)
        {
            FavoritesLogic fs = new FavoritesLogic();
            return fs.GetListsForFeatureID(SiteCollection, Web, "d222342d-5556-40a7-be42-97dbd08a9d96");
        }

        [WebMethod]
        public void UploadFavorites(string SiteCollection, string SharepointSite, string List, string Favorites)
        {
            FavoritesLogic fs = new FavoritesLogic();
            fs.UploadItems(SiteCollection, SharepointSite, List, FavoritesEntry.Deserialize(Favorites));
        }

        [WebMethod]
        public string GetRemoteFavorites(string SiteCollection, string SharepointSite, string List)
        {
            FavoritesLogic fs = new FavoritesLogic();
            return FavoritesEntry.Serialize(fs.GetRemoteFavorites(SiteCollection, SharepointSite, List).ToArray());
        }
    }
}
