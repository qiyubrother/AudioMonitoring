using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioMonitoring
{
    public partial class ucMicroPhone : UserControl
    {
        public ucMicroPhone()
        {
            InitializeComponent();
            trackBarMicrophone.ValueChanged += (o, ex) => lblMicrophoneValue.Text = trackBarMicrophone.Value.ToString();

        }
        public void InitAudioPanel(string devName, bool isMuteMicphone, int microphoneValue, bool isDefault)
        {
            lblTitle.Text = devName;
            trackBarMicrophone.Value = microphoneValue;

            chkDefault.Checked = isDefault;

            if (isDefault)
            {
                lblTitle.ForeColor = Color.Blue;
            }
            chkMicrophoneMute.Checked = isMuteMicphone;
        }

        public string Title => lblTitle.Text;
        public bool IsDefault => chkDefault.Checked;
    }
}
