using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

// for atribute "Command"
using DevExpress.Mvvm.DataAnnotations;

using DevExpress.Mvvm.POCO;

namespace CommandInDx
{
    public class CustomCommandAdd
    {
        Form parent;
        public Form Parent { set { parent = value; } }

        [Command(UseCommandManager = false)]
        public void Execute()
        {
            XtraForm1 childForm = new XtraForm1();
            childForm.MdiParent = parent;
            childForm.Show();
        }

        protected virtual void OnParentChanged()
        {
            this.RaiseCanExecuteChanged(x => x.Execute());
        }

        public bool CanExecute()
        {
            return true;
        }
    }
}
