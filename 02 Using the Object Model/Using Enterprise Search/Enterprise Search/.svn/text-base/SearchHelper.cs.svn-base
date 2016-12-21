using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;

using Microsoft.Office.Server.Search.Administration;
using Microsoft.Office.Server.Search.Query;
using Microsoft.SharePoint;
using Microsoft.Office.Server;

namespace Integrations
{
    class SearchHelper
    {

        private static SearchContext SetSearchContext(string SiteCollection)
        {
            SPSite col = new SPSite(SiteCollection);

            ServerContext ctxServer = ServerContext.GetContext(col);

            // set the context to the ssp
            return SearchContext.GetContext(ctxServer);
        }

        public static void CreateContentSource(string SiteCollection, string FileShare,string ContentSourceName, bool startCrawl)
        {
            // set the search context
            SearchContext ctxSearch = SetSearchContext(SiteCollection);

            // top level object for administration of search
            Content ssp = new Content(ctxSearch);

            foreach (ContentSource cs in ssp.ContentSources)
            {
                Debug.WriteLine(cs.Name);
            }

            FileShareContentSource fs = (FileShareContentSource)ssp.ContentSources.Create(typeof(FileShareContentSource), ContentSourceName);

            fs.StartAddresses.Add(new Uri(FileShare));
            fs.FollowDirectories = true;

            fs.Update();

            if(startCrawl)
            {
                fs.StartFullCrawl();
            }
        }

        public static void CreateSearchScope(string siteCollection, string ScopeName, string ScopeDesc, string CustSearchPage)
        {
            Scopes SCScopes = GetScopesForSiteCollection(siteCollection);

            foreach (Scope s in SCScopes.GetSharedScopes())
            {
                Debug.WriteLine("Scope: " + s.Name);
                Debug.WriteLine("Last time compiled: " + s.LastCompilationTime.ToShortDateString());
            }

            SCScopes.AllScopes.Create(ScopeName, ScopeDesc, null, true,
                                       CustSearchPage, ScopeCompilationType.AlwaysCompile);
        }

        public static Scopes GetScopesForSiteCollection(string siteCollection)
        {
            SearchContext sc = SetSearchContext(siteCollection);

            return new Scopes(sc);
        }

        public static void AddRulesToScopeAndCompile(string SiteCollection, string ScopeName, string FileShare)
        {
            Scopes SCScopes = GetScopesForSiteCollection(SiteCollection);

            Scope fsc = SCScopes.GetSharedScope(ScopeName);

            foreach (ScopeRule r in fsc.Rules)
            {
                Debug.WriteLine("Ruletype: " + r.RuleType);
            }

            fsc.Rules.CreateUrlRule(ScopeRuleFilterBehavior.Include, UrlScopeRuleType.Folder, FileShare);

            SCScopes.StartCompilation();
        }

        public static DataTable ExecuteQuery(string SiteCollection, string QueryString)
        {
            SPSite col = new SPSite(SiteCollection);
            ServerContext ctx = ServerContext.GetContext(col);

            FullTextSqlQuery ftq = new FullTextSqlQuery(ctx);
            ftq.ResultTypes = ResultType.RelevantResults;
            ftq.EnableStemming = true;
            ftq.TrimDuplicates = true;
            ftq.QueryText = QueryString;

            ResultTableCollection allresults = ftq.Execute();

            ResultTable relevant = allresults[ResultType.RelevantResults];

            DataTable dt = null;
            if (relevant.RowCount > 0)
            {
                dt = new DataTable("Search Result");
                dt.Columns.Add("Title");
                dt.Columns.Add("URL");
                while (relevant.Read())
                {
                    DataRow row = dt.NewRow();
                    row[0] = relevant.GetString(0);
                    row[1] = relevant.GetString(1);
                    dt.Rows.Add(row);
                }
            }

            return dt;
        
        }
    }
}