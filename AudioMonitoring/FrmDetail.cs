using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioMonitoring
{
    public partial class FrmDetail : Form
    {
        public FrmDetail()
        {
            InitializeComponent();
        }

        public string DetailText { get; set; }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            txtDetail.Text = DetailText;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
