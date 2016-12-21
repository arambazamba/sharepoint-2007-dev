using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

using System.Net;


namespace Integrations
{
    public class SPRequestJob : SPJobDefinition
    {
        public SPRequestJob() : base()
        {
        }

        public SPRequestJob(string jobName, SPService service, SPServer server, SPJobLockType targetType)
            : base(jobName, service, server, targetType)
        {
        }

        public SPRequestJob(string jobName, SPWebApplication webApplication)
            : base(jobName, webApplication, null, SPJobLockType.None)
        {
            Title = "SPRequestJob";
        }

        public override void Execute(Guid contentDBID)
        {
            SPWebApplication webApplication = (SPWebApplication) Parent;

            SPContentDatabase contentDb = webApplication.ContentDatabases[contentDBID];

            string url = contentDb.Sites[0].RootWeb.Url;

            WebRequest request = WebRequest.Create(url);

            request.Credentials = CredentialCache.DefaultCredentials;

            HttpWebResponse response = (HttpWebResponse) request.GetResponse();

        }
    }
}