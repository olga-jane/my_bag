using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

using DevExpress.Mvvm;

// for atribute "Command"
using DevExpress.Mvvm.DataAnnotations;

using DevExpress.Mvvm.POCO;


namespace CommandInDx
{
    // this class must be public!
    public class CustomComandClose
    {

        [Command(UseCommandManager = false)]
        public void Execute(Form form)
        {
            form.Close();

            MessageBox.Show(form.ToString());
        }

        public virtual Form form { get; set; }

        protected virtual void OnSelectedFormChanged()
        {
            this.RaiseCanExecuteChanged(x => x.Execute(null));
        }

        public bool CanExecute(Form form)
        {
            return form != null;
        }
    }
}
