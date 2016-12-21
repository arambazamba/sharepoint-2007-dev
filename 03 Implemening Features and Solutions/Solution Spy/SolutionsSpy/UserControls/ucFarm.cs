using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Integrations;

namespace Integrations
{
    public partial class ucFarm : ucContentBase
    {
        public ucFarm()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            fdSolution.ShowDialog();
            lblWSP.Text = fdSolution.FileName;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            SPBroker broker = new SPBroker();
            broker.AddSolution(fdSolution.FileName);
            RefreshNavigation();
        }
    }
}
