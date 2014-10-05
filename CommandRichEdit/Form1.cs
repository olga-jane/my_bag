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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DevExpress.Utils.Commands;
using DevExpress.XtraRichEdit.Commands;


    public partial class Form1 : Form 
    {
        public Form1() 
        {
            InitializeComponent();

            btnUndo.Initialize(richEditControl1, RichEditCommandId.Undo);

            CommandButtonAdapter redoAdapter = new CommandButtonAdapter();

            redoAdapter.Initialize(richEditControl1, RichEditCommandId.Undo);
            redoAdapter.Button = btnRedo;
            redoAdapter.CommandId = RichEditCommandId.Redo;
            redoAdapter.RichEditControl = richEditControl1;

            CommandCheckBoxAdapter fontBoldAdapter = new CommandCheckBoxAdapter();

            fontBoldAdapter.CommandId = RichEditCommandId.ToggleFontBold;
            fontBoldAdapter.RichEditControl = richEditControl1;
            fontBoldAdapter.CheckBox = chkToggleFontBold;
        }

        private void btnToggleReadOnly_Click(object sender, EventArgs e) 
        {
            richEditControl1.ReadOnly = !richEditControl1.ReadOnly;
        }
    }
