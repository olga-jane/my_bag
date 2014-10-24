// Developer Express Code Central Example:
// How to show a TreeList at the grid's detail level
// 
// This example demonstrates how to embed the TreeList control into the grid
// control, and show it within a detail level
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E2064

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;


using DevExpress.XtraTreeList.Nodes;

namespace WindowsFormsApplication16
{
    public partial class Form1 : Form
    {
        BindingList<ChildObject> fakeList = new BindingList<ChildObject>();

        public Form1()
        {
            InitializeComponent();
            
            for (int i = 0; i < 5; i++)
            {
                fakeList.Add(new ChildObject());
            }

        }

        private void UpdateTreeListData(Parent parent)
        {
            tree.BeginUnboundLoad();
            try
            {
                for (int j = 0; j < 5; j++)
                {
                    TreeListNode node = tree.AppendNode(new object[] { 
                                       "Foo" + j.ToString(), 
                                       "Bar" + j.ToString() }, 
                                       null);
                }
            }
            finally {
                tree.EndUnboundLoad();
            }
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
            bindingSource1.Add(new Parent("Parent1"));
            bindingSource1.Add(new Parent("Parent2"));
            bindingSource1.Add(new Parent("Parent3"));
            bindingSource1.Add(new Parent("Parent4"));
            gridControl1.Controls.Add(tree);
            tree.Visible = false;
        }

        
        private void gridView1_MasterRowGetChildList(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs e)
        {
            e.ChildList = fakeList;
            Parent parent = (sender as GridView).GetRow(e.RowHandle) as Parent;
            UpdateTreeListData(parent);
        }

        private void UpdateTreeVisibility(GridView view)
        {
            if (view == null)
                return;
            tree.SetBounds(view.ViewRect.X, view.ViewRect.Y, view.ViewRect.Width, view.ViewRect.Height);
            tree.Tag = view;
            tree.Visible = true;
        }

        private void gridView1_MasterRowExpanded(object sender, DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs e)
        {
            GridView view = gridView1.GetDetailView(e.RowHandle, e.RelationIndex) as GridView;
            UpdateTreeVisibility(view);
        }
        
        private void gridView1_TopRowChanged(object sender, EventArgs e)
        {
            BeginInvoke(new MethodInvoker(delegate
            {
                GridView view = tree.Tag as GridView;
                if (tree.Visible)
                    UpdateTreeVisibility(view);
            }));

        }
        
        private void gridView1_MasterRowCollapsing(object sender, MasterRowCanExpandEventArgs e)
        {
            tree.Tag = null;
            tree.Visible = false;
        }
        
        
        private void gridView2_Layout(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            UpdateTreeVisibility(view);
        }

        
        private void gridControl1_SizeChanged(object sender, EventArgs e)
        {
            GridView view = tree.Tag as GridView;
            if (tree.Visible)
                UpdateTreeVisibility(view);
        } 
        
    }


    public class Parent
    {

        public Parent(string name)
        {
            this._Name = name;
        }
        

        public Parent()
        {
            
        }

        private int _ID;
        public int ID
        {
            get { return _ID; }
            set
            {
                _ID = value;
            }
        }

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
            }
        }

        private BindingList<ChildObject> _FakeCollection = new BindingList<ChildObject>();
        public BindingList<ChildObject> FakeCollection
        {
            get { return _FakeCollection; }
        }
       
    }

    public class ChildObject
    {
        
        public ChildObject()
        {
            
        }

        private string _Foo;
        public string Foo
        {
            get { return _Foo; }
            set
            {
                _Foo = value;
            }
        }

        private string _Bar;
        public string Bar
        {
            get { return _Bar; }
            set
            {
                _Bar = value;
            }
        }
    }
}
