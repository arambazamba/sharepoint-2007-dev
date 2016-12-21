using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Navigation;

namespace Integrations
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // parameter and object definition
            string url = "http://chiron";
            uint locale = 1033;
            string siteTemplate = "STS#1"; //Blank Site Template
            string webName = "CodedWeb";

            // create site, list, set security
            SPSite col = new SPSite(url);
            ShowSiteTemplates(col, locale);
            SPWeb web = CreateSite(col, locale, siteTemplate, webName);
            ShowListTemplates(web);
            SPList list = CreateList(web);
            SetSecurityOnRessouces(web, list);
        }

        private static void ShowSiteTemplates(SPSite SiteCollection, uint Locale)
        {
            SPWeb root = SiteCollection.RootWeb;

            foreach (SPWebTemplate t in root.GetAvailableWebTemplates(Locale))
            {
                Console.WriteLine(string.Format("Template: {0}, Name {1}", t.Title, t.Name));
            }
        }

        private static SPWeb CreateSite(SPSite Col, uint locale, string template, string SiteName)
        {
            SPWeb root = Col.RootWeb;
            SPWeb web = root.Webs.Add(SiteName, SiteName, "Demo Description", locale, template, true, false);

            // add navigation
            SPNavigation navRoot = root.Navigation;
            SPNavigationNodeCollection navQL = navRoot.QuickLaunch;
            var newNav = new SPNavigationNode(web.Title, web.ServerRelativeUrl);
            navQL.Add(newNav, newNav);

            // alternative
            // web.QuickLaunchEnabled = true;

            return web;
        }

        private static void ShowListTemplates(SPWeb Web)
        {
            SPListTemplateCollection templates = Web.ListTemplates;

            foreach (SPListTemplate l in templates)
            {
                Console.WriteLine(string.Format("List: {0}, Categorie: {1}, Custom: {2}", l.Name, l.CategoryType,
                                                l.IsCustomTemplate));
            }
        }

        private static SPList CreateList(SPWeb Web)
        {
            Web.Lists.Add("My Pictures", "PersonalPictures", Web.ListTemplates["Picture Library"]);
            SPList pictureLib = Web.Lists["My Pictures"];
            pictureLib.OnQuickLaunch = true;
            return pictureLib;
        }     

        private static void SetSecurityOnRessouces(SPWeb Web, SPList List)
        {
            // list permission levels
            foreach (SPRoleDefinition PermLevel in Web.RoleDefinitions)
            {
                Console.WriteLine(string.Format("Role: {0}, ID: {1}", PermLevel.Name, PermLevel.Id));
            }

            // list groups
            foreach (SPGroup gp in Web.SiteGroups)
            {
                Console.WriteLine(string.Format("Group: {0}", gp.Name));
            }

            // break rights inheritance - boolean: copy permissions
            List.BreakRoleInheritance(false);

            // assign permissions to class\katja
            Web.SiteUsers.Add(@"class\katja", "katja@class.local", "Katja", "a test user");

            SPUser usrKatja = Web.SiteUsers[@"class\katja"]; //login name

            if (usrKatja != null)
            {
                usrKatja.Name = "Katja";
                usrKatja.Email = "katja@class.at";
                usrKatja.Update();

                // create a new permission level
                SPRoleDefinition PermLevelFull = Web.RoleDefinitions["Full Control"];

                SPRoleAssignment KatjaAssign =
                    new SPRoleAssignment(usrKatja.LoginName, usrKatja.Email, usrKatja.Name, usrKatja.Notes);

                // Bind Assignment to definition
                KatjaAssign.RoleDefinitionBindings.Add(PermLevelFull);

                List.RoleAssignments.Add(KatjaAssign);

                List.Update();
            }
        }
    }
}
