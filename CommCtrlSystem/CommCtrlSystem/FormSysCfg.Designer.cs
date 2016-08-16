namespace CommCtrlSystem
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
            this.maskedTextBoxServerIP = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.checkBoxAutoStartOnLoad = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
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
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(155, 224);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "采集端口设定";
            // 
            // radioButtonASCII1
            // 
            this.radioButtonASCII1.AutoSize = true;
            this.radioButtonASCII1.Location = new System.Drawing.Point(74, 193);
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
            this.radioButtonRTU1.Location = new System.Drawing.Point(6, 193);
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
            this.comboBoxStopBits1.Location = new System.Drawing.Point(6, 154);
            this.comboBoxStopBits1.Name = "comboBoxStopBits1";
            this.comboBoxStopBits1.Size = new System.Drawing.Size(121, 20);
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
            this.comboBoxParity1.Location = new System.Drawing.Point(6, 123);
            this.comboBoxParity1.Name = "comboBoxParity1";
            this.comboBoxParity1.Size = new System.Drawing.Size(121, 20);
            this.comboBoxParity1.TabIndex = 4;
            // 
            // comboBoxDataBits1
            // 
            this.comboBoxDataBits1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDataBits1.FormattingEnabled = true;
            this.comboBoxDataBits1.Items.AddRange(new object[] {
            "7 Data Bits",
            "8 Data Bits"});
            this.comboBoxDataBits1.Location = new System.Drawing.Point(6, 92);
            this.comboBoxDataBits1.Name = "comboBoxDataBits1";
            this.comboBoxDataBits1.Size = new System.Drawing.Size(121, 20);
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
            this.comboBoxBaud1.Location = new System.Drawing.Point(6, 61);
            this.comboBoxBaud1.Name = "comboBoxBaud1";
            this.comboBoxBaud1.Size = new System.Drawing.Size(121, 20);
            this.comboBoxBaud1.TabIndex = 2;
            // 
            // comboBoxCom1
            // 
            this.comboBoxCom1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCom1.FormattingEnabled = true;
            this.comboBoxCom1.Location = new System.Drawing.Point(6, 30);
            this.comboBoxCom1.Name = "comboBoxCom1";
            this.comboBoxCom1.Size = new System.Drawing.Size(121, 20);
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
            this.groupBox2.Location = new System.Drawing.Point(207, 79);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(155, 224);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "输出串口设定";
            // 
            // radioButtonASCII2
            // 
            this.radioButtonASCII2.AutoSize = true;
            this.radioButtonASCII2.Location = new System.Drawing.Point(74, 193);
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
            this.radioButtonRTU2.Location = new System.Drawing.Point(6, 193);
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
            this.comboBoxStopBits2.Location = new System.Drawing.Point(6, 154);
            this.comboBoxStopBits2.Name = "comboBoxStopBits2";
            this.comboBoxStopBits2.Size = new System.Drawing.Size(121, 20);
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
            this.comboBoxParity2.Location = new System.Drawing.Point(6, 123);
            this.comboBoxParity2.Name = "comboBoxParity2";
            this.comboBoxParity2.Size = new System.Drawing.Size(121, 20);
            this.comboBoxParity2.TabIndex = 4;
            // 
            // comboBoxDataBits2
            // 
            this.comboBoxDataBits2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDataBits2.FormattingEnabled = true;
            this.comboBoxDataBits2.Items.AddRange(new object[] {
            "7 Data Bits",
            "8 Data Bits"});
            this.comboBoxDataBits2.Location = new System.Drawing.Point(6, 92);
            this.comboBoxDataBits2.Name = "comboBoxDataBits2";
            this.comboBoxDataBits2.Size = new System.Drawing.Size(121, 20);
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
            this.comboBoxBaud2.Location = new System.Drawing.Point(6, 61);
            this.comboBoxBaud2.Name = "comboBoxBaud2";
            this.comboBoxBaud2.Size = new System.Drawing.Size(121, 20);
            this.comboBoxBaud2.TabIndex = 2;
            // 
            // comboBoxCom2
            // 
            this.comboBoxCom2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCom2.FormattingEnabled = true;
            this.comboBoxCom2.Location = new System.Drawing.Point(6, 30);
            this.comboBoxCom2.Name = "comboBoxCom2";
            this.comboBoxCom2.Size = new System.Drawing.Size(121, 20);
            this.comboBoxCom2.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBoxConnectMode);
            this.groupBox3.Location = new System.Drawing.Point(207, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(155, 50);
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
            this.comboBoxConnectMode.Location = new System.Drawing.Point(6, 20);
            this.comboBoxConnectMode.Name = "comboBoxConnectMode";
            this.comboBoxConnectMode.Size = new System.Drawing.Size(121, 20);
            this.comboBoxConnectMode.TabIndex = 6;
            this.comboBoxConnectMode.SelectedIndexChanged += new System.EventHandler(this.comboBoxConnectMode_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.maskedTextBoxServerPort);
            this.groupBox4.Controls.Add(this.maskedTextBoxServerIP);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(368, 79);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(136, 122);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "TCP/IP设定";
            // 
            // maskedTextBoxServerPort
            // 
            this.maskedTextBoxServerPort.Location = new System.Drawing.Point(6, 95);
            this.maskedTextBoxServerPort.Mask = "00000";
            this.maskedTextBoxServerPort.Name = "maskedTextBoxServerPort";
            this.maskedTextBoxServerPort.Size = new System.Drawing.Size(101, 21);
            this.maskedTextBoxServerPort.TabIndex = 4;
            this.maskedTextBoxServerPort.Text = "502";
            // 
            // maskedTextBoxServerIP
            // 
            this.maskedTextBoxServerIP.Location = new System.Drawing.Point(6, 45);
            this.maskedTextBoxServerIP.Mask = "000.000.000.000";
            this.maskedTextBoxServerIP.Name = "maskedTextBoxServerIP";
            this.maskedTextBoxServerIP.Size = new System.Drawing.Size(101, 21);
            this.maskedTextBoxServerIP.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "Server IP";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(376, 12);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(57, 50);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(447, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(57, 50);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // checkBoxAutoStartOnLoad
            // 
            this.checkBoxAutoStartOnLoad.AutoSize = true;
            this.checkBoxAutoStartOnLoad.Location = new System.Drawing.Point(12, 253);
            this.checkBoxAutoStartOnLoad.Name = "checkBoxAutoStartOnLoad";
            this.checkBoxAutoStartOnLoad.Size = new System.Drawing.Size(156, 16);
            this.checkBoxAutoStartOnLoad.TabIndex = 4;
            this.checkBoxAutoStartOnLoad.Text = "打开程序时开始实时采集";
            this.checkBoxAutoStartOnLoad.UseVisualStyleBackColor = true;
            // 
            // FormSysCfg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 321);
            this.Controls.Add(this.checkBoxAutoStartOnLoad);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
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
        private System.Windows.Forms.MaskedTextBox maskedTextBoxServerIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxServerPort;
        private System.Windows.Forms.CheckBox checkBoxAutoStartOnLoad;
    }
}