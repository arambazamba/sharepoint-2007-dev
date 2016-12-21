using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Microsoft.SharePoint;

namespace SharePoint_Hierachie
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tvStructure.Nodes.Clear();
            SPSite col = new SPSite(txtURL.Text);
            SPWeb root = col.RootWeb;
            TreeNode rootNode = new TreeNode(root.Title,0,0);
            tvStructure.Nodes.Add(rootNode);
            AddChilds(root, rootNode);
            AddLists(root, rootNode);
            tvStructure.ExpandAll();
        }

        private void AddChilds(SPWeb web, TreeNode parent) 
        {
            TreeNode child = null;
            foreach (SPWeb w in web.Webs)
            {
                child = new TreeNode(w.Title, 0, 0);
                parent.Nodes.Add(child);
                AddChilds(w, child);
                AddLists(w, child);
            }
        }

        private void AddLists(SPWeb web, TreeNode parent)
        {
            TreeNode listnode = null;
            foreach (SPList list in web.Lists)
            {
                listnode = new TreeNode(list.Title, 1, 1);
                parent.Nodes.Add(listnode);   
            }
        }

        private void txtURL_TextChanged(object sender, EventArgs e)
        {

        }
    }
}