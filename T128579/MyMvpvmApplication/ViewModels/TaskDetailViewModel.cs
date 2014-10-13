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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using MyMvpvmApplication.Model;

namespace MyMvpvmApplication.ViewModels {
    public class TaskDetailViewModel {
        public TaskDetailViewModel() {
            Messenger.Default.Register<TaskMessage>(this, OnTaskMessage);
        }

        public virtual Task Task { get; set; }

        void OnTaskMessage(TaskMessage message) {
            Task = message.Task;
        }

        public event EventHandler TaskChanged;

        protected virtual void OnTaskChanged() {
            if (TaskChanged != null)
                TaskChanged(this, EventArgs.Empty);
        }

        [ServiceProperty]
        public virtual IMyNotificationService MyNotificationService {
            get { throw new NotImplementedException(); }
        }

        public void ShowNotificaion() {
            MyNotificationService.Notify(Task.Subject);
        }
    }

    
}
