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

// finde resourses
using System.IO;

// this atribute should be set culture as default
[assembly: NeutralResourcesLanguageAttribute("en-US")]

namespace dxDemoTest
{
    public partial class FormDxDemoTest : DevExpress.XtraEditors.XtraForm
    {

        ComboBoxItemCollection cultureNamesColl;
        CultureInfo originalCulture = Thread.CurrentThread.CurrentCulture;

        public FormDxDemoTest()
        {
            InitializeComponent();

            cultureNamesColl = comboBoxEditDemoTest.Properties.Items;

            cultureNamesColl.BeginUpdate();

            try
            {
                cultureNamesColl.Add(new Language("English", "en-US"));

                // Returns the names of the subdirectories (including their paths) 
                // that match the specified search pattern in the specified 
                // directory, and optionally searches subdirectories.
                string appPath = Application.StartupPath;
                string[] dirs = Directory.GetDirectories(appPath, "*??-??");

                foreach (string d in dirs)
                {
                    // Gets the list of supported cultures filtered by the 
                    // specified CultureTypes parameter.
                    foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.InstalledWin32Cultures))
                    {
                        if (ci.Name.Length >= 2 &&
                            ci.Name.Substring(0, 2) == d.Substring(appPath.Length + 1, 2))
                        {
                            // specify the collection of items to display in the 
                            // drop-down window (the RepositoryItemComboBox.Items 
                            // property).
                            cultureNamesColl.Add(new Language(ci.EnglishName, d.Substring(appPath.Length + 1)));
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


        private void comboBoxEditDemoTest_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxEditDemoTest.SelectedIndex >= 0 &&
               comboBoxEditDemoTest.SelectedIndex < cultureNamesColl.Count)
            {
                try
                {
                    // resource extraction
                    var rm = new ResourceManager("dxDemoTest.Strings", typeof(Program).Assembly);

                    string cultureName = ((Language)cultureNamesColl[comboBoxEditDemoTest.SelectedIndex]).LngValue;

                    CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);

                    Thread.CurrentThread.CurrentCulture = culture;
                    Thread.CurrentThread.CurrentUICulture = culture;

                    this.Text = rm.GetString("TimeHeader");

                    simpleButtonDemoTest.Text = rm.GetString("btnCapture");

                }
                catch (Exception exc)
                {
                    MessageBox.Show("Unable to instantiate culture " + exc.Message);
                }
                finally
                {
                    Thread.CurrentThread.CurrentCulture = originalCulture;
                    Thread.CurrentThread.CurrentUICulture = originalCulture;
                }
            }
        }
    }
}
