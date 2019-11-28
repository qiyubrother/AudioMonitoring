namespace AudioMonitoring
{
    partial class ucMicroPhone
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
            this.lblMicrophoneValue = new System.Windows.Forms.Label();
            this.chkMicrophoneMute = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.trackBarMicrophone = new System.Windows.Forms.TrackBar();
            this.lblTitle = new System.Windows.Forms.Label();
            this.chkDefault = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMicrophone)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMicrophoneValue
            // 
            this.lblMicrophoneValue.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMicrophoneValue.Location = new System.Drawing.Point(458, 24);
            this.lblMicrophoneValue.Name = "lblMicrophoneValue";
            this.lblMicrophoneValue.Size = new System.Drawing.Size(63, 23);
            this.lblMicrophoneValue.TabIndex = 17;
            this.lblMicrophoneValue.Text = "100";
            this.lblMicrophoneValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkMicrophoneMute
            // 
            this.chkMicrophoneMute.AutoSize = true;
            this.chkMicrophoneMute.Location = new System.Drawing.Point(19, 24);
            this.chkMicrophoneMute.Name = "chkMicrophoneMute";
            this.chkMicrophoneMute.Size = new System.Drawing.Size(48, 16);
            this.chkMicrophoneMute.TabIndex = 16;
            this.chkMicrophoneMute.Text = "静音";
            this.chkMicrophoneMute.UseVisualStyleBackColor = true;
            this.chkMicrophoneMute.CheckedChanged += new System.EventHandler(this.chkMicrophoneMute_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(90, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "麦克风音量";
            // 
            // trackBarMicrophone
            // 
            this.trackBarMicrophone.Location = new System.Drawing.Point(180, 13);
            this.trackBarMicrophone.Maximum = 100;
            this.trackBarMicrophone.Name = "trackBarMicrophone";
            this.trackBarMicrophone.Size = new System.Drawing.Size(272, 45);
            this.trackBarMicrophone.TabIndex = 14;
            this.trackBarMicrophone.TickStyle = System.Windows.Forms.TickStyle.Both;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.Location = new System.Drawing.Point(592, 24);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(450, 23);
            this.lblTitle.TabIndex = 18;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkDefault
            // 
            this.chkDefault.AutoSize = true;
            this.chkDefault.Enabled = false;
            this.chkDefault.Location = new System.Drawing.Point(527, 24);
            this.chkDefault.Name = "chkDefault";
            this.chkDefault.Size = new System.Drawing.Size(48, 16);
            this.chkDefault.TabIndex = 19;
            this.chkDefault.Text = "默认";
            this.chkDefault.UseVisualStyleBackColor = true;
            // 
            // ucMicroPhone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Controls.Add(this.chkDefault);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblMicrophoneValue);
            this.Controls.Add(this.chkMicrophoneMute);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.trackBarMicrophone);
            this.Name = "ucMicroPhone";
            this.Size = new System.Drawing.Size(1060, 66);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMicrophone)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMicrophoneValue;
        private System.Windows.Forms.CheckBox chkMicrophoneMute;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trackBarMicrophone;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.CheckBox chkDefault;
    }
}
