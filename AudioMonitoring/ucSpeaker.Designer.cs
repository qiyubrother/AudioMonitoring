namespace AudioMonitoring
{
    partial class ucSpeaker
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.chkDefault = new System.Windows.Forms.CheckBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSpeakerValue = new System.Windows.Forms.Label();
            this.chkSpeakerMute = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.trackBarSpeaker = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeaker)).BeginInit();
            this.SuspendLayout();
            // 
            // chkDefault
            // 
            this.chkDefault.AutoSize = true;
            this.chkDefault.Enabled = false;
            this.chkDefault.Location = new System.Drawing.Point(527, 24);
            this.chkDefault.Name = "chkDefault";
            this.chkDefault.Size = new System.Drawing.Size(48, 16);
            this.chkDefault.TabIndex = 25;
            this.chkDefault.Text = "默认";
            this.chkDefault.UseVisualStyleBackColor = true;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.Location = new System.Drawing.Point(592, 24);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(450, 23);
            this.lblTitle.TabIndex = 24;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSpeakerValue
            // 
            this.lblSpeakerValue.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSpeakerValue.Location = new System.Drawing.Point(458, 24);
            this.lblSpeakerValue.Name = "lblSpeakerValue";
            this.lblSpeakerValue.Size = new System.Drawing.Size(63, 23);
            this.lblSpeakerValue.TabIndex = 23;
            this.lblSpeakerValue.Text = "100";
            this.lblSpeakerValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkSpeakerMute
            // 
            this.chkSpeakerMute.AutoSize = true;
            this.chkSpeakerMute.Enabled = false;
            this.chkSpeakerMute.Location = new System.Drawing.Point(19, 24);
            this.chkSpeakerMute.Name = "chkSpeakerMute";
            this.chkSpeakerMute.Size = new System.Drawing.Size(48, 16);
            this.chkSpeakerMute.TabIndex = 22;
            this.chkSpeakerMute.Text = "静音";
            this.chkSpeakerMute.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(90, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 21;
            this.label2.Text = "扬声器音量";
            // 
            // trackBarSpeaker
            // 
            this.trackBarSpeaker.Enabled = false;
            this.trackBarSpeaker.Location = new System.Drawing.Point(180, 13);
            this.trackBarSpeaker.Maximum = 100;
            this.trackBarSpeaker.Name = "trackBarSpeaker";
            this.trackBarSpeaker.Size = new System.Drawing.Size(272, 45);
            this.trackBarSpeaker.TabIndex = 20;
            this.trackBarSpeaker.TickStyle = System.Windows.Forms.TickStyle.Both;
            // 
            // ucSpeaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Moccasin;
            this.Controls.Add(this.chkDefault);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSpeakerValue);
            this.Controls.Add(this.chkSpeakerMute);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.trackBarSpeaker);
            this.Name = "ucSpeaker";
            this.Size = new System.Drawing.Size(1060, 66);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeaker)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkDefault;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSpeakerValue;
        private System.Windows.Forms.CheckBox chkSpeakerMute;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trackBarSpeaker;
    }
}
