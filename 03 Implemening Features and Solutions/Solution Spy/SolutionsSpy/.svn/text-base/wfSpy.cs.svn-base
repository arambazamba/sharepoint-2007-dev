using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Integrations;


namespace Integrations
{
    public partial class wfSpy : Form
    {
        public wfSpy()
        {
            InitializeComponent();
        }

        public Panel pContent = null;
        public Panel pNavigation = null;
        public object SourceObject = null;

        private void LoadForm(object sender, EventArgs e)
        {
            pContent= scMain.Panel2;
            pNavigation = scMain.Panel1;
            
            pNavigation.Controls.Add( new ucNavigation());
            pContent.Controls.Add( new ucFarm());
            RefreshNav();
        }

        public void RefreshNav()
        {
            ucNavigation nav = (ucNavigation)pNavigation.Controls[0];
            nav.DoLoad();
        }

    }
}