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
    public partial class ucSpeaker : UserControl
    {
        public ucSpeaker()
        {
            InitializeComponent();
            trackBarSpeaker.ValueChanged += (o, ex) => lblSpeakerValue.Text = trackBarSpeaker.Value.ToString();
        }

        public void InitAudioPanel(string devName, bool isMuteSpeaker, int speakerValue, bool isDefault)
        {
            lblTitle.Text = devName;
            trackBarSpeaker.Value = speakerValue;

            chkDefault.Checked = isDefault;

            if (isDefault)
            {
                lblTitle.ForeColor = Color.Blue;
            }
            chkSpeakerMute.Checked = isMuteSpeaker;
        }

        public string Title => lblTitle.Text;
        public bool IsDefault => chkDefault.Checked;
    }
}
