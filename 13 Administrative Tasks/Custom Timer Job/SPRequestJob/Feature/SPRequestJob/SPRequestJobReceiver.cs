using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

namespace Integrations
{
    class SPRequestJobReceiver : SPFeatureReceiver 
    {
        const string SPRequestJobName = "SPRequestJob";

        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            SPSite site = properties.Feature.Parent as SPSite;

            // make sure the job isn't already registered

            if (site != null)
            {
                foreach (SPJobDefinition job in site.WebApplication.JobDefinitions)
                {
                    if (job.Name == SPRequestJobName) job.Delete();
                }

                // install the job

                SPRequestJob requestJob = new SPRequestJob(SPRequestJobName, site.WebApplication);

                SPMinuteSchedule schedule = new SPMinuteSchedule();

                schedule.BeginSecond = 0;

                schedule.EndSecond = 59;

                schedule.Interval = 20;

                requestJob.Schedule = schedule;

                requestJob.Update();
            }
        }

        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            SPSite site = properties.Feature.Parent as SPSite;

            // delete the job

            if (site != null)
                foreach (SPJobDefinition job in site.WebApplication.JobDefinitions)
                {
                    if (job.Name == SPRequestJobName)

                        job.Delete();
                }
        }

        public override void FeatureInstalled(SPFeatureReceiverProperties properties)
        {

        }

        public override void FeatureUninstalling(SPFeatureReceiverProperties properties)
        {

        }
    }
}
