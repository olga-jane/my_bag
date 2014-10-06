using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Timers;

using CommandManagement;

namespace CommandManagerTest
{

    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class frmTest : System.Windows.Forms.Form
    {
        private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.ImageList imgCommands;

		private System.Windows.Forms.ToolBarButton btnOpen;
		private System.Windows.Forms.ToolBarButton btnSave;
		private System.Windows.Forms.ToolBarButton sep1;
		private System.Windows.Forms.ToolBarButton btnCopy;
		private System.Windows.Forms.ToolBarButton btnPrint;

		private System.Windows.Forms.MenuItem mnuFile;
		private System.Windows.Forms.MenuItem mnuOpen;
		private System.Windows.Forms.MenuItem mnuSave;
		private System.Windows.Forms.MenuItem mnuExit;
		private System.Windows.Forms.MenuItem mnuEdit;
		private System.Windows.Forms.MenuItem mnuEditCopy;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem mnuPrint;

		private System.Windows.Forms.ToolBar tlbMain;

		private CommandManagement.CommandManager cmdMgr;

		private System.Windows.Forms.RichTextBox txtEditor;

		private System.Windows.Forms.ToolBarButton sep2;
		private System.Windows.Forms.ToolBarButton btnBold;

		private System.Windows.Forms.MenuItem mnuFormat;
		private System.Windows.Forms.MenuItem mnuBold;

        private System.ComponentModel.IContainer components = null;

        public frmTest()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
			InitializeCommandManager();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                if (components != null) 
                {
                    components.Dispose();
                }
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTest));
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.mnuFile = new System.Windows.Forms.MenuItem();
            this.mnuOpen = new System.Windows.Forms.MenuItem();
            this.mnuSave = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.mnuPrint = new System.Windows.Forms.MenuItem();
            this.mnuExit = new System.Windows.Forms.MenuItem();
            this.mnuEdit = new System.Windows.Forms.MenuItem();
            this.mnuEditCopy = new System.Windows.Forms.MenuItem();
            this.mnuFormat = new System.Windows.Forms.MenuItem();
            this.mnuBold = new System.Windows.Forms.MenuItem();
            this.imgCommands = new System.Windows.Forms.ImageList(this.components);
            this.tlbMain = new System.Windows.Forms.ToolBar();
            this.btnOpen = new System.Windows.Forms.ToolBarButton();
            this.btnSave = new System.Windows.Forms.ToolBarButton();
            this.btnPrint = new System.Windows.Forms.ToolBarButton();
            this.sep1 = new System.Windows.Forms.ToolBarButton();
            this.btnCopy = new System.Windows.Forms.ToolBarButton();
            this.sep2 = new System.Windows.Forms.ToolBarButton();
            this.btnBold = new System.Windows.Forms.ToolBarButton();
            this.cmdMgr = new CommandManagement.CommandManager();
            this.txtEditor = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuFile,
            this.mnuEdit,
            this.mnuFormat});
            // 
            // mnuFile
            // 
            this.mnuFile.Index = 0;
            this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuOpen,
            this.mnuSave,
            this.menuItem5,
            this.mnuPrint,
            this.mnuExit});
            this.mnuFile.Text = "&File";
            // 
            // mnuOpen
            // 
            this.mnuOpen.Index = 0;
            this.mnuOpen.Text = "&Open";
            // 
            // mnuSave
            // 
            this.mnuSave.Index = 1;
            this.mnuSave.Text = "&Save";
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 2;
            this.menuItem5.Text = "-";
            // 
            // mnuPrint
            // 
            this.mnuPrint.Index = 3;
            this.mnuPrint.Text = "&Print";
            // 
            // mnuExit
            // 
            this.mnuExit.Index = 4;
            this.mnuExit.Text = "E&xit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // mnuEdit
            // 
            this.mnuEdit.Index = 1;
            this.mnuEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuEditCopy});
            this.mnuEdit.Text = "&Edit";
            // 
            // mnuEditCopy
            // 
            this.mnuEditCopy.Index = 0;
            this.mnuEditCopy.Text = "&Copy";
            // 
            // mnuFormat
            // 
            this.mnuFormat.Index = 2;
            this.mnuFormat.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuBold});
            this.mnuFormat.Text = "&Format";
            // 
            // mnuBold
            // 
            this.mnuBold.Index = 0;
            this.mnuBold.Text = "&Bold";
            // 
            // imgCommands
            // 
            this.imgCommands.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgCommands.ImageStream")));
            this.imgCommands.TransparentColor = System.Drawing.Color.Silver;
            this.imgCommands.Images.SetKeyName(0, "");
            this.imgCommands.Images.SetKeyName(1, "");
            this.imgCommands.Images.SetKeyName(2, "");
            this.imgCommands.Images.SetKeyName(3, "");
            this.imgCommands.Images.SetKeyName(4, "");
            // 
            // tlbMain
            // 
            this.tlbMain.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.tlbMain.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.btnOpen,
            this.btnSave,
            this.btnPrint,
            this.sep1,
            this.btnCopy,
            this.sep2,
            this.btnBold});
            this.tlbMain.ButtonSize = new System.Drawing.Size(24, 24);
            this.tlbMain.DropDownArrows = true;
            this.tlbMain.ImageList = this.imgCommands;
            this.tlbMain.Location = new System.Drawing.Point(0, 0);
            this.tlbMain.Name = "tlbMain";
            this.tlbMain.ShowToolTips = true;
            this.tlbMain.Size = new System.Drawing.Size(360, 30);
            this.tlbMain.TabIndex = 2;
            // 
            // btnOpen
            // 
            this.btnOpen.ImageIndex = 0;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Tag = "cmdOpen";
            // 
            // btnSave
            // 
            this.btnSave.ImageIndex = 1;
            this.btnSave.Name = "btnSave";
            this.btnSave.Tag = "cmdSave";
            // 
            // btnPrint
            // 
            this.btnPrint.ImageIndex = 3;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Tag = "cmdPrint";
            // 
            // sep1
            // 
            this.sep1.Name = "sep1";
            this.sep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // btnCopy
            // 
            this.btnCopy.ImageIndex = 2;
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Tag = "cmdCopy";
            // 
            // sep2
            // 
            this.sep2.Name = "sep2";
            this.sep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // btnBold
            // 
            this.btnBold.ImageIndex = 4;
            this.btnBold.Name = "btnBold";
            this.btnBold.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
            // 
            // txtEditor
            // 
            this.txtEditor.Location = new System.Drawing.Point(8, 48);
            this.txtEditor.Name = "txtEditor";
            this.txtEditor.Size = new System.Drawing.Size(344, 184);
            this.txtEditor.TabIndex = 3;
            this.txtEditor.Text = "";
            // 
            // frmTest
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(360, 249);
            this.Controls.Add(this.txtEditor);
            this.Controls.Add(this.tlbMain);
            this.Menu = this.mainMenu1;
            this.Name = "frmTest";
            this.Text = "Command Manager Test";
            this.Load += new System.EventHandler(this.frmTest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


		private void InitializeCommandManager()
		{
            // Create Command Manager
            cmdMgr = new CommandManager();

            // Add All Commands
            cmdMgr.Commands.Add( new Command(    
                "FileOpen", 
                new Command.ExecuteHandler(CommandHandler), null));

            cmdMgr.Commands.Add( new Command(    
                "FileSave", 
                new Command.ExecuteHandler(CommandHandler), null));

            cmdMgr.Commands.Add( new Command(
                "FilePrint", 
                new Command.ExecuteHandler(CommandHandler), null));

            cmdMgr.Commands.Add( new Command(
                "EditCopy", 
                new Command.ExecuteHandler(OnCopy), 
                new Command.UpdateHandler(UpdateCopyCommand)));

            cmdMgr.Commands.Add( new Command(
                "FormatBold", 
                new Command.ExecuteHandler(OnBold), 
                new Command.UpdateHandler(UpdateBoldCommand)));

            // Associate UI Instances with commands
			cmdMgr.Commands["FileOpen"].CommandInstances.Add(
                new Object[]{mnuOpen, tlbMain.Buttons[0]});

            cmdMgr.Commands["FileSave"].CommandInstances.Add(
                new Object[]{mnuSave, tlbMain.Buttons[1]});

            cmdMgr.Commands["FilePrint"].CommandInstances.Add(
                new Object[]{mnuPrint, tlbMain.Buttons[2]});

            cmdMgr.Commands["EditCopy"].CommandInstances.Add(
                new Object[]{mnuEditCopy, tlbMain.Buttons[4]});

            cmdMgr.Commands["FormatBold"].CommandInstances.Add(
                new Object[]{mnuBold, tlbMain.Buttons[6]});
		}


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() 
        {
            Application.Run(new frmTest());
        }

		///////////////////////////////////////////////////
		// Event Handlers

        public void CommandHandler(Command cmd)
        {
            System.Windows.Forms.MessageBox.Show(cmd.Tag, "Command Executed");
        }

        public void UpdateCopyCommand(Command cmd)
        {
            cmd.Enabled = txtEditor.SelectedText.Length > 0;
        }

		public void UpdateBoldCommand(Command cmd)
		{
			cmd.Checked = txtEditor.SelectionFont.Bold;
		}

		public void OnCopy(Command cmd)
		{
			Clipboard.SetDataObject(txtEditor.SelectedText);
		}

		public void OnBold(Command cmd)
		{
			if (txtEditor.SelectionFont != null)
			{
				System.Drawing.Font currentFont = txtEditor.SelectionFont;
				System.Drawing.FontStyle newFontStyle;

				if (txtEditor.SelectionFont.Bold == true)
				{
					newFontStyle = FontStyle.Regular;
				}
				else
				{
					newFontStyle = FontStyle.Bold;
				}

				txtEditor.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
			}
		}

		private void mnuExit_Click(object sender, System.EventArgs e)
		{
            this.Close();
		}

        private void frmTest_Load(object sender, EventArgs e)
        {

        }
    }
}
