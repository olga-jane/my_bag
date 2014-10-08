using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;

namespace CommandInDx
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        CustomCommandAdd custCommCore;
        CustomComandClose custCommCoreCl;

        public Form1()
        {
            InitializeComponent();

            // commands creation by ViewModelSource.Create from DevExpress.Mvvm.POCO
            custCommCore = ViewModelSource.Create<CustomCommandAdd>();
            custCommCoreCl = ViewModelSource.Create<CustomComandClose>();

            custCommCore.Parent = this;

            BindCommands();
        }
        
        // comand binding  
        private void BindCommands()
        {
            barButtonItem3.BindCommand(() => custCommCore.Execute(), custCommCore);
            barButtonItem2.BindCommand(() => custCommCore.Execute(), custCommCore);
            barButtonItem4.BindCommand(() => custCommCoreCl.Execute(), custCommCoreCl);
            barButtonItem5.BindCommand(() => custCommCoreCl.Execute(), custCommCoreCl);
        }

        private void Form1_MdiChildActivate(object sender, EventArgs e)
        {
            custCommCoreCl.Form = this.ActiveMdiChild;
        }
    }
}
