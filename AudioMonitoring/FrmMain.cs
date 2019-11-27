using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.CoreAudioApi;

namespace AudioMonitoring
{
    public partial class FrmMain : Form
    {
        //private MMDevice device;
        private MMDeviceEnumerator DevEnum = new MMDeviceEnumerator();
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void UpdateUI()
        {
            foreach (MMDevice deviceRender in DevEnum.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active))
            {
                var defaultRender = DevEnum.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
                ucSpeaker auPanelSpeaker = null;
                var devName = deviceRender.FriendlyName;
                var isSpeakerMute = deviceRender.AudioEndpointVolume.Mute;
                var speakerValue = 0;
                foreach (var c in pnlMain.Controls)
                {
                    var au = c as ucSpeaker;
                    if (au != null && au.Title == devName)
                    {
                        auPanelSpeaker = au;
                        break;
                    }
                }
                speakerValue = (int)(deviceRender.AudioEndpointVolume.MasterVolumeLevelScalar * 100); // 扬声器音量
                if (auPanelSpeaker == null)
                {
                    auPanelSpeaker = new ucSpeaker();
                    auPanelSpeaker.Dock = DockStyle.Top;
                    pnlMain.Controls.Add(auPanelSpeaker);
                }
                auPanelSpeaker.InitAudioPanel(devName, isSpeakerMute, speakerValue, defaultRender.FriendlyName == devName);
            }

            foreach (MMDevice deviceRender in DevEnum.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active))
            {
                var defaultRender = DevEnum.GetDefaultAudioEndpoint(DataFlow.Capture, Role.Console);
                ucMicroPhone auPanelMicrophone = null;
                var devName = deviceRender.FriendlyName;
                var isMicrophoneMute = deviceRender.AudioEndpointVolume.Mute;
                var microphoneValue = 0;
                foreach (var c in pnlMain.Controls)
                {
                    var au = c as ucMicroPhone;
                    if (au != null && au.Title == devName)
                    {
                        auPanelMicrophone = au;
                        break;
                    }
                }
                microphoneValue = (int)(deviceRender.AudioEndpointVolume.MasterVolumeLevelScalar * 100); // 麦克风音量

                if (auPanelMicrophone == null)
                {
                    auPanelMicrophone = new ucMicroPhone();
                    auPanelMicrophone.Dock = DockStyle.Top;
                    pnlMain.Controls.Add(auPanelMicrophone);
                }
                auPanelMicrophone.InitAudioPanel(devName, isMicrophoneMute, microphoneValue, defaultRender.FriendlyName == devName);
            }

            //foreach (MMDevice deviceRender in DevEnum.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active))
            //{
            //    var defaultRender = DevEnum.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
            //    UcAudio auPanel = null;
            //    var devName = deviceRender.FriendlyName;
            //    var isSpeakerMute = deviceRender.AudioEndpointVolume.Mute;
            //    var isMicrophoneMute = false;
            //    var speakerValue = 0;
            //    var microphoneValue = 0;
            //    foreach (var c in flowLayoutPanel1.Controls)
            //    {
            //        var au = c as UcAudio;
            //        if (au.Title == devName)
            //        {
            //            auPanel = au;
            //            break;
            //        }
            //    }
            //    if (auPanel == null)
            //    {
            //        auPanel = new UcAudio();
            //        flowLayoutPanel1.Controls.Add(auPanel);
            //    }

            //    speakerValue = (int)(deviceRender.AudioEndpointVolume.MasterVolumeLevelScalar * 100); // 扬声器音量
            //    foreach (MMDevice deviceCapture in DevEnum.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active))
            //    {
            //        if (devName == deviceCapture.FriendlyName)
            //        {
            //            microphoneValue = (int)(deviceCapture.AudioEndpointVolume.MasterVolumeLevelScalar * 100); // 麦克风音量
            //            isMicrophoneMute = deviceCapture.AudioEndpointVolume.Mute;
            //        }
            //    }
            //    auPanel.InitAudioPanel(devName, isSpeakerMute, isMicrophoneMute, speakerValue, microphoneValue, defaultRender.FriendlyName == devName);
            //}
        }

        protected override void OnClosed(EventArgs e)
        {
            timer1.Stop();
            base.OnClosed(e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                UpdateUI();
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                MessageBox.Show($"{ex.Message}  推断：找不到音响资源。");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void btnSystemAudioPanel_Click(object sender, EventArgs e)
        {
            Process.Start("mmsys.cpl");
        }

        private void chkDefault_CheckedChanged(object sender, EventArgs e)
        {
            foreach (var c in pnlMain.Controls)
            {
                var ucSpeaker = c as ucSpeaker;
                if (ucSpeaker != null && !ucSpeaker.IsDefault)
                {
                    ucSpeaker.Visible = !chkDefault.Checked;
                }
                var ucMicrophone = c as ucMicroPhone;
                if (ucMicrophone != null && !ucMicrophone.IsDefault)
                {
                    ucMicrophone.Visible = !chkDefault.Checked;
                }
            }
        }
    }
}
