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
[assembly: NeutralResourcesLanguageAttribute("en-US")]

namespace dxMUIdemoTestSE
{
    public partial class DemoTestSE : DevExpress.XtraEditors.XtraForm
    {
        ComboBoxItemCollection cultureNamesColl;

        /// <summary>
        /// counting of chil windows number
        /// </summary>
        private int count;

        /// <summary>
        /// The assigned name of resourse file
        /// </summary>
        private readonly string strFileName = "Strings";

        /// <summary>
        /// The number of characters in culture type string
        /// </summary>
        private readonly int cltTypeCount = 5;

        public DemoTestSE()
        {
            InitializeComponent();

            // Collection of supported languages
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
            catch (Exception excep)
            {
                MessageBox.Show("Warning!\n" + excep.Message);
            }
            finally
            {
                cultureNamesColl.EndUpdate();
            }
        }

        /// <summary>
        /// The renaming controls function
        /// </summary>
        /// <param name="rm"> Resource Manager object created for correspond resource file </param>
        /// <param name="culture"> culture </param>
        private void ChangeControlsCapture(ResourceManager rm, CultureInfo culture)
        {
            barSubItemFile.Caption =        rm.GetString("MenuFile", culture);
            barSubItemOptions.Caption =     rm.GetString("MenuOptions", culture);
            barEditItemLang.Caption =       rm.GetString("ComboLang", culture);
            barButtonItemCloseAll.Caption = rm.GetString("BtnName", culture);
            barButtonItemAddDoc.Caption =   rm.GetString("BtnName", culture);
            this.Text =                     rm.GetString("TitleName", culture);
        }

        private void SetCulture(CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
        }


        private void barEditItemLang_EditValueChanged(object sender, EventArgs e)
        {
            ResourceManager rm;

            // get store current culture value
            CultureInfo originalCulture = Thread.CurrentThread.CurrentCulture;

            try
            {
                if (barEditItemLang.EditValue is Language &&
                    ((Language)barEditItemLang.EditValue).LngValue != "en-US")
                {
                    rm = ResourceManager.CreateFileBasedResourceManager("Strings", "Resources", null);
                }
                else
                {
                    barEditItemLang.EditValue = cultureNamesColl[0];
                    rm = new ResourceManager("dxMUIdemoTestSE.Strings", typeof(Program).Assembly);
                }

                string cultureName = ((Language)barEditItemLang.EditValue).LngValue;

                CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);

                SetCulture(culture);

                // renaming
                ChangeControlsCapture(rm, culture);
            }
            catch (Exception excep)
            {
                MessageBox.Show("Unable to instantiate culture: ", excep.Message);
            }
            finally
            {
                SetCulture(originalCulture);
            }
        }


        private void DemoTestSE_Load(object sender, EventArgs e) { }



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
    }
}
