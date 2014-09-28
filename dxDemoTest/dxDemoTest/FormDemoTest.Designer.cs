namespace dxDemoTest
{
    partial class FormDxDemoTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxEditDemoTest = new DevExpress.XtraEditors.ComboBoxEdit();
            this.simpleButtonDemoTest = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditDemoTest.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxEditDemoTest
            // 
            this.comboBoxEditDemoTest.Location = new System.Drawing.Point(12, 12);
            this.comboBoxEditDemoTest.Name = "comboBoxEditDemoTest";
            this.comboBoxEditDemoTest.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditDemoTest.Size = new System.Drawing.Size(150, 20);
            this.comboBoxEditDemoTest.TabIndex = 0;
            this.comboBoxEditDemoTest.SelectedIndexChanged += new System.EventHandler(this.comboBoxEditDemoTest_SelectedIndexChanged);
            // 
            // simpleButtonDemoTest
            // 
            this.simpleButtonDemoTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonDemoTest.Location = new System.Drawing.Point(218, 99);
            this.simpleButtonDemoTest.Name = "simpleButtonDemoTest";
            this.simpleButtonDemoTest.Size = new System.Drawing.Size(215, 23);
            this.simpleButtonDemoTest.TabIndex = 1;
            this.simpleButtonDemoTest.Text = "Do nothing";
            // 
            // FormDxDemoTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 134);
            this.Controls.Add(this.simpleButtonDemoTest);
            this.Controls.Add(this.comboBoxEditDemoTest);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.Name = "FormDxDemoTest";
            this.Text = "Heder";
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditDemoTest.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditDemoTest;
        private DevExpress.XtraEditors.SimpleButton simpleButtonDemoTest;

    }
}

