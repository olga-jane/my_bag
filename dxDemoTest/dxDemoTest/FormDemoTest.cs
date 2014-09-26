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

        ResourceManager rm;
        ComboBoxItemCollection cultureNamesColl;

        public FormDxDemoTest()
        {
            InitializeComponent();

            comboBoxEditDemoTest.EditValue = "en-US";

            cultureNamesColl = comboBoxEditDemoTest.Properties.Items;

            cultureNamesColl.BeginUpdate();

            try
            {
                cultureNamesColl.Add("en-US");
                cultureNamesColl.Add("fr-FR");
                cultureNamesColl.Add("ru-RU");
                cultureNamesColl.Add("zh-CH");
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
                // resource extraction
                rm = new ResourceManager("dxDemoTest.Strings", typeof(Program).Assembly);

                string cultureName = (string)cultureNamesColl[comboBoxEditDemoTest.SelectedIndex];

                CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);

                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = culture;

                this.Text = rm.GetString("TimeHeader");

                simpleButtonDemoTest.Text = rm.GetString("btnCapture");
            }
        }
    }
}
