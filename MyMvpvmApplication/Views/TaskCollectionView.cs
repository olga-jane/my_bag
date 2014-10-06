// Developer Express Code Central Example:
// Lesson 2 - Binding Commands in the WinForms MVPVM application
// 
// Lesson 1 - Create a Simple MVPVM Application (Step-by-step description
// (https://documentation.devexpress.com/#WindowsForms/CustomDocument17300))
// (http://www.devexpress.com/scid=T127068)
// >> Lesson 2 - Commands. Presenter.
// (Step-by-step description
// (https://documentation.devexpress.com/#WindowsForms/CustomDocument17302))
// Lesson
// 3 - Interaction Between Views. Services. (Step-by-step description
// (https://documentation.devexpress.com/#WindowsForms/CustomDocument17301))
// (http://www.devexpress.com/scid=T128579)
// Lesson 4 - Navigation in MVPVM
// Applications (Step-by-step description
// (https://documentation.devexpress.com/#WindowsForms/CustomDocument17382))
// (http://www.devexpress.com/scid=T136045)
// Lesson 5 - Advanced MVPVM Application
// (Step-by-step description
// (https://documentation.devexpress.com/#WindowsForms/CustomDocument17385))
// (http://www.devexpress.com/scid=T136053)
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=T127997

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using $safeprojectname$.ViewModels;
using DevExpress.Mvvm.POCO;
using $safeprojectname$.Model;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;

namespace $safeprojectname$.Views {
    public partial class TaskCollectionView : UserControl {
        public TaskCollectionView() {
            InitializeComponent();
            viewModelCore = ViewModelSource.Create<TaskCollectionViewModel>();
            presenterCore = new TaskCollectionPresenter(gridControl1, ViewModel);
            BindCommands();
        }
        TaskCollectionViewModel viewModelCore;
        public TaskCollectionViewModel ViewModel {
            get { return viewModelCore; }
        }
        TaskCollectionPresenter presenterCore;
        public TaskCollectionPresenter Presenter {
            get { return presenterCore; }
        }
        void BindCommands() {
            biAddTask.BindCommand(() => ViewModel.AddTask(), ViewModel);
            biDeleteTask.BindCommand(() => ViewModel.DeleteTask(null), ViewModel, () => ViewModel.SelectedTask);
        }
    }

    public class TaskCollectionPresenter {
        public TaskCollectionPresenter(GridControl grid, TaskCollectionViewModel viewModel) {
            viewModelCore = viewModel;
            ((ColumnView)grid.MainView).FocusedRowObjectChanged += gridView1_FocusedRowObjectChanged;
            (grid.DataSource as BindingSource).DataSource = ViewModel.Tasks;
        }
        void gridView1_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e) {
            ViewModel.SelectedTask = e.Row as Task;
        }

        TaskCollectionViewModel viewModelCore;
        public TaskCollectionViewModel ViewModel {
            get { return viewModelCore; }
        }
    }
}
