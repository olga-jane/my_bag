﻿// Developer Express Code Central Example:
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
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }

