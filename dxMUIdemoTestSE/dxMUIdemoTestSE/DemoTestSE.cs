using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// this references should be added
using System.Globalization;
using System.Resources;
using System.Threading;
using DevExpress.XtraEditors.Controls;

// for finding resourses
using System.IO;

// this atribute should be set culture as default
// [assembly: NeutralResourcesLanguageAttribute("en-US")]

namespace dxMUIdemoTestSE
{
    public partial class DemoTestSE : DevExpress.XtraEditors.XtraForm
    {
        private int count;
        private LanguageManager lm;
        private TranslationManager tm;

        public TranslationManager Tm { get { return tm; } }

        public DemoTestSE()
        {
            InitializeComponent();

            this.lm = new LanguageManager(barEditItemLang, repositoryItemComboBoxLang);
         
            barListItem1.ShowChecks = true;

            this.tm = new TranslationManager(barListItem1);
        }

        private void ChangeTextLM()
        {
            barSubItemFile.Caption = lm.ChangeControlsCaption("MenuFile");

            barSubItemOptions.Caption = lm.ChangeControlsCaption("MenuOptions");

            barEditItemLang.Caption = lm.ChangeControlsCaption("ComboLang");

            barButtonItemCloseAll.Caption = lm.ChangeControlsCaption("BtnName");

            barButtonItemAddDoc.Caption = lm.ChangeControlsCaption("BtnName");

            this.Text = lm.ChangeControlsCaption("TitleName");
        }

        private void ChangeTextTM()
        {
            barSubItemFile.Caption 
                = tm.ChangeControlsCaption("barSubItemFile");

            barSubItemOptions.Caption 
                = tm.ChangeControlsCaption("barSubItemOptions");

            barEditItemLang.Caption 
                = tm.ChangeControlsCaption("barEditItemLang");

            barButtonItemCloseAll.Caption 
                = tm.ChangeControlsCaption("barButtonItemCloseAll");

            barButtonItemAddDoc.Caption 
                = tm.ChangeControlsCaption("barButtonItemAddDoc");

            this.Text
                = tm.ChangeControlsCaption("TitleName");
        }

        private void barEditItemLang_HiddenEditor(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            lm.ChangeCulture();
            ChangeTextLM();
        }
        private void barButtonItemAddDoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ++count;
            XtraFormChild child = new XtraFormChild();
            child.MdiParent = this;
            child.Text = this.Text + "-" + count + DateTime.Now.ToString();
            child.Show();
        }
        private void barButtonItemCloseAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Close();
        }
        private void barEditItemLang_EditValueChanged(object sender, EventArgs e) { }
        private void DemoTestSE_Load(object sender, EventArgs e) { }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {}
        private void barDockingMenuItem1_ListItemClick(object sender, DevExpress.XtraBars.ListItemClickEventArgs e) { }
        private void barButtonItem1_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {}
        private void barListItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tm.ChangeCulture();
            ChangeTextTM();
            
            //var crm = new ComponentResourceManager(typeof(Program));
            //foreach (Control ctl in this.Controls)
            //{
            //    try
            //    {
            //        crm.ApplyResources(ctl, ctl.Name);
            //    }
            //    catch
            //    {
            //    }
            //}
            
        }
    }
}
