// Developer Express Code Central Example:
// Commands in the XtraRichEdit Suite - How to bind commands to buttons, check boxes and other UI elements
// 
// This project illustrates how to bind an XtraRichEdit command to the UI element.
// A DevExpress.XtraEditors.SimpleButton
// (http://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraEditorsSimpleButtontopic)
// button is bound to Undo command
// (http://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraRichEditCommandsUndoCommandtopic)
// via creating a command-enabled descendant. Another SimpleButton is bound to Redo
// command
// (http://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraRichEditCommandsRedoCommandtopic)
// via the Command Adapter technique. A CheckEdit
// (http://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraEditorsCheckEdittopic)
// is bound to the ToggleFontBold command
// (http://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraRichEditCommandsToggleFontBoldCommandtopic).
// Once implemented in the application, the command UI elements properly respond to
// changes in the XtraRichEdit control. This behavior is illustrated by an example,
// in which the command buttons correctly reflect changes in Undo and Redo command
// state. Moreover, all command elements are automatically grayed out and disabled
// when the RichEditControl becomes read-only.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E1774

using System;
using System.Collections.Generic;
using System.Windows.Forms;


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
