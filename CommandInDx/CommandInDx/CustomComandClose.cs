using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// for atribute "Command"
using DevExpress.Mvvm.DataAnnotations;

// for method RaiseCanExecuteChanged
using DevExpress.Mvvm.POCO;


namespace CommandInDx
{
    // this class must be public!
    public class CustomComandClose
    {

        [Command(UseCommandManager = false)]
        public void Execute()
        {
            Form.Close();
        }

        public virtual Form Form { get; set; }

        protected virtual void OnFormChanged()
        {
            this.RaiseCanExecuteChanged(x => x.Execute());
        }

        public bool CanExecute()
        {
            return Form != null;
        }
    }
}
