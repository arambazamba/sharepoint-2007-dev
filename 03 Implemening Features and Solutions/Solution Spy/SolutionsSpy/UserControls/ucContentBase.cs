using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Integrations
{
    public partial class ucContentBase : UserControl
    {
        public ucContentBase()
        {
            InitializeComponent();
        }

        public ScopeLevel SL;
        protected wfSpy parent = null;
        protected object SourceObject = null;

        private void ucContentBase_Load(object sender, EventArgs e)
        {
            if(ParentForm!=null)
            {
                parent = (wfSpy)ParentForm;
                SourceObject = parent.SourceObject;                
            }
        }        

        protected void RefreshNavigation()
        {            
            parent.RefreshNav();
        }


    }
}
