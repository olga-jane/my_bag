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
using System.ComponentModel;
using System.Linq;
using System.Text;
using MyMvpvmApplication.Model;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.DataAnnotations;

namespace MyMvpvmApplication.ViewModels {
    public class TaskCollectionViewModel {
        IList<Task> tasksCore;

        public TaskCollectionViewModel() {
            tasksCore = new BindingList<Task> { 
                new Task(){ Subject="Test Task", Description = "Test Description"}
            };
        }
        public IList<Task> Tasks {
            get { return tasksCore; }
        }

        public void AddTask() {
            Tasks.Add(new Task() { Subject = "Task " + Tasks.Count.ToString() });
        }

        public virtual Task SelectedTask {
            get;
            set;
        }
        protected virtual void OnSelectedTaskChanged() {
            this.RaiseCanExecuteChanged(x => x.DeleteTask(null));
            Messenger.Default.Send(new TaskMessage() { Task = SelectedTask });
        }

        [Command(UseCommandManager = false)]
        public void DeleteTask(Task task) {
            Tasks.Remove(task);
        }
        public bool CanDeleteTask(Task task) {
            return task != null;
        }

    }
}
