using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Integrations;

namespace Integrations
{
    public partial class ucNavigation : UserControl
    {
        public ucNavigation()
        {
            InitializeComponent();
        }

        public DisplayMode View;
        public ScopeLevel CS;
        public wfSpy parent = null;


        private void ucNavigation_Load(object sender, EventArgs e)
        {
            parent = (wfSpy)ParentForm;
            DoLoad();
        }

        public void DoLoad()
        {
            tvFarm.Nodes.Clear();
            SPFarm farm = SPFarm.Local;

            TreeNode farmnode = new TreeNode("Farm", 5, 5);
            farmnode.Tag = farm;
            tvFarm.Nodes.Add(farmnode);
            AddSolutions(farmnode);
            AddWebApplications(farmnode, farm);
        }

        private void AddWebApplications(TreeNode farmnode, SPFarm farm)
        {
            SPWebServiceCollection ws = new SPWebServiceCollection(farm);

            // a node representing the web application
            TreeNode wanode = null;

            foreach (SPWebService webservice in ws)
            {
                foreach (SPWebApplication wa in webservice.WebApplications)
                {
                    if (!wa.IsAdministrationWebApplication)
                    {
                        wanode = new TreeNode(wa.DisplayName, 6, 6);
                        wanode.Tag = wa;
                        farmnode.Nodes.Add(wanode);

                        AddFeaturesForWA(wa, wanode);

                        foreach (SPSite s in wa.Sites)
                        {
                            AddSiteCollections(s.RootWeb.Url, wanode);
                        }
                    }
                }
            }
        }

        private void AddSiteCollections(string url, TreeNode pnode)
        {
            SPSite col = new SPSite(url);

            TreeNode chnode = new TreeNode(col.RootWeb.Title, 7, 7);
            chnode.Tag = col;
            pnode.Nodes.Add(chnode);

            AddFeaturesForSC(col, chnode);

            SPWeb web = col.RootWeb;
            AddWebs(web, chnode);
            chnode.Expand();
        }

        private void AddWebs(SPWeb pw, TreeNode pnode)
        {
            foreach (SPWeb chw in pw.GetSubwebsForCurrentUser())
            {
                TreeNode cn = new TreeNode(chw.Title, 3, 3);
                cn.Tag = chw;
                if (chw.GetSubwebsForCurrentUser().Count > 0)
                {
                    AddWebs(chw, cn);
                }

                AddFeaturesForWeb(chw, cn);
                AddLists(chw, cn);

                pnode.Nodes.Add(cn);
            }
        }

        private void AddSolutions(TreeNode pnode)
        {
            SPFarm farm = SPFarm.Local;
            foreach (SPSolution s in farm.Solutions)
            {
                TreeNode chnode = new TreeNode(s.Name, 4, 4);
                chnode.Tag = s;
                pnode.Nodes.Add(chnode);
            }
        }

        private void AddFeaturesForWA(SPWebApplication wa, TreeNode pnode)
        {
            SPFeatureScope Scope = SPFeatureScope.WebApplication;
            SPFeatureCollection active = wa.Features;

            List<SPFeatureDefinition> fds = SPBroker.GetAllFeaturesForScope(Scope);
            AddFeaturesForScope(pnode, fds, active);
        }

        private void AddFeaturesForSC(SPSite col, TreeNode pnode)
        {
            SPFeatureScope Scope = SPFeatureScope.Site;
            SPFeatureCollection active = col.Features;

            List<SPFeatureDefinition> fds = SPBroker.GetAllFeaturesForScope(Scope);
            AddFeaturesForScope(pnode, fds, active);
        }


        private void AddFeaturesForWeb(SPWeb pw, TreeNode pnode)
        {
            SPFeatureScope Scope = SPFeatureScope.Web;
            SPFeatureCollection active = pw.Features;

            List<SPFeatureDefinition> fds = SPBroker.GetAllFeaturesForScope(Scope);
            AddFeaturesForScope(pnode, fds, active);
        }

        private void AddFeaturesForScope(TreeNode pnode, List<SPFeatureDefinition> fds, SPFeatureCollection active)
        {
            TreeNode fnode = new TreeNode("Features", 9, 9);
            pnode.Nodes.Add(fnode);

            foreach (SPFeatureDefinition fd in fds)
            {
                SPFeature f = active[fd.Id];

                TreeNode chnode;
                if (f == null)
                {
                    chnode = new TreeNode(fd.DisplayName, 1, 1);
                }
                else
                {
                    chnode = new TreeNode(fd.DisplayName, 0, 0);
                }
                chnode.Tag = f;
                fnode.Nodes.Add(chnode);
            }
        }

        private void AddLists(SPWeb web, TreeNode pnode)
        {
            TreeNode cn = null;

            foreach (SPList list in web.Lists)
            {
                cn = new TreeNode(list.Title, 10, 10);
                cn.Tag = list;
                pnode.Nodes.Add(cn);
            }
        }

        private void tvFarm_AfterSelect(object sender, TreeViewEventArgs e)
        {
            parent.SourceObject = e.Node.Tag;
            if (parent.SourceObject != null)
            {
                
                parent.pContent.Controls.Clear();
                NodeType current = GetNodeType(parent.SourceObject);

                switch(current)
                {
                    case NodeType.Farm:
                        parent.pContent.Controls.Add(new ucFarm());
                        break;
                    case NodeType.WebApplication:
                        break;
                    case NodeType.SiteCollection:
                        break;
                    case NodeType.Site:
                        break;
                    case NodeType.Feature:
                        parent.pContent.Controls.Add(new ucFeatures());
                        break;
                    case NodeType.Solution:
                        parent.pContent.Controls.Add(new ucSolutions());
                        break;
                    case NodeType.List:
                        break;
                    case NodeType.ContentType:
                        break;
                    default:
                        break;
                }
            }
        }

        private void AddCMItems(object sender, CancelEventArgs e)
        {
            if(tvFarm.SelectedNode!=null)
            {
                NodeType current = GetNodeType(tvFarm.SelectedNode.Tag);
                cmNavigation.Items.Clear();

                switch(current)
                {
                    case NodeType.Farm:
                        break;
                    case NodeType.WebApplication:
                        break;
                    case NodeType.SiteCollection:
                        break;
                    case NodeType.Site:
                        break;
                    case NodeType.Feature:
                        break;
                    case NodeType.Solution:
                        
                        break;
                    case NodeType.List:
                        break;
                    case NodeType.ContentType:
                        break;
                    default:
                        break;
                }
            }
        }

        private void AddCMItem(string DisplayName, EventHandler evtHandler)
        {
            ToolStripMenuItem mi = new ToolStripMenuItem(DisplayName,null,evtHandler);
            cmNavigation.Items.Add(mi);
        }

        private NodeType GetNodeType(object NodeContent)
        {
            if(NodeContent!=null)
            {
                Type t = NodeContent.GetType();
                if (t == typeof(SPFarm))
                {
                    return NodeType.Farm;
                }
                else if (t == typeof(SPWebApplication))
                {
                    return NodeType.WebApplication;
                }
                else if (t == typeof(SPSite))
                {
                    return NodeType.SiteCollection;
                }
                else if (t == typeof(SPWeb))
                {
                    return NodeType.Site;
                }
                else if (t == typeof(SPFeature))
                {
                    return NodeType.Feature;
                }
                else if (t == typeof(SPSolution))
                {
                    return NodeType.Solution;
                }
            }
            return NodeType.NotImplemented;
        }
    }
}
