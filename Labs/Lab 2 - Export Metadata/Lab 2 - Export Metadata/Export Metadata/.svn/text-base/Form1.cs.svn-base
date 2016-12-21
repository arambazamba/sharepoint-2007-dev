using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Microsoft.SharePoint;
using Integrations;
using System.IO;

namespace SharePoint_Hierachie
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SPList CurrentList = null;

        private void button1_Click(object sender, EventArgs e)
        {
            tvStructure.Nodes.Clear();
            SPSite col = new SPSite(txtURL.Text);
            SPWeb tls = col.RootWeb;
            TreeNode rootNode = new TreeNode(tls.Title,0,0);
            rootNode.Tag = tls;
            tvStructure.Nodes.Add(rootNode);
            AddChilds(tls, rootNode);
            AddLists(tls, rootNode);
            tvStructure.ExpandAll();
        }

        private void AddChilds(SPWeb web, TreeNode parent) 
        {
            TreeNode child = null;
            foreach (SPWeb w in web.Webs)
            {
                child = new TreeNode(w.Title, 0, 0);
                child.Tag = w;
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
                listnode.Tag = list;
                parent.Nodes.Add(listnode);   
            }
        }

        private void NodeSelected(object sender, TreeViewEventArgs e)
        {
            lbItems.Items.Clear();
            TreeNode current = e.Node;
            Type t = current.Tag.GetType();
            if (t == typeof(SPDocumentLibrary) | t == typeof(SPList))
            {
                SPList list = (SPList)current.Tag;
                CurrentList = list;
                foreach (SPListItem item in list.Items)
                {
                    ControlHelper ch = new ControlHelper(item.Name, item.UniqueId);
                    lbItems.Items.Add(ch);
                }
            }
        }

        private void ExportMetadata(object sender, EventArgs e)
        {
            ControlHelper ch = (ControlHelper)lbItems.SelectedItem;

            SPListItem item = CurrentList.GetItemByUniqueId(ch.UniqueID);
            string filename = item.Name.Substring(0, item.Name.LastIndexOf("."));
            string path = @"d:\" + filename + ".txt";
            FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(file);
            sw.WriteLine("Metadata for: " + item.Name);
            sw.WriteLine("-----------");               
   

            foreach (SPField fld in item.Fields)
            {
                object value = null;

                if (item[fld.Title] == null)
                {
                    value = "Not Set";
                }
                else
                {
                    value = item[fld.Title];
                }         
                sw.WriteLine("Feld: " + fld.Title);
                sw.WriteLine("Wert: " + value.ToString());
            }
            sw.Close();
            MessageBox.Show("Metadata written");
        }
      }
}