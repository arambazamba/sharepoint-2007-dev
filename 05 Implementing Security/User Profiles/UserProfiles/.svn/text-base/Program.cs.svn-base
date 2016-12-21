using System;
using System.Collections;
using Microsoft.Office.Server;
using Microsoft.Office.Server.Audience;
using Microsoft.Office.Server.UserProfiles;
using Microsoft.SharePoint;

namespace UserProfiles
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            SPSecurity.CatchAccessDeniedException = false;

            SPSite site = new SPSite("http://chiron");

            UserProfileManager pm = new UserProfileManager(ServerContext.GetContext(site));

            foreach (UserProfile profile in pm)
            {
                //User PropertyConstants to get values
                Console.WriteLine("Account: " + profile[PropertyConstants.AccountName]);

                //Check for null 
                if (profile[PropertyConstants.WebSite].Value != null)
                {
                    Console.WriteLine(profile[PropertyConstants.WebSite]);
                }
            }


            //ToDo: Create the AD User "class\bart" and remove the breakpoint
            Console.WriteLine("Current Number of Profiles" + pm.Count);

            if (pm.GetUserProfile(@"class\bart") != null)
            {
                pm.RemoveUserProfile(@"class\bart");
            }

            //Create Bart's Profile
            UserProfile p = pm.CreateUserProfile(@"class\bart");

            //Set it's Office to Springfield
            p[PropertyConstants.Office].Value = "Springfield";
            p.Commit();


            Console.WriteLine("Current Number of Profiles" + pm.Count);

            //Showing Audiences
            AudienceManager am = new AudienceManager(ServerContext.GetContext(site));

            foreach (Audience a in am.Audiences)
            {
                Console.WriteLine("Audience: " + a.AudienceName);
            }

            Audience simpsons;

            try
            {
                simpsons = am.Audiences.Create("Springfield Users", "All users working in Springfield");
                ArrayList audienceRules = new ArrayList();

                AudienceRuleComponent arc = new AudienceRuleComponent("Office", "Contains", "Springfield");
                audienceRules.Add(arc);
                simpsons.AudienceRules = audienceRules;
                simpsons.Commit();
            }
            catch (AudienceDuplicateNameException e)
            {
                simpsons = am.Audiences["Springfield Users"];
            }

            //Compiling Audience can only be done using the UI - sorry :)
        }
    }
}
