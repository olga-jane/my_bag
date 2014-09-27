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

            comboBoxEditDemoTest.EditValue = "en-US";

            cultureNamesColl = comboBoxEditDemoTest.Properties.Items;

            cultureNamesColl.BeginUpdate();

            try
            {
                cultureNamesColl.Add(new Language("English", "en-US"));
                cultureNamesColl.Add(new Language("Françaises", "fr-FR"));
                cultureNamesColl.Add(new Language("Русский", "ru-RU"));
                cultureNamesColl.Add(new Language("中國", "zh-CH"));
            }
            finally
            {
                cultureNamesColl.EndUpdate();
            }
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
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
