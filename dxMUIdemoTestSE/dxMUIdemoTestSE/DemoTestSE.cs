using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Globalization;
using System.Resources;
using System.Threading;
using DevExpress.XtraEditors.Controls;
using System.IO;


// this atribute should be set culture as default
[assembly: NeutralResourcesLanguage("en-US")]

namespace dxMUIdemoTestSE
{
    public partial class DemoTestSE : DevExpress.XtraEditors.XtraForm
    {
        ComboBoxItemCollection cultureNamesColl;

        int count;

        readonly string strFileName = "Strings";
        readonly int cltTypeCount = 5;

        public DemoTestSE()
        {
            InitializeComponent();

            cultureNamesColl = repositoryItemComboBoxLang.Items;
            cultureNamesColl.BeginUpdate();

            try
            {
                cultureNamesColl.Add(new Language("English", "en-US"));

                // Returns the names of the subdirectories (including their paths) 
                // that match the specified search pattern in the specified 
                // directory, and optionally searches subdirectories.
                string appPath = Application.StartupPath + "\\Resources\\";
                string[] files = Directory.GetFiles(appPath, "*.??-??.resources");


                foreach (string f in files)
                {
                    // Gets the list of supported cultures filtered by the 
                    // specified CultureTypes parameter.
                    foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.InstalledWin32Cultures))
                    {
                        if (ci.Name.Length >= cltTypeCount &&
                            ci.Name.Substring(0, cltTypeCount) == 
                            f.Substring(appPath.Length + strFileName.Length + 1, cltTypeCount))
                        {
                            
                            // specify the collection of items to display in the 
                            // drop-down window (the RepositoryItemComboBox.Items 
                            // property).
                            cultureNamesColl.Add(new Language(ci.EnglishName,
                                f.Substring(appPath.Length + strFileName.Length + 1, cltTypeCount)));
                            break;
                        }
                    }
                }
            }
            finally
            {
                cultureNamesColl.EndUpdate();
            }
        }



        private void barEditItemLang_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (barEditItemLang.EditValue is Language)
                {
                    var rm = ResourceManager.CreateFileBasedResourceManager("Strings", "Resources", null);

                    string cultureName = ((Language)barEditItemLang.EditValue).LngValue;

                    CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);

                    Thread.CurrentThread.CurrentCulture = culture;
                    Thread.CurrentThread.CurrentUICulture = culture;

                    barSubItemFile.Caption = rm.GetString("MenuFile", culture);
                    barSubItemOptions.Caption = rm.GetString("MenuOptions", culture);
                    barEditItemLang.Caption = rm.GetString("ComboLang", culture);

                    barButtonItemCloseAll.Caption = rm.GetString("BtnName", culture);
                    barButtonItemAddDoc.Caption = rm.GetString("BtnName", culture);

                    this.Text = rm.GetString("TitleName", culture);
                }
                else
                {
                    barEditItemLang.EditValue = cultureNamesColl[0];
                }

            }
            catch (Exception excep)
            {
                MessageBox.Show("Unable to instantiate culture: ", excep.Message);
            }
        }

        private void DemoTestSE_Load(object sender, EventArgs e) { }

        private void barButtonItemAddDoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ++count;
            XtraFormChild child = new XtraFormChild();
            child.MdiParent = this;
            child.Text = this.Text + "-" + count;
            child.Show();
        }

        private void barButtonItemCloseAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Close();
        }
    }
}
