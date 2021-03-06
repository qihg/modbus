﻿namespace CommCtrlSystem
{
    partial class FormSysCfg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonASCII1 = new System.Windows.Forms.RadioButton();
            this.radioButtonRTU1 = new System.Windows.Forms.RadioButton();
            this.comboBoxStopBits1 = new System.Windows.Forms.ComboBox();
            this.comboBoxParity1 = new System.Windows.Forms.ComboBox();
            this.comboBoxDataBits1 = new System.Windows.Forms.ComboBox();
            this.comboBoxBaud1 = new System.Windows.Forms.ComboBox();
            this.comboBoxCom1 = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButtonASCII2 = new System.Windows.Forms.RadioButton();
            this.radioButtonRTU2 = new System.Windows.Forms.RadioButton();
            this.comboBoxStopBits2 = new System.Windows.Forms.ComboBox();
            this.comboBoxParity2 = new System.Windows.Forms.ComboBox();
            this.comboBoxDataBits2 = new System.Windows.Forms.ComboBox();
            this.comboBoxBaud2 = new System.Windows.Forms.ComboBox();
            this.comboBoxCom2 = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBoxConnectMode = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.maskedTextBoxServerPort = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.checkBoxAutoStartOnLoad = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxAnalysis = new System.Windows.Forms.TextBox();
            this.textBoxIpAddr = new CommCtrlSystem.IPAddrTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonASCII1);
            this.groupBox1.Controls.Add(this.radioButtonRTU1);
            this.groupBox1.Controls.Add(this.comboBoxStopBits1);
            this.groupBox1.Controls.Add(this.comboBoxParity1);
            this.groupBox1.Controls.Add(this.comboBoxDataBits1);
            this.groupBox1.Controls.Add(this.comboBoxBaud1);
            this.groupBox1.Controls.Add(this.comboBoxCom1);
            this.groupBox1.Location = new System.Drawing.Point(16, 16);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(207, 299);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "采集端口设定";
            // 
            // radioButtonASCII1
            // 
            this.radioButtonASCII1.AutoSize = true;
            this.radioButtonASCII1.Location = new System.Drawing.Point(99, 257);
            this.radioButtonASCII1.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonASCII1.Name = "radioButtonASCII1";
            this.radioButtonASCII1.Size = new System.Drawing.Size(53, 16);
            this.radioButtonASCII1.TabIndex = 1;
            this.radioButtonASCII1.Text = "ASCII";
            this.radioButtonASCII1.UseVisualStyleBackColor = true;
            // 
            // radioButtonRTU1
            // 
            this.radioButtonRTU1.AutoSize = true;
            this.radioButtonRTU1.Checked = true;
            this.radioButtonRTU1.Location = new System.Drawing.Point(8, 257);
            this.radioButtonRTU1.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonRTU1.Name = "radioButtonRTU1";
            this.radioButtonRTU1.Size = new System.Drawing.Size(41, 16);
            this.radioButtonRTU1.TabIndex = 1;
            this.radioButtonRTU1.TabStop = true;
            this.radioButtonRTU1.Text = "RTU";
            this.radioButtonRTU1.UseVisualStyleBackColor = true;
            // 
            // comboBoxStopBits1
            // 
            this.comboBoxStopBits1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStopBits1.FormattingEnabled = true;
            this.comboBoxStopBits1.Items.AddRange(new object[] {
            "1 Stop Bit",
            "2 Stop Bits"});
            this.comboBoxStopBits1.Location = new System.Drawing.Point(8, 205);
            this.comboBoxStopBits1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxStopBits1.Name = "comboBoxStopBits1";
            this.comboBoxStopBits1.Size = new System.Drawing.Size(160, 24);
            this.comboBoxStopBits1.TabIndex = 5;
            // 
            // comboBoxParity1
            // 
            this.comboBoxParity1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxParity1.FormattingEnabled = true;
            this.comboBoxParity1.Items.AddRange(new object[] {
            "None Parity",
            "Odd Parity",
            "Even Parity"});
            this.comboBoxParity1.Location = new System.Drawing.Point(8, 164);
            this.comboBoxParity1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxParity1.Name = "comboBoxParity1";
            this.comboBoxParity1.Size = new System.Drawing.Size(160, 24);
            this.comboBoxParity1.TabIndex = 4;
            // 
            // comboBoxDataBits1
            // 
            this.comboBoxDataBits1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDataBits1.FormattingEnabled = true;
            this.comboBoxDataBits1.Items.AddRange(new object[] {
            "7 Data Bits",
            "8 Data Bits"});
            this.comboBoxDataBits1.Location = new System.Drawing.Point(8, 123);
            this.comboBoxDataBits1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxDataBits1.Name = "comboBoxDataBits1";
            this.comboBoxDataBits1.Size = new System.Drawing.Size(160, 24);
            this.comboBoxDataBits1.TabIndex = 3;
            // 
            // comboBoxBaud1
            // 
            this.comboBoxBaud1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBaud1.FormattingEnabled = true;
            this.comboBoxBaud1.Items.AddRange(new object[] {
            "300 Baud",
            "600 Baud",
            "1200 Baud",
            "2400 Baud",
            "4800 Baud",
            "9600 Baud",
            "14400 Baud",
            "19200 Baud",
            "38400 Baud",
            "56000 Baud",
            "57600 Baud",
            "115200 Baud",
            "921600 Baud"});
            this.comboBoxBaud1.Location = new System.Drawing.Point(8, 81);
            this.comboBoxBaud1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxBaud1.Name = "comboBoxBaud1";
            this.comboBoxBaud1.Size = new System.Drawing.Size(160, 24);
            this.comboBoxBaud1.TabIndex = 2;
            // 
            // comboBoxCom1
            // 
            this.comboBoxCom1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCom1.FormattingEnabled = true;
            this.comboBoxCom1.Location = new System.Drawing.Point(8, 40);
            this.comboBoxCom1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxCom1.Name = "comboBoxCom1";
            this.comboBoxCom1.Size = new System.Drawing.Size(160, 24);
            this.comboBoxCom1.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButtonASCII2);
            this.groupBox2.Controls.Add(this.radioButtonRTU2);
            this.groupBox2.Controls.Add(this.comboBoxStopBits2);
            this.groupBox2.Controls.Add(this.comboBoxParity2);
            this.groupBox2.Controls.Add(this.comboBoxDataBits2);
            this.groupBox2.Controls.Add(this.comboBoxBaud2);
            this.groupBox2.Controls.Add(this.comboBoxCom2);
            this.groupBox2.Location = new System.Drawing.Point(276, 105);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(207, 299);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "输出串口设定";
            // 
            // radioButtonASCII2
            // 
            this.radioButtonASCII2.AutoSize = true;
            this.radioButtonASCII2.Location = new System.Drawing.Point(99, 257);
            this.radioButtonASCII2.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonASCII2.Name = "radioButtonASCII2";
            this.radioButtonASCII2.Size = new System.Drawing.Size(53, 16);
            this.radioButtonASCII2.TabIndex = 1;
            this.radioButtonASCII2.Text = "ASCII";
            this.radioButtonASCII2.UseVisualStyleBackColor = true;
            // 
            // radioButtonRTU2
            // 
            this.radioButtonRTU2.AutoSize = true;
            this.radioButtonRTU2.Checked = true;
            this.radioButtonRTU2.Location = new System.Drawing.Point(8, 257);
            this.radioButtonRTU2.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonRTU2.Name = "radioButtonRTU2";
            this.radioButtonRTU2.Size = new System.Drawing.Size(41, 16);
            this.radioButtonRTU2.TabIndex = 1;
            this.radioButtonRTU2.TabStop = true;
            this.radioButtonRTU2.Text = "RTU";
            this.radioButtonRTU2.UseVisualStyleBackColor = true;
            // 
            // comboBoxStopBits2
            // 
            this.comboBoxStopBits2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStopBits2.FormattingEnabled = true;
            this.comboBoxStopBits2.Items.AddRange(new object[] {
            "1 Stop Bit",
            "2 Stop Bits"});
            this.comboBoxStopBits2.Location = new System.Drawing.Point(8, 205);
            this.comboBoxStopBits2.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxStopBits2.Name = "comboBoxStopBits2";
            this.comboBoxStopBits2.Size = new System.Drawing.Size(160, 24);
            this.comboBoxStopBits2.TabIndex = 5;
            // 
            // comboBoxParity2
            // 
            this.comboBoxParity2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxParity2.FormattingEnabled = true;
            this.comboBoxParity2.Items.AddRange(new object[] {
            "None Parity",
            "Odd Parity",
            "Even Parity"});
            this.comboBoxParity2.Location = new System.Drawing.Point(8, 164);
            this.comboBoxParity2.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxParity2.Name = "comboBoxParity2";
            this.comboBoxParity2.Size = new System.Drawing.Size(160, 24);
            this.comboBoxParity2.TabIndex = 4;
            // 
            // comboBoxDataBits2
            // 
            this.comboBoxDataBits2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDataBits2.FormattingEnabled = true;
            this.comboBoxDataBits2.Items.AddRange(new object[] {
            "7 Data Bits",
            "8 Data Bits"});
            this.comboBoxDataBits2.Location = new System.Drawing.Point(8, 123);
            this.comboBoxDataBits2.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxDataBits2.Name = "comboBoxDataBits2";
            this.comboBoxDataBits2.Size = new System.Drawing.Size(160, 24);
            this.comboBoxDataBits2.TabIndex = 3;
            // 
            // comboBoxBaud2
            // 
            this.comboBoxBaud2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBaud2.FormattingEnabled = true;
            this.comboBoxBaud2.Items.AddRange(new object[] {
            "300 Baud",
            "600 Baud",
            "1200 Baud",
            "2400 Baud",
            "4800 Baud",
            "9600 Baud",
            "14400 Baud",
            "19200 Baud",
            "38400 Baud",
            "56000 Baud",
            "57600 Baud",
            "115200 Baud",
            "921600 Baud"});
            this.comboBoxBaud2.Location = new System.Drawing.Point(8, 81);
            this.comboBoxBaud2.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxBaud2.Name = "comboBoxBaud2";
            this.comboBoxBaud2.Size = new System.Drawing.Size(160, 24);
            this.comboBoxBaud2.TabIndex = 2;
            // 
            // comboBoxCom2
            // 
            this.comboBoxCom2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCom2.FormattingEnabled = true;
            this.comboBoxCom2.Location = new System.Drawing.Point(8, 40);
            this.comboBoxCom2.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxCom2.Name = "comboBoxCom2";
            this.comboBoxCom2.Size = new System.Drawing.Size(160, 24);
            this.comboBoxCom2.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBoxConnectMode);
            this.groupBox3.Location = new System.Drawing.Point(276, 16);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(207, 67);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "连接模式";
            // 
            // comboBoxConnectMode
            // 
            this.comboBoxConnectMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxConnectMode.FormattingEnabled = true;
            this.comboBoxConnectMode.Items.AddRange(new object[] {
            "串口",
            "TCP/IP"});
            this.comboBoxConnectMode.Location = new System.Drawing.Point(8, 27);
            this.comboBoxConnectMode.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxConnectMode.Name = "comboBoxConnectMode";
            this.comboBoxConnectMode.Size = new System.Drawing.Size(160, 24);
            this.comboBoxConnectMode.TabIndex = 6;
            this.comboBoxConnectMode.SelectedIndexChanged += new System.EventHandler(this.comboBoxConnectMode_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBoxIpAddr);
            this.groupBox4.Controls.Add(this.maskedTextBoxServerPort);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(491, 105);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(181, 163);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "TCP/IP设定";
            // 
            // maskedTextBoxServerPort
            // 
            this.maskedTextBoxServerPort.Location = new System.Drawing.Point(8, 127);
            this.maskedTextBoxServerPort.Margin = new System.Windows.Forms.Padding(4);
            this.maskedTextBoxServerPort.Name = "maskedTextBoxServerPort";
            this.maskedTextBoxServerPort.Size = new System.Drawing.Size(133, 21);
            this.maskedTextBoxServerPort.TabIndex = 4;
            this.maskedTextBoxServerPort.Text = "502";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 96);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "Server IP";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(501, 16);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(76, 67);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(596, 16);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(76, 67);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // checkBoxAutoStartOnLoad
            // 
            this.checkBoxAutoStartOnLoad.AutoSize = true;
            this.checkBoxAutoStartOnLoad.Location = new System.Drawing.Point(16, 337);
            this.checkBoxAutoStartOnLoad.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxAutoStartOnLoad.Name = "checkBoxAutoStartOnLoad";
            this.checkBoxAutoStartOnLoad.Size = new System.Drawing.Size(156, 16);
            this.checkBoxAutoStartOnLoad.TabIndex = 4;
            this.checkBoxAutoStartOnLoad.Text = "打开程序时开始实时采集";
            this.checkBoxAutoStartOnLoad.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBoxAnalysis);
            this.groupBox5.Controls.Add(this.textBoxPassword);
            this.groupBox5.Controls.Add(this.textBoxUserName);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Location = new System.Drawing.Point(493, 276);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(178, 127);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "系统设定";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "用户名";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "密码";
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(66, 18);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(96, 21);
            this.textBoxUserName.TabIndex = 1;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(66, 43);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(96, 21);
            this.textBoxPassword.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "分析方法";
            // 
            // textBoxAnalysis
            // 
            this.textBoxAnalysis.Location = new System.Drawing.Point(66, 67);
            this.textBoxAnalysis.Name = "textBoxAnalysis";
            this.textBoxAnalysis.Size = new System.Drawing.Size(96, 21);
            this.textBoxAnalysis.TabIndex = 1;
            // 
            // textBoxIpAddr
            // 
            this.textBoxIpAddr.Location = new System.Drawing.Point(8, 64);
            this.textBoxIpAddr.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxIpAddr.Name = "textBoxIpAddr";
            this.textBoxIpAddr.Size = new System.Drawing.Size(135, 21);
            this.textBoxIpAddr.TabIndex = 5;
            this.textBoxIpAddr.Text = "0.0.0.0";
            // 
            // FormSysCfg
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(699, 428);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.checkBoxAutoStartOnLoad);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSysCfg";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = " ";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonASCII1;
        private System.Windows.Forms.RadioButton radioButtonRTU1;
        private System.Windows.Forms.ComboBox comboBoxStopBits1;
        private System.Windows.Forms.ComboBox comboBoxParity1;
        private System.Windows.Forms.ComboBox comboBoxDataBits1;
        private System.Windows.Forms.ComboBox comboBoxBaud1;
        private System.Windows.Forms.ComboBox comboBoxCom1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButtonASCII2;
        private System.Windows.Forms.RadioButton radioButtonRTU2;
        private System.Windows.Forms.ComboBox comboBoxStopBits2;
        private System.Windows.Forms.ComboBox comboBoxParity2;
        private System.Windows.Forms.ComboBox comboBoxDataBits2;
        private System.Windows.Forms.ComboBox comboBoxBaud2;
        private System.Windows.Forms.ComboBox comboBoxCom2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox comboBoxConnectMode;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxServerPort;
        private System.Windows.Forms.CheckBox checkBoxAutoStartOnLoad;
        private IPAddrTextBox textBoxIpAddr;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox textBoxAnalysis;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}