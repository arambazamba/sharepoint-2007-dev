using System;
using System.Collections.Generic;
using System.Text;
using Integrations;
using Microsoft.SharePoint;
using Microsoft.Office.Server;

namespace Integrations
{
    class Program
    {
        static void Main(string[] args)
        {
            string SiteCollection = "http://chiron";
            string ContentSourceName = "MyFileshareSource";
            string ScopeName = "MyFileShareScope";
            string ScopeDesc = "A scope representing all my file shares";
            string FileSystemPath = "file://chiron/MyFileshare";
            string ResultPage = "results.aspx";
            string SearchPhrase = "Sonne";

            SearchHelper.CreateContentSource(SiteCollection, FileSystemPath, ContentSourceName, true);

            SearchHelper.CreateSearchScope(SiteCollection, ScopeName, ScopeDesc, ResultPage);

            SearchHelper.AddRulesToScopeAndCompile(SiteCollection, ScopeName, FileSystemPath);

            string query = "Select title, url FROM Scope() where \"Scope\" = '" + ScopeName + "' AND Freetext('" + SearchPhrase + " ')";

            SearchHelper.ExecuteQuery(SiteCollection, query);
        }       
    }
}