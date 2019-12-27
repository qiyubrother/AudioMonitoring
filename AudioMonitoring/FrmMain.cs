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
            try
            {
                var defaultRender = DevEnum.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
                foreach (MMDevice deviceRender in DevEnum.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active))
                {
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
            }
            catch(Exception ex)
            {

            }

            try
            {
                var defaultCapture = DevEnum.GetDefaultAudioEndpoint(DataFlow.Capture, Role.Console);
                foreach (MMDevice deviceRender in DevEnum.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active))
                {
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
                    auPanelMicrophone.InitAudioPanel(devName, isMicrophoneMute, microphoneValue, defaultCapture.FriendlyName == devName);
                }
            }
            catch(Exception ex)
            {

            }

            // 移除不必要的数据
            var lst = new List<Control>();
            foreach (Control c in pnlMain.Controls)
            {
                if (c is ucSpeaker)
                {
                    var au = c as ucSpeaker;
                    bool isFind = false;
                    foreach (MMDevice deviceRender in DevEnum.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active))
                    {
                        if (deviceRender.FriendlyName == au.Title)
                        {
                            isFind = true;
                            break;
                        }
                    }
                    if (!isFind)
                    {
                        lst.Add(c);
                    }
                }
                else if (c is ucMicroPhone)
                {
                    var au = c as ucMicroPhone;
                    bool isFind = false;
                    foreach (MMDevice deviceCapture in DevEnum.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active))
                    {
                        if (deviceCapture.FriendlyName == au.Title)
                        {
                            isFind = true;
                            break;
                        }
                    }
                    if (!isFind)
                    {
                        lst.Add(c);
                    }
                }
            }
            for(var i = lst.Count - 1; i >=0; i--)
            {
                pnlMain.Controls.Remove(lst[i]);
                lst.Remove(lst[i]);
            }
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
                timer1.Stop();
                MessageBox.Show($"{ex.Message}  推断：找不到音响资源。监控将停止工作。如需启动监控，请重新启动本软件。");
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

        private void chkTopmost_CheckedChanged(object sender, EventArgs e)
        {
            TopMost = chkTopmost.Checked;
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
            var defaultRender = DevEnum.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
            var defaultCapture = DevEnum.GetDefaultAudioEndpoint(DataFlow.Capture, Role.Console);
            sb.Append($"---------- 输入设备 ----------");
            sb.Append($"{Environment.NewLine}");
            foreach (MMDevice deviceRender in DevEnum.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active))
            {
                sb.Append($"ID={deviceRender.ID}{Environment.NewLine}FriendlyName={deviceRender.FriendlyName}{Environment.NewLine}DeviceFriendlyName={deviceRender.DeviceFriendlyName}{Environment.NewLine}IsDefault={defaultRender.FriendlyName == deviceRender.FriendlyName}{Environment.NewLine}{Environment.NewLine}");
            }
            sb.Append($"{Environment.NewLine}");
            sb.Append($"---------- 输出设备 ----------");
            sb.Append($"{Environment.NewLine}");
            foreach (MMDevice deviceCapture in DevEnum.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active))
            {
                sb.Append($"ID={deviceCapture.ID}{Environment.NewLine}FriendlyName={deviceCapture.FriendlyName}{Environment.NewLine}DeviceFriendlyName={deviceCapture.DeviceFriendlyName}{Environment.NewLine}IsDefault={defaultCapture.FriendlyName == deviceCapture.FriendlyName}{Environment.NewLine}{Environment.NewLine}");
            }

            var frm = new FrmDetail();
            frm.DetailText = sb.ToString();
            frm.ShowDialog();
        }
    }
}
