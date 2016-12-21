using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Integrations;

namespace Integrations
{
    public partial class wfFavorites : Form
    {
        public wfFavorites()
        {
            InitializeComponent();
        }

        private Integrations.FavoritesWS fws = null;

        private bool internalUpdate = false;

        private void wfFavoritesLoad(object sender, EventArgs e)
        {
        }

        private void InitializeWS()
        {
            fws = new Integrations.FavoritesWS();
            fws.Credentials = CredentialCache.DefaultCredentials;
        }
     
        private void btnConnect_Click(object sender, EventArgs e)
        {
            lblStatus.Text = string.Empty;

            InitializeWS();

            string[] webs = fws.GetSites(txtCollection.Text);

            cbSite.Items.AddRange(webs);   
            if(webs.GetUpperBound(0)>0)
            {
                internalUpdate = true;
                cbSite.SelectedIndex = 0;
                internalUpdate = false;
            }

            pbConnected.Image = ilPics.Images[1];
            
        }

        private void SiteSelected(object sender, EventArgs e)
        {
            if (internalUpdate==false)
            {
                InitializeWS();

                string[] lists = fws.GetFavoritesListsForWeb(txtCollection.Text, cbSite.SelectedItem.ToString());

                foreach (string list in lists)
                {
                    cbList.Items.Add(list);
                }

                if (lists.GetLength(0) > 0)
                {
                    cbList.SelectedIndex = 0;
                }                
            }
        }

        private void UploadFavorites(object sender, EventArgs e)
        {
            lblStatus.Text = string.Empty;

            string collection = txtCollection.Text;
            string web = cbSite.SelectedItem.ToString();
            string list = cbList.SelectedItem.ToString();

            InitializeWS();

            List<FavoritesEntry> items = FavoritesEntry.GetLocalFavorites();
            
            fws.UploadFavorites(collection, web, list, FavoritesEntry.Serialize(items.ToArray()));

            lblStatus.Text = "Favorites have been uploaded";
            
        }

        private void DownloadFavorites(object sender, EventArgs e)
        {
            lblStatus.Text = string.Empty;


            string collection = txtCollection.Text;
            string web = cbSite.SelectedItem.ToString();
            string list = cbList.SelectedItem.ToString();

            InitializeWS();
            List<FavoritesEntry> ClientFavs = FavoritesEntry.GetLocalFavorites();

            List<FavoritesEntry> SPFavs = new List<FavoritesEntry>();
            SPFavs.AddRange(FavoritesEntry.Deserialize(fws.GetRemoteFavorites(collection, web, list)));


            foreach (FavoritesEntry SPFav in SPFavs)
            {

                foreach (FavoritesEntry ClientFav in ClientFavs)
                {
                    if (ClientFav.Url == SPFav.Url)
                    {

                        FavoritesEntry.DeleteLocalFavorite(ClientFav);
                        break;
                    }
                }

                FavoritesEntry.CreateLocalFavorite(SPFav);
            }

            lblStatus.Text = "Favorites have been downloaded";
        }

    }
}