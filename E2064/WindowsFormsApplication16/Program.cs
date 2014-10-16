// Developer Express Code Central Example:
// How to show a TreeList at the grid's detail level
// 
// This example demonstrates how to embed the TreeList control into the grid
// control, and show it within a detail level
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E2064

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApplication16
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
