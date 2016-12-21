using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

namespace Integrations
{
    public partial class ucSolutions : ucContentBase
    {
        public ucSolutions()
        {
            InitializeComponent();
        }

        private SPSolution CurrentSolution = null;
        private SPFeatureDefinition CurrentFeature = null;


        private void LoadContent(object sender, EventArgs e)
        {
            CurrentSolution = (SPSolution)SourceObject;
            SetFeaturesForSolution();
        }

        private void SetFeaturesForSolution()
        {
            List<SPFeatureDefinition> features = SPBroker.GetFeaturesForSolution(CurrentSolution.Id);
            gpSolution.Text = CurrentSolution.DisplayName;

            lvSolutions.Items.Clear();
            foreach (SPFeatureDefinition f in features)
            {
                AddFeaturesInSolutionLVI(f);
            }
        }

        private void AddFeaturesInSolutionLVI(SPFeatureDefinition f)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.SubItems.Add(f.DisplayName);
            lvi.SubItems.Add(f.Scope.ToString());
            lvi.SubItems.Add(f.Hidden.ToString());
            lvi.SubItems.Add(f.Version.ToString());
            lvi.Tag = f;
            lvSolutions.Items.Add(lvi);
        }

        private void FeatureSelected(object sender, EventArgs e)
        {
            if (lvSolutions.SelectedItems.Count>0)
            {
                CurrentFeature = (SPFeatureDefinition)lvSolutions.SelectedItems[0].Tag; 
                gbSites.Text = "Sites using " + CurrentFeature.DisplayName;
                
                lvWebs.Items.Clear();
                List<SPWeb> sites = SPBroker.GetSitesUsingFeature(CurrentFeature.Id);               
                foreach (SPWeb web in sites)
                {                   
                    AddFeaturesInWebLvi(web, UsageType.Direct);                    
                }
                foreach (SPWeb web in SPBroker.GetSitesUsingFeatureInDependency(CurrentFeature.Id))
                {
                    AddFeaturesInWebLvi(web,UsageType.Dependency);
                }
            }
        }

        private void AddFeaturesInWebLvi(SPWeb web, UsageType usage)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.SubItems.Add(web.Site.RootWeb.Title);
            lvi.SubItems.Add(web.Title);
            lvi.SubItems.Add(usage.ToString());
            lvi.Tag = web;
            lvWebs.Items.Add(lvi);
        }
    }
}
