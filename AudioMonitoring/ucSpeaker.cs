using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.CoreAudioApi;

namespace AudioMonitoring
{
    public partial class ucSpeaker : UserControl
    {
        private MMDeviceEnumerator DevEnum = new MMDeviceEnumerator();
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

        private void chkSpeakerMute_CheckedChanged(object sender, EventArgs e)
        {
            foreach (MMDevice deviceRender in DevEnum.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active))
            {
                if(deviceRender.FriendlyName == Title)
                {
                    deviceRender.AudioEndpointVolume.Mute = chkSpeakerMute.Checked;
                }
            }
        }

        private void trackBarSpeaker_ValueChanged(object sender, EventArgs e)
        {
            foreach (MMDevice deviceRender in DevEnum.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active))
            {
                if (deviceRender.FriendlyName == Title)
                {
                    deviceRender.AudioEndpointVolume.MasterVolumeLevelScalar = 1.0f * trackBarSpeaker.Value / 100;
                }
            }
        }
    }
}
