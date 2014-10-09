using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// for attribute "Command"
using DevExpress.Mvvm.DataAnnotations;

// for method RaiseCanExecuteChanged
using DevExpress.Mvvm.POCO;

namespace DXBindCommandsMvvm
{
    // class "Command" must be public
    public class CmdClose: ICommand
    {
        // this property is used for an 
        // implicit method invocation "CanExecute"
        public virtual Form Form { get; set; }

        // In WindowsForms, we need to disable the CommandManager 
        // within the Command attribute and specify the button's 
        // availability manually. To do so, we handle the On[Form]Changed event. 
        // The RaiseCanExecuteChanged method is provided by DevExpress.MVVM.POCO 
        // namespace and is available, since we created the Command via 
        // the ViewModelSource.Create method.
        [Command(UseCommandManager = false)]
        public void Execute()
        {
            Form.Close();
        }

        // The name of this method have 
        // form: On[public virtual fild name]Changed
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
