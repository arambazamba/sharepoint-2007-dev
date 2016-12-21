using System;
using System.IO;
using System.Workflow.Activities;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.SharePoint.Workflow;

namespace SequentialWF
{
    public sealed partial class SeqApprovalWF : SequentialWorkflowActivity
    {
        public SeqApprovalWF()
        {
            InitializeComponent();
        }

        // Global Variables

        private String approver = default(String);
        private String instructions = default(String);

        // On Activated

        public Guid workflowId = default(Guid);
        public SPWorkflowActivationProperties workflowProperties = new SPWorkflowActivationProperties();

        private void onWorkflowActivated(object sender, ExternalDataEventArgs e)
        {
            workflowId = workflowProperties.WorkflowId;
            XmlSerializer serializer = new XmlSerializer(typeof (InitForm));
            XmlTextReader reader = new XmlTextReader(new StringReader(workflowProperties.InitiationData));
            InitForm initform = (InitForm) serializer.Deserialize(reader);
            approver = initform.Approver;
            instructions = initform.Instructions;
        }

        // Create Task

        public Guid createTask1_TaskId1 = default(Guid);
        public SPWorkflowTaskProperties createTask1_TaskProperties1 = new SPWorkflowTaskProperties();

        private void createTask(object sender, EventArgs e)
        {
            createTask1_TaskId1 = Guid.NewGuid();
            createTask1_TaskProperties1.Title = "Approval WF Task";
            createTask1_TaskProperties1.AssignedTo = approver;
            createTask1_TaskProperties1.ExtendedProperties["Instructions"] = instructions;            
        }

        // On Task Changed

        public SPWorkflowTaskProperties beforProps = new SPWorkflowTaskProperties();
        public SPWorkflowTaskProperties afterProps = new SPWorkflowTaskProperties();
        public string wfOutcome = default(string);
        public string taskComment = default(string);

        private void onTaskChanged(object sender, ExternalDataEventArgs e)
        {
            string outcome = afterProps.ExtendedProperties["ApprovalResult"].ToString();
            wfOutcome = outcome;

            // Not used here
            taskComment = afterProps.ExtendedProperties["Comment"].ToString();
        }

        // Complete Task

        private void completeTask(object sender, EventArgs e)
        {
            completeTask1.TaskOutcome = wfOutcome;
        }
    }
}
