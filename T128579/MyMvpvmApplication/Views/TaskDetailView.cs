// Developer Express Code Central Example:
// Lesson 3 - Create a WinForms MVPVM applicaiton with multiple Views
// 
// Lesson 1 - Create a Simple MVPVM Application (Step-by-step description
// (https://documentation.devexpress.com/#WindowsForms/CustomDocument17300))
// (http://www.devexpress.com/scid=T127068)
// Lesson 2 - Commands. Presenter.
// (Step-by-step description
// (https://documentation.devexpress.com/#WindowsForms/CustomDocument17302))
// (http://www.devexpress.com/scid=T127997)
// >> Lesson 3 - Interaction Between
// Views. Services. (Step-by-step description
// (https://documentation.devexpress.com/#WindowsForms/CustomDocument17301))
// Lesson
// 4 - Navigation in MVPVM Applications (Step-by-step description
// (https://documentation.devexpress.com/#WindowsForms/CustomDocument17382))
// (http://www.devexpress.com/scid=T136045)
// Lesson 5 - Advanced MVPVM Application
// (Step-by-step description
// (https://documentation.devexpress.com/#WindowsForms/CustomDocument17385))
// (http://www.devexpress.com/scid=T136053)
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=T128579

using System.Windows.Forms;
using DevExpress.Mvvm.POCO;
using MyMvpvmApplication.ViewModels;

namespace MyMvpvmApplication.Views {
    public partial class TaskDetailView : UserControl {
        public TaskDetailView() {
            InitializeComponent();
            viewModelCore = ViewModelSource.Create<TaskDetailViewModel>();
            presenterCore = new TaskPresenter(taskBindingSource, ViewModel);
            simpleButton1.BindCommand(() => ViewModel.ShowNotificaion(), ViewModel);
        }

        TaskDetailViewModel viewModelCore;
        public TaskDetailViewModel ViewModel {
            get { return viewModelCore; }
        }

        TaskPresenter presenterCore;
        public TaskPresenter Presenter {
            get { return presenterCore; }
        }
    }

    public class TaskPresenter {
        BindingSource bs;
        public TaskPresenter(BindingSource bs, TaskDetailViewModel viewModel) {
            viewModelCore = viewModel;
            this.bs = bs;
            ViewModel.TaskChanged += ViewModel_TaskChanged;
        }

        void ViewModel_TaskChanged(object sender, System.EventArgs e) {
             if (ViewModel.Task != null)
                 bs.DataSource = ViewModel.Task;
        }    
        
        TaskDetailViewModel viewModelCore;
        public TaskDetailViewModel ViewModel {
            get { return viewModelCore; }
        }
    }
}
