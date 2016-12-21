using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Text;
using System.Web;

using Microsoft.SharePoint;
using Integrations;
using Microsoft.SharePoint.Administration; // used to get a reference to SPFarm

namespace Integrations
{
    public class SPBroker
    {
        private SPFarm farm = SPFarm.Local;

        #region Gerneral Helpers

        private  SPWeb ConnectToWeb(string SiteCollection, string Site)
        {
            SPSite siteCol = new SPSite(SiteCollection);
            return siteCol.AllWebs[Site];
        }

        private SPSite ConnectToSiteCollection(string SiteCollection)
        {
         return new SPSite(SiteCollection);   
        }

        public SPList GetListByID(string SiteCollection, Guid Web, Guid List)
        {
            string result = string.Empty;
            SPSite col = ConnectToSiteCollection(SiteCollection);
            SPWeb web = col.AllWebs[Web];
            SPList list = web.Lists[List];
            return list;

        }

        #endregion

        #region Lists Manager

       public SPListCollection GetGenericListsForWeb(string SiteCollection, string Site)
        {
            SPWeb web = ConnectToWeb(SiteCollection, Site);
            return web.GetListsOfType(SPBaseType.GenericList);
        }


        

        //public  bool UploadItems(string SiteCollection, string Site, string List, FavoritesEntry [] Favorites)
        //{
        //    SPWeb web = ConnectToWeb(SiteCollection, Site);
        //    SPList list = web.Lists[List];
                      
        //    SPListItemCollection itemsCol = list.Items;

        //    foreach (FavoritesEntry fe in Favorites)
        //    {
        //        SPListItem item = itemsCol.Add();
        //        item["Title"] = fe.Display;

        //        //sp structure to store urls
        //        SPFieldUrlValue url = new SPFieldUrlValue();
        //        url.Url = fe.Url;
        //        url.Description = fe.Display;

        //        item["URL"] = url;
        //        item["Topic"] = fe.Topic;
        //        item.Update();
        //    }

        //    return true;
        //}

        
        #endregion

        #region Solutions

        string uploadPath = @"D:\Webs\IntegrationsWS\UploadedSolutions\";

        public bool CheckSolution(Guid SolutionGUID)
        {
            bool result = false;
            
            SPSolution sol = farm.Solutions[SolutionGUID];           
            if (sol!=null)
            {
                result = true;
            }
            return result;
        }

        public SPSolutionCollection GetSolutions()
        {            
            return farm.Solutions;
        }

        public DataTable GetSolutionTable()
        {
            DataTable dt = new DataTable("Solutions");
            DataColumn dc = null;
            dc = new DataColumn("ID", typeof(Guid));
            dt.Columns.Add(dc);

            dc = new DataColumn("Name", typeof(string));
            dt.Columns.Add(dc);
            dc = new DataColumn("Added", typeof(bool));
            dt.Columns.Add(dc);
            dc = new DataColumn("Deployed", typeof(bool));
            dt.Columns.Add(dc);
            
            DataRow row = null;
           
            foreach (SPSolution s in farm.Solutions)
            {
                row = dt.NewRow();
                row[0] = s.Id;
                row[1] = s.Name;
                row[2] = s.Added;
                row[3] = s.Deployed;
                dt.Rows.Add(row);
            }

            return dt;
        }
      
        public void AddSolution(byte[] WSP, string WSPName, Guid SolutionsGUID)
        {
            farm = SPFarm.Local;
            if (CheckSolution(SolutionsGUID) == false)
            {
                UploadWSP(WSP, WSPName);
                farm.Solutions.Add(uploadPath + WSPName);
            }
        }

        public void AddSolution(string WSPFullPath)
        {
            if(File.Exists(WSPFullPath))
            {
                farm = SPFarm.Local;
                int i = WSPFullPath.LastIndexOf(@"\");
                string solname = WSPFullPath.Substring(i + 1);
                SPSolution sol = farm.Solutions[solname];
                if (sol == null)
                {
                    farm.Solutions.Add(WSPFullPath);
                }
            }
        }

        public void RetractSolution(Guid ID)
        {
            farm = SPFarm.Local;
            SPSolution sol = farm.Solutions[ID];
            sol.Retract(DateTime.Now);
        }

        public void DeploySolution(Guid SolutionsGUID, string URL )
        {
            farm = SPFarm.Local;
            if (CheckSolution(SolutionsGUID))
            {
                SPSolution sol = farm.Solutions[SolutionsGUID];
                foreach (SPServer srv in sol.DeployedServers)
                {
                    Console.WriteLine(srv.DisplayName);
                }
            }

        }

        public void UploadWSP(byte[] WSP, string WSPName)
        {
            Stream target = File.Create(uploadPath + WSPName);

            BinaryWriter writer = new BinaryWriter(target);
            writer.Write(WSP);
            writer.Flush();
            writer.Close();
        }

        #endregion

        #region Features

        public DataTable GetActiveFeaturesTable(string SiteCollection, string Site)
        {
            DataTable result = null;
            SPWeb web = ConnectToWeb(SiteCollection, Site);

            foreach (SPFeature f in web.Features)
            {

            }

            return result;
        }

        public static List<SPFeatureDefinition> GetAllFeaturesForScope(SPFeatureScope Scope)
        {
            List<SPFeatureDefinition> result = new List<SPFeatureDefinition>();

            foreach (SPFeatureDefinition fd in SPFarm.Local.FeatureDefinitions)
            {
                if(fd.Scope == Scope){result.Add(fd);}
            }
            return result;
        }

        public static List<SPFeatureDefinition> GetFeaturesForSolution(Guid ID)
        {
            List<SPFeatureDefinition> result = new List<SPFeatureDefinition>();

            foreach (SPFeatureDefinition fd in SPFarm.Local.FeatureDefinitions)
            {
                if (fd.SolutionId == ID)
                {
                    result.Add(fd);
                }
            }
            return result;
        }

        public static List<SPWeb> GetSitesUsingFeature(Guid ID)
        {
            List<SPWeb> result = new List<SPWeb>();

            foreach (SPWeb web in GetAllWebs())
            {
                SPFeature f = web.Features[ID];
                if (f != null)
                {
                    result.Add(web);
                }
            }

            return result;
        }

        public static List<SPWeb> GetAllWebs()
        {
            List<SPWeb> result = new List<SPWeb>();

            SPWebServiceCollection ws = new SPWebServiceCollection(SPFarm.Local);

            foreach (SPWebService webservice in ws)
            {
                foreach (SPWebApplication wa in webservice.WebApplications)
                {
                    if (!wa.IsAdministrationWebApplication)
                    {
                        foreach (SPSite s in wa.Sites)
                        {
                            foreach (SPWeb w in s.AllWebs)
                            {
                                result.Add(w);
                            }
                        }
                    }
                }
            }
            return result;
        }

        public static List<SPWeb> GetSitesUsingFeatureInDependency(Guid ID)
        {
            List<SPWeb> result = new List<SPWeb>();

            foreach (SPWeb web in GetAllWebs())
            {
                //todo: change to something including hidden features
                foreach (SPFeature f in web.Features)
                {
                    foreach (SPFeatureDependency d in f.Definition.ActivationDependencies)
                    {
                        if(d.FeatureId==ID){result.Add(web);}
                    }
                }

            }

            return result;
        }
      
        #endregion
    }
}
