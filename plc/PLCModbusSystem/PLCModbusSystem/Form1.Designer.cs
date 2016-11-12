namespace PLCModbusSystem
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxDevName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxDevID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxLabName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxAnalysis = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxOilName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxOilID = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.checkBoxExcel = new System.Windows.Forms.CheckBox();
            this.checkBoxLims = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxFormat = new System.Windows.Forms.ComboBox();
            this.radioButtonNetwork = new System.Windows.Forms.RadioButton();
            this.radioButtonSerial = new System.Windows.Forms.RadioButton();
            this.maskedTextBoxStartAddr = new System.Windows.Forms.MaskedTextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.buttonSaveSettings = new System.Windows.Forms.Button();
            this.label33 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.comboBoxSerialPort = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.comboBoxProtocol = new System.Windows.Forms.ComboBox();
            this.comboBoxBaud = new System.Windows.Forms.ComboBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.textBoxIPAddr = new PLCModbusSystem.IPAddrTextBox();
            this.buttonTestOutput = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.labelWarning = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.regTextBox2 = new PLCModbusSystem.RegTextBox();
            this.regTextBox1 = new PLCModbusSystem.RegTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.regTextBox4 = new PLCModbusSystem.RegTextBox();
            this.regTextBox3 = new PLCModbusSystem.RegTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.regTextBox6 = new PLCModbusSystem.RegTextBox();
            this.regTextBox5 = new PLCModbusSystem.RegTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.regTextBox8 = new PLCModbusSystem.RegTextBox();
            this.regTextBox7 = new PLCModbusSystem.RegTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.regTextBoxResult = new PLCModbusSystem.RegTextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "仪器名称";
            // 
            // textBoxDevName
            // 
            this.textBoxDevName.Location = new System.Drawing.Point(124, 91);
            this.textBoxDevName.Name = "textBoxDevName";
            this.textBoxDevName.Size = new System.Drawing.Size(103, 21);
            this.textBoxDevName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "仪器编号";
            // 
            // textBoxDevID
            // 
            this.textBoxDevID.Location = new System.Drawing.Point(124, 118);
            this.textBoxDevID.Name = "textBoxDevID";
            this.textBoxDevID.Size = new System.Drawing.Size(103, 21);
            this.textBoxDevID.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "实验室名称";
            // 
            // textBoxLabName
            // 
            this.textBoxLabName.Location = new System.Drawing.Point(124, 145);
            this.textBoxLabName.Name = "textBoxLabName";
            this.textBoxLabName.Size = new System.Drawing.Size(103, 21);
            this.textBoxLabName.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "分析方法";
            // 
            // textBoxAnalysis
            // 
            this.textBoxAnalysis.Location = new System.Drawing.Point(124, 172);
            this.textBoxAnalysis.Name = "textBoxAnalysis";
            this.textBoxAnalysis.Size = new System.Drawing.Size(103, 21);
            this.textBoxAnalysis.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "用户密码";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(124, 199);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(103, 21);
            this.textBoxPassword.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(45, 229);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "油样名称";
            // 
            // textBoxOilName
            // 
            this.textBoxOilName.Location = new System.Drawing.Point(124, 226);
            this.textBoxOilName.Name = "textBoxOilName";
            this.textBoxOilName.Size = new System.Drawing.Size(103, 21);
            this.textBoxOilName.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(45, 256);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "油样号";
            // 
            // textBoxOilID
            // 
            this.textBoxOilID.Location = new System.Drawing.Point(124, 253);
            this.textBoxOilID.Name = "textBoxOilID";
            this.textBoxOilID.Size = new System.Drawing.Size(103, 21);
            this.textBoxOilID.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(45, 283);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "实验员";
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(124, 280);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(103, 21);
            this.textBoxUserName.TabIndex = 1;
            // 
            // checkBoxExcel
            // 
            this.checkBoxExcel.AutoSize = true;
            this.checkBoxExcel.Location = new System.Drawing.Point(11, 459);
            this.checkBoxExcel.Name = "checkBoxExcel";
            this.checkBoxExcel.Size = new System.Drawing.Size(78, 16);
            this.checkBoxExcel.TabIndex = 2;
            this.checkBoxExcel.Text = "输出Excel";
            this.checkBoxExcel.UseVisualStyleBackColor = true;
            // 
            // checkBoxLims
            // 
            this.checkBoxLims.AutoSize = true;
            this.checkBoxLims.Location = new System.Drawing.Point(119, 459);
            this.checkBoxLims.Name = "checkBoxLims";
            this.checkBoxLims.Size = new System.Drawing.Size(72, 16);
            this.checkBoxLims.TabIndex = 2;
            this.checkBoxLims.Text = "输出lims";
            this.checkBoxLims.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxFormat);
            this.groupBox1.Controls.Add(this.radioButtonNetwork);
            this.groupBox1.Controls.Add(this.radioButtonSerial);
            this.groupBox1.Controls.Add(this.maskedTextBoxStartAddr);
            this.groupBox1.Controls.Add(this.label34);
            this.groupBox1.Controls.Add(this.buttonSaveSettings);
            this.groupBox1.Controls.Add(this.label33);
            this.groupBox1.Controls.Add(this.label32);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.checkBoxLims);
            this.groupBox1.Controls.Add(this.comboBoxSerialPort);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.comboBoxProtocol);
            this.groupBox1.Controls.Add(this.checkBoxExcel);
            this.groupBox1.Controls.Add(this.comboBoxBaud);
            this.groupBox1.Controls.Add(this.textBoxPort);
            this.groupBox1.Controls.Add(this.textBoxIPAddr);
            this.groupBox1.Location = new System.Drawing.Point(32, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(210, 528);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "用户输入";
            // 
            // comboBoxFormat
            // 
            this.comboBoxFormat.FormattingEnabled = true;
            this.comboBoxFormat.Items.AddRange(new object[] {
            "AB CD",
            "CD AB",
            "BA DC",
            "DC BA"});
            this.comboBoxFormat.Location = new System.Drawing.Point(70, 431);
            this.comboBoxFormat.Name = "comboBoxFormat";
            this.comboBoxFormat.Size = new System.Drawing.Size(121, 20);
            this.comboBoxFormat.TabIndex = 9;
            this.comboBoxFormat.Text = "DC BA";
            // 
            // radioButtonNetwork
            // 
            this.radioButtonNetwork.AutoSize = true;
            this.radioButtonNetwork.Location = new System.Drawing.Point(92, 252);
            this.radioButtonNetwork.Name = "radioButtonNetwork";
            this.radioButtonNetwork.Size = new System.Drawing.Size(59, 16);
            this.radioButtonNetwork.TabIndex = 12;
            this.radioButtonNetwork.TabStop = true;
            this.radioButtonNetwork.Text = "以太网";
            this.radioButtonNetwork.UseVisualStyleBackColor = true;
            this.radioButtonNetwork.CheckedChanged += new System.EventHandler(this.radioButtonNetwork_CheckedChanged);
            // 
            // radioButtonSerial
            // 
            this.radioButtonSerial.AutoSize = true;
            this.radioButtonSerial.Location = new System.Drawing.Point(15, 252);
            this.radioButtonSerial.Name = "radioButtonSerial";
            this.radioButtonSerial.Size = new System.Drawing.Size(47, 16);
            this.radioButtonSerial.TabIndex = 12;
            this.radioButtonSerial.TabStop = true;
            this.radioButtonSerial.Text = "串口";
            this.radioButtonSerial.UseVisualStyleBackColor = true;
            this.radioButtonSerial.CheckedChanged += new System.EventHandler(this.radioButtonSerial_CheckedChanged);
            // 
            // maskedTextBoxStartAddr
            // 
            this.maskedTextBoxStartAddr.Location = new System.Drawing.Point(70, 404);
            this.maskedTextBoxStartAddr.Mask = "99999";
            this.maskedTextBoxStartAddr.Name = "maskedTextBoxStartAddr";
            this.maskedTextBoxStartAddr.Size = new System.Drawing.Size(121, 21);
            this.maskedTextBoxStartAddr.TabIndex = 11;
            this.maskedTextBoxStartAddr.Text = "0";
            this.maskedTextBoxStartAddr.ValidatingType = typeof(int);
            this.maskedTextBoxStartAddr.Leave += new System.EventHandler(this.maskedTextBoxStartAddr_Leave);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(9, 332);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(29, 12);
            this.label34.TabIndex = 0;
            this.label34.Text = "协议";
            // 
            // buttonSaveSettings
            // 
            this.buttonSaveSettings.Location = new System.Drawing.Point(11, 481);
            this.buttonSaveSettings.Name = "buttonSaveSettings";
            this.buttonSaveSettings.Size = new System.Drawing.Size(180, 37);
            this.buttonSaveSettings.TabIndex = 3;
            this.buttonSaveSettings.Text = "保存设定";
            this.buttonSaveSettings.UseVisualStyleBackColor = true;
            this.buttonSaveSettings.Click += new System.EventHandler(this.buttonSaveSettings_Click);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(9, 379);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(29, 12);
            this.label33.TabIndex = 0;
            this.label33.Text = "端口";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(9, 354);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(41, 12);
            this.label32.TabIndex = 0;
            this.label32.Text = "IP地址";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(9, 434);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(53, 12);
            this.label22.TabIndex = 0;
            this.label22.Text = "浮点格式";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(9, 279);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 12);
            this.label17.TabIndex = 0;
            this.label17.Text = "输入串口";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(9, 307);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(41, 12);
            this.label19.TabIndex = 0;
            this.label19.Text = "波特率";
            // 
            // comboBoxSerialPort
            // 
            this.comboBoxSerialPort.FormattingEnabled = true;
            this.comboBoxSerialPort.Location = new System.Drawing.Point(70, 276);
            this.comboBoxSerialPort.Name = "comboBoxSerialPort";
            this.comboBoxSerialPort.Size = new System.Drawing.Size(121, 20);
            this.comboBoxSerialPort.TabIndex = 7;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(9, 407);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(53, 12);
            this.label21.TabIndex = 0;
            this.label21.Text = "开始地址";
            // 
            // comboBoxProtocol
            // 
            this.comboBoxProtocol.FormattingEnabled = true;
            this.comboBoxProtocol.Items.AddRange(new object[] {
            "TCP/IP",
            "RTU Over TCP/IP"});
            this.comboBoxProtocol.Location = new System.Drawing.Point(70, 329);
            this.comboBoxProtocol.Name = "comboBoxProtocol";
            this.comboBoxProtocol.Size = new System.Drawing.Size(121, 20);
            this.comboBoxProtocol.TabIndex = 7;
            this.comboBoxProtocol.Text = "TCP/IP";
            // 
            // comboBoxBaud
            // 
            this.comboBoxBaud.FormattingEnabled = true;
            this.comboBoxBaud.Items.AddRange(new object[] {
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
            this.comboBoxBaud.Location = new System.Drawing.Point(70, 302);
            this.comboBoxBaud.Name = "comboBoxBaud";
            this.comboBoxBaud.Size = new System.Drawing.Size(121, 20);
            this.comboBoxBaud.TabIndex = 7;
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(70, 376);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(121, 21);
            this.textBoxPort.TabIndex = 1;
            this.textBoxPort.Text = "502";
            // 
            // textBoxIPAddr
            // 
            this.textBoxIPAddr.Location = new System.Drawing.Point(70, 351);
            this.textBoxIPAddr.Name = "textBoxIPAddr";
            this.textBoxIPAddr.Size = new System.Drawing.Size(121, 21);
            this.textBoxIPAddr.TabIndex = 1;
            this.textBoxIPAddr.Text = "0.0.0.0";
            // 
            // buttonTestOutput
            // 
            this.buttonTestOutput.Location = new System.Drawing.Point(248, 437);
            this.buttonTestOutput.Name = "buttonTestOutput";
            this.buttonTestOutput.Size = new System.Drawing.Size(336, 41);
            this.buttonTestOutput.TabIndex = 6;
            this.buttonTestOutput.Text = "输出结果测试";
            this.buttonTestOutput.UseVisualStyleBackColor = true;
            this.buttonTestOutput.Click += new System.EventHandler(this.buttonTestOutput_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(180, 19);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(203, 31);
            this.label18.TabIndex = 7;
            this.label18.Text = "PLC通信测试系统";
            // 
            // labelWarning
            // 
            this.labelWarning.AutoSize = true;
            this.labelWarning.ForeColor = System.Drawing.Color.Red;
            this.labelWarning.Location = new System.Drawing.Point(30, 43);
            this.labelWarning.Name = "labelWarning";
            this.labelWarning.Size = new System.Drawing.Size(29, 12);
            this.labelWarning.TabIndex = 8;
            this.labelWarning.Text = "警告";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.regTextBox2);
            this.groupBox4.Controls.Add(this.regTextBox1);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label25);
            this.groupBox4.Controls.Add(this.label24);
            this.groupBox4.Location = new System.Drawing.Point(29, 42);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(284, 69);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "一号弹";
            // 
            // regTextBox2
            // 
            this.regTextBox2.dataType = PLCModbusSystem.RegTextBox.DataType.dtSingleFloat;
            this.regTextBox2.dtDivValue = 100;
            this.regTextBox2.dtMaxValue = 0;
            this.regTextBox2.dtMinValue = 0;
            this.regTextBox2.floatFmt = PLCModbusSystem.RegTextBox.FloatFMT.FMT_DCBA;
            this.regTextBox2.Location = new System.Drawing.Point(159, 42);
            this.regTextBox2.Name = "regTextBox2";
            this.regTextBox2.ReadOnly = true;
            this.regTextBox2.RegIndex = 10;
            this.regTextBox2.Size = new System.Drawing.Size(102, 21);
            this.regTextBox2.TabIndex = 1;
            // 
            // regTextBox1
            // 
            this.regTextBox1.dataType = PLCModbusSystem.RegTextBox.DataType.dtSingleFloat;
            this.regTextBox1.dtDivValue = 100;
            this.regTextBox1.dtMaxValue = 0;
            this.regTextBox1.dtMinValue = 0;
            this.regTextBox1.floatFmt = PLCModbusSystem.RegTextBox.FloatFMT.FMT_DCBA;
            this.regTextBox1.Location = new System.Drawing.Point(159, 14);
            this.regTextBox1.Name = "regTextBox1";
            this.regTextBox1.ReadOnly = true;
            this.regTextBox1.RegIndex = 2;
            this.regTextBox1.Size = new System.Drawing.Size(102, 21);
            this.regTextBox1.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(25, 47);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "最大压力";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "测试时间";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(84, 47);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(41, 12);
            this.label25.TabIndex = 0;
            this.label25.Text = "(0000)";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(84, 17);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(41, 12);
            this.label24.TabIndex = 0;
            this.label24.Text = "(0000)";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(54, 24);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(53, 12);
            this.label20.TabIndex = 0;
            this.label20.Text = "测试结果";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.regTextBox4);
            this.groupBox5.Controls.Add(this.regTextBox3);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.label27);
            this.groupBox5.Controls.Add(this.label26);
            this.groupBox5.Location = new System.Drawing.Point(29, 119);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(284, 69);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "二号弹";
            // 
            // regTextBox4
            // 
            this.regTextBox4.dataType = PLCModbusSystem.RegTextBox.DataType.dtSingleFloat;
            this.regTextBox4.dtDivValue = 100;
            this.regTextBox4.dtMaxValue = 0;
            this.regTextBox4.dtMinValue = 0;
            this.regTextBox4.floatFmt = PLCModbusSystem.RegTextBox.FloatFMT.FMT_DCBA;
            this.regTextBox4.Location = new System.Drawing.Point(159, 44);
            this.regTextBox4.Name = "regTextBox4";
            this.regTextBox4.ReadOnly = true;
            this.regTextBox4.RegIndex = 12;
            this.regTextBox4.Size = new System.Drawing.Size(102, 21);
            this.regTextBox4.TabIndex = 1;
            // 
            // regTextBox3
            // 
            this.regTextBox3.dataType = PLCModbusSystem.RegTextBox.DataType.dtSingleFloat;
            this.regTextBox3.dtDivValue = 100;
            this.regTextBox3.dtMaxValue = 0;
            this.regTextBox3.dtMinValue = 0;
            this.regTextBox3.floatFmt = PLCModbusSystem.RegTextBox.FloatFMT.FMT_DCBA;
            this.regTextBox3.Location = new System.Drawing.Point(159, 14);
            this.regTextBox3.Name = "regTextBox3";
            this.regTextBox3.ReadOnly = true;
            this.regTextBox3.RegIndex = 4;
            this.regTextBox3.Size = new System.Drawing.Size(102, 21);
            this.regTextBox3.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(25, 47);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "最大压力";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(25, 17);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 0;
            this.label12.Text = "测试时间";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(84, 47);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(41, 12);
            this.label27.TabIndex = 0;
            this.label27.Text = "(0000)";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(84, 17);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(41, 12);
            this.label26.TabIndex = 0;
            this.label26.Text = "(0000)";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.regTextBox6);
            this.groupBox6.Controls.Add(this.regTextBox5);
            this.groupBox6.Controls.Add(this.label13);
            this.groupBox6.Controls.Add(this.label14);
            this.groupBox6.Controls.Add(this.label29);
            this.groupBox6.Controls.Add(this.label28);
            this.groupBox6.Location = new System.Drawing.Point(29, 199);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(284, 69);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "三号弹";
            // 
            // regTextBox6
            // 
            this.regTextBox6.dataType = PLCModbusSystem.RegTextBox.DataType.dtSingleFloat;
            this.regTextBox6.dtDivValue = 100;
            this.regTextBox6.dtMaxValue = 0;
            this.regTextBox6.dtMinValue = 0;
            this.regTextBox6.floatFmt = PLCModbusSystem.RegTextBox.FloatFMT.FMT_DCBA;
            this.regTextBox6.Location = new System.Drawing.Point(159, 44);
            this.regTextBox6.Name = "regTextBox6";
            this.regTextBox6.ReadOnly = true;
            this.regTextBox6.RegIndex = 14;
            this.regTextBox6.Size = new System.Drawing.Size(102, 21);
            this.regTextBox6.TabIndex = 1;
            // 
            // regTextBox5
            // 
            this.regTextBox5.dataType = PLCModbusSystem.RegTextBox.DataType.dtSingleFloat;
            this.regTextBox5.dtDivValue = 100;
            this.regTextBox5.dtMaxValue = 0;
            this.regTextBox5.dtMinValue = 0;
            this.regTextBox5.floatFmt = PLCModbusSystem.RegTextBox.FloatFMT.FMT_DCBA;
            this.regTextBox5.Location = new System.Drawing.Point(159, 14);
            this.regTextBox5.Name = "regTextBox5";
            this.regTextBox5.ReadOnly = true;
            this.regTextBox5.RegIndex = 6;
            this.regTextBox5.Size = new System.Drawing.Size(102, 21);
            this.regTextBox5.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(25, 47);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 0;
            this.label13.Text = "最大压力";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(25, 17);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 0;
            this.label14.Text = "测试时间";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(84, 47);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(41, 12);
            this.label29.TabIndex = 0;
            this.label29.Text = "(0000)";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(84, 17);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(41, 12);
            this.label28.TabIndex = 0;
            this.label28.Text = "(0000)";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.regTextBox8);
            this.groupBox7.Controls.Add(this.regTextBox7);
            this.groupBox7.Controls.Add(this.label15);
            this.groupBox7.Controls.Add(this.label16);
            this.groupBox7.Controls.Add(this.label31);
            this.groupBox7.Controls.Add(this.label30);
            this.groupBox7.Location = new System.Drawing.Point(29, 279);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(284, 69);
            this.groupBox7.TabIndex = 2;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "四号弹";
            // 
            // regTextBox8
            // 
            this.regTextBox8.dataType = PLCModbusSystem.RegTextBox.DataType.dtSingleFloat;
            this.regTextBox8.dtDivValue = 100;
            this.regTextBox8.dtMaxValue = 0;
            this.regTextBox8.dtMinValue = 0;
            this.regTextBox8.floatFmt = PLCModbusSystem.RegTextBox.FloatFMT.FMT_DCBA;
            this.regTextBox8.Location = new System.Drawing.Point(159, 44);
            this.regTextBox8.Name = "regTextBox8";
            this.regTextBox8.ReadOnly = true;
            this.regTextBox8.RegIndex = 16;
            this.regTextBox8.Size = new System.Drawing.Size(102, 21);
            this.regTextBox8.TabIndex = 1;
            // 
            // regTextBox7
            // 
            this.regTextBox7.dataType = PLCModbusSystem.RegTextBox.DataType.dtSingleFloat;
            this.regTextBox7.dtDivValue = 100;
            this.regTextBox7.dtMaxValue = 0;
            this.regTextBox7.dtMinValue = 0;
            this.regTextBox7.floatFmt = PLCModbusSystem.RegTextBox.FloatFMT.FMT_DCBA;
            this.regTextBox7.Location = new System.Drawing.Point(159, 14);
            this.regTextBox7.Name = "regTextBox7";
            this.regTextBox7.ReadOnly = true;
            this.regTextBox7.RegIndex = 8;
            this.regTextBox7.Size = new System.Drawing.Size(102, 21);
            this.regTextBox7.TabIndex = 1;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(25, 47);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 0;
            this.label15.Text = "最大压力";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(25, 17);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 12);
            this.label16.TabIndex = 0;
            this.label16.Text = "测试时间";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(84, 47);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(41, 12);
            this.label31.TabIndex = 0;
            this.label31.Text = "(0000)";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(84, 17);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(41, 12);
            this.label30.TabIndex = 0;
            this.label30.Text = "(0000)";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox7);
            this.groupBox3.Controls.Add(this.regTextBoxResult);
            this.groupBox3.Controls.Add(this.groupBox6);
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Location = new System.Drawing.Point(248, 70);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(336, 358);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "实时结果";
            // 
            // regTextBoxResult
            // 
            this.regTextBoxResult.dataType = PLCModbusSystem.RegTextBox.DataType.dtSingleFloat;
            this.regTextBoxResult.dtDivValue = 100;
            this.regTextBoxResult.dtMaxValue = 0;
            this.regTextBoxResult.dtMinValue = 0;
            this.regTextBoxResult.floatFmt = PLCModbusSystem.RegTextBox.FloatFMT.FMT_DCBA;
            this.regTextBoxResult.Location = new System.Drawing.Point(188, 21);
            this.regTextBoxResult.Name = "regTextBoxResult";
            this.regTextBoxResult.ReadOnly = true;
            this.regTextBoxResult.RegIndex = 0;
            this.regTextBoxResult.Size = new System.Drawing.Size(102, 21);
            this.regTextBoxResult.TabIndex = 1;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(113, 24);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(41, 12);
            this.label23.TabIndex = 0;
            this.label23.Text = "(0000)";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 601);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.labelWarning);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.buttonTestOutput);
            this.Controls.Add(this.textBoxUserName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxOilID);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxOilName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxAnalysis);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxLabName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxDevID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxDevName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "PLCCommSystem";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDevName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxDevID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxLabName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxAnalysis;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxOilName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxOilID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.CheckBox checkBoxExcel;
        private System.Windows.Forms.CheckBox checkBoxLims;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonTestOutput;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox comboBoxSerialPort;
        private System.Windows.Forms.Button buttonSaveSettings;
        private System.Windows.Forms.ComboBox comboBoxBaud;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label labelWarning;
        private System.Windows.Forms.GroupBox groupBox4;
        private RegTextBox regTextBox2;
        private RegTextBox regTextBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.GroupBox groupBox5;
        private RegTextBox regTextBox4;
        private RegTextBox regTextBox3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox6;
        private RegTextBox regTextBox6;
        private RegTextBox regTextBox5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private RegTextBox regTextBoxResult;
        private System.Windows.Forms.GroupBox groupBox7;
        private RegTextBox regTextBox8;
        private RegTextBox regTextBox7;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox comboBoxFormat;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxStartAddr;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RadioButton radioButtonNetwork;
        private System.Windows.Forms.RadioButton radioButtonSerial;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.ComboBox comboBoxProtocol;
        private System.Windows.Forms.TextBox textBoxPort;
        private IPAddrTextBox textBoxIPAddr;
    }
}

