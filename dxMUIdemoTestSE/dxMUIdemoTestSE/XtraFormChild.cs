using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace dxMUIdemoTestSE
{
    public partial class XtraFormChild : DevExpress.XtraEditors.XtraForm
    {
        public XtraFormChild()
        {
            InitializeComponent();
        }

        private void ChangeControlsCaptureTM()
        {
            //barSubItemFile.Caption = this.Parent.tm.ChangeControlsCaption("MenuFile");
        }
    }
}