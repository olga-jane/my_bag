using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// These references should be added
// for binding commands with control
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;

namespace DXBindCommandsMvvm
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        CmdNew commandNew;
        CmdClose commandClose;
        
        public MainForm()
        {
            InitializeComponent();

            // commands creation by ViewModelSource.Create 
            // from DevExpress.Mvvm.POCO
            commandNew = ViewModelSource.Create<CmdNew>();
            commandClose = ViewModelSource.Create<CmdClose>();

            commandNew.Form = this;
            
            // comand binding 
            BindCommands();
        }

        private void BindCommands()
        {
            // Starting from release 14.1, most DevExpress WinForms controls
            // provide the set of BindCommand methods. These methods allow you 
            // to attach commands to required UI elements and automatically track 
            // the CanExecute logic changes.

            // "New" command bind
            barButtonItemNew.BindCommand(() => commandNew.Execute(), commandNew);
            barButtonItemBarNew.BindCommand(() => commandNew.Execute(), commandNew);

            // "Close" command bind
            barButtonItemClose.BindCommand(() => commandClose.Execute(), commandClose);
            barButtonItemBarClose.BindCommand(() => commandClose.Execute(), commandClose);
        }

        // the handler to activate and deactivate buttons "Close"
        private void MainForm_MdiChildActivate(object sender, EventArgs e)
        {
            commandClose.Form = this.ActiveMdiChild;
        }
    }
}
