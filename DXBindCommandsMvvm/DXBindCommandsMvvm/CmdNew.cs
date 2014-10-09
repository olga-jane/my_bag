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

namespace DXBindCommandsMvvm
{
    // class "Command" must be public
    public class CmdNew: ICommand
    {
        // this property is used for an 
        // implicit method invocation "CanExecute"
        public Form Form { get;  set; }

        // In WindowsForms, we need to disable the CommandManager 
        // within the Command attribute and specify the button's 
        // availability manually. To do so, we handle the On[Form]Changed event. 
        // The RaiseCanExecuteChanged method is provided by DevExpress.MVVM.POCO 
        // namespace and is available, since we created the Command via 
        // the ViewModelSource.Create method.
        [Command(UseCommandManager = false)]
        public void Execute()
        {
            ChildForm childForm = new ChildForm();
            childForm.MdiParent = Form;
            childForm.Show();
        }

        // The name of this method have 
        // form: On[public virtual fild name]Changed
        protected virtual void OnFormChanged()
        {
            this.RaiseCanExecuteChanged(x => x.Execute());
        }

        public bool CanExecute()
        {
            return true;
        }
    }
}
