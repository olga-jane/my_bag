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
        /// counting of child windows number
        /// </summary>
        private int count;

        /// <summary>
        /// The assigned name of resourse file
        /// </summary>
        private readonly string strFileName = "Strings";

        private readonly string fldResName = "Resources";

        private readonly static string mask = "??-??";
        /// <summary>
        /// The number of characters in culture type string
        /// </summary>
        private readonly int cltTypeCount = mask.Count<char>();

        public DemoTestSE()
        {
            InitializeComponent();

            // the bottom line should be discommented to create 
            // a unique language culture with name "en-CS"
            // CreateCustomeCulture("en-CS");

            // Collection of supported languages
            cultureNamesColl = repositoryItemComboBoxLang.Items;

            cultureNamesColl.BeginUpdate();

            try
            {
                cultureNamesColl.Add(new Language("English (United States)", "en-US"));
                barEditItemLang.EditValue = cultureNamesColl[0];

                // 
                string engDispName;
                string cltrValName;

                char[] separator = { ' ', '(' };

                // Returns the names of the subdirectories (including their paths) 
                // that match the specified search pattern in the specified 
                // directory, and optionally searches subdirectories.
                string appPath = Application.StartupPath + "//" + fldResName + "//";
                string[] files = Directory.GetFiles(appPath, "*." + mask + "*.resources");

                foreach (string f in files)
                {
                    cltrValName = f.Substring(appPath.Length + strFileName.Length + 1, cltTypeCount);

                    // Gets the list of supported cultures filtered by the 
                    // specified CultureTypes parameter.
                    foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.InstalledWin32Cultures))
                    {
                        if (ci.Name.Length >= cltTypeCount &&
                            ci.Name.Substring(0, cltTypeCount) == cltrValName)
                        {
                            // forming the display name
                            engDispName = ci.EnglishName.Split(separator)[0] + " (" + 
                                          ci.NativeName.Split(separator)[0] + ")";

                            // specify the collection of items to display in the 
                            // drop-down window (the RepositoryItemComboBox.Items 
                            // property).
                            cultureNamesColl.Add(new Language(engDispName, cltrValName));
                            break;
                        }
                    }
                }
                // Australian English is used as the base of a custom 
                // language. In this case, the name of culture is 
                // preserved ("en-AU") and displayed the name changed to 
                // "English (customizable)"
                foreach (Language cnc in cultureNamesColl)
                {
                    if (cnc.LngValue == "en-AU")
                    {
                        cnc.LngName = "English (customizable)";
                    }
                }
            }
            catch ( DirectoryNotFoundException excep)
            {
                MessageBox.Show("Warning!\n" + excep.Message);
            }
            finally
            {
                cultureNamesColl.EndUpdate();
            }
        }

        #region 
        // for useing this function, you must discommented it in the constructor
        /// <summary>
        /// creation function of new language culture
        /// </summary>
        /// <param name="prmStr">the name of new language culture</param>
        private void CreateCustomeCulture(string prmStr)
        {
            // Create a CultureAndRegionInfoBuilder object named "prmStr".
            CultureAndRegionInfoBuilder cib = 
                new CultureAndRegionInfoBuilder(prmStr, CultureAndRegionModifiers.None);

            // Populate the new CultureAndRegionInfoBuilder object with culture information.
            cib.LoadDataFromCultureInfo(new CultureInfo("en-US"));

            // Populate the new CultureAndRegionInfoBuilder object with region information.
            cib.LoadDataFromRegionInfo(new RegionInfo("US"));

            // Register the culture. 
            try
            {
                // Register the custom culture.
                cib.Register(); 
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Swallow the exception: \nthe culture already is registered");
            }
        }
        #endregion

        /// <summary>
        /// The renaming controls function
        /// </summary>
        /// <param name="rm"> Resource Manager object 
        /// created for correspond resource file </param>
        /// <param name="culture"> culture </param>
        private void ChangeControlsCapture(ResourceManager rm, CultureInfo clt)
        {
            barSubItemFile.Caption =
                rm.GetString("MenuFile", clt);

            barSubItemOptions.Caption =
                rm.GetString("MenuOptions", clt);

            barEditItemLang.Caption =
                rm.GetString("ComboLang", clt);

            barButtonItemCloseAll.Caption =
                rm.GetString("BtnName", clt);

            barButtonItemAddDoc.Caption =
                rm.GetString("BtnName", clt);

            this.Text =
                rm.GetString("TitleName", clt);
        }

        private void SetCulture(CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
        }
        
        private void barEditItemLang_EditValueChanged(object sender, EventArgs e)
        {
            ResourceManager rm;

            // get store the current culture value
            CultureInfo originalCulture = Thread.CurrentThread.CurrentCulture;

            try
            {
                // In this case, we load built-in internal resources (* .resx)
                if (barEditItemLang.EditValue is Language &&
                    ((Language)barEditItemLang.EditValue).LngValue != "en-US")
                {
                    rm = ResourceManager.CreateFileBasedResourceManager("Strings", "Resources", null);
                }
                // In this case, we load external resources from the folder "Resources"  
                // are compiled separately (* .resources) 
                else
                {
                    barEditItemLang.EditValue = cultureNamesColl[0];
                    rm = new ResourceManager("dxMUIdemoTestSE.Strings", typeof(Program).Assembly);
                }

                string cultureName = ((Language)barEditItemLang.EditValue).LngValue;

                CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);

                SetCulture(culture);

                // translation of text matter on controls
                ChangeControlsCapture(rm, culture);

            }
            catch (Exception excep)
            {
                MessageBox.Show("Unable to instantiate culture: ", excep.Message);
            }
            finally
            {
                // after the change of the names we are 
                // going back to the original culture
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
