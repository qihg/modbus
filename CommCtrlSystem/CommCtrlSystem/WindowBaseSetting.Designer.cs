namespace CommCtrlSystem
{
    partial class WindowBaseSetting
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonMain = new System.Windows.Forms.Button();
            this.buttonRead = new System.Windows.Forms.Button();
            this.buttonWrite = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.regTextBox10 = new CommCtrlSystem.RegTextBox();
            this.regTextBox9 = new CommCtrlSystem.RegTextBox();
            this.regTextBox8 = new CommCtrlSystem.RegTextBox();
            this.regTextBox7 = new CommCtrlSystem.RegTextBox();
            this.regTextBox6 = new CommCtrlSystem.RegTextBox();
            this.regTextBox5 = new CommCtrlSystem.RegTextBox();
            this.regTextBox4 = new CommCtrlSystem.RegTextBox();
            this.regTextBox3 = new CommCtrlSystem.RegTextBox();
            this.regTextBox2 = new CommCtrlSystem.RegTextBox();
            this.regTextBox1 = new CommCtrlSystem.RegTextBox();
            this.SuspendLayout();
            // 
            // buttonMain
            // 
            this.buttonMain.Location = new System.Drawing.Point(630, 409);
            this.buttonMain.Name = "buttonMain";
            this.buttonMain.Size = new System.Drawing.Size(86, 40);
            this.buttonMain.TabIndex = 0;
            this.buttonMain.Text = "返回主界面";
            this.buttonMain.UseVisualStyleBackColor = true;
            this.buttonMain.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonRead
            // 
            this.buttonRead.Location = new System.Drawing.Point(50, 409);
            this.buttonRead.Name = "buttonRead";
            this.buttonRead.Size = new System.Drawing.Size(86, 40);
            this.buttonRead.TabIndex = 0;
            this.buttonRead.Text = "读取";
            this.buttonRead.UseVisualStyleBackColor = true;
            this.buttonRead.Click += new System.EventHandler(this.buttonRead_Click);
            // 
            // buttonWrite
            // 
            this.buttonWrite.Location = new System.Drawing.Point(152, 409);
            this.buttonWrite.Name = "buttonWrite";
            this.buttonWrite.Size = new System.Drawing.Size(86, 40);
            this.buttonWrite.TabIndex = 0;
            this.buttonWrite.Text = "写入";
            this.buttonWrite.UseVisualStyleBackColor = true;
            this.buttonWrite.Click += new System.EventHandler(this.buttonWrite_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(67, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "预期冷滤点";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SimHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(67, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 89;
            this.label2.Text = "测定下限";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("SimHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(67, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 16);
            this.label3.TabIndex = 89;
            this.label3.Text = "恢复加热速度";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("SimHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(67, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 89;
            this.label4.Text = "清洗次数";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("SimHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(67, 273);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 16);
            this.label5.TabIndex = 89;
            this.label5.Text = "取消下限检测";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("SimHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(409, 273);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 16);
            this.label6.TabIndex = 93;
            this.label6.Text = "取消下限检测";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("SimHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(409, 219);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 16);
            this.label7.TabIndex = 92;
            this.label7.Text = "清洗次数";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("SimHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(409, 165);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 16);
            this.label8.TabIndex = 94;
            this.label8.Text = "恢复加热速度";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("SimHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(409, 111);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 16);
            this.label9.TabIndex = 95;
            this.label9.Text = "测定下限";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("SimHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(409, 57);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 16);
            this.label10.TabIndex = 91;
            this.label10.Text = "预期冷滤点";
            // 
            // regTextBox10
            // 
            this.regTextBox10.dataType = CommCtrlSystem.RegTextBox.DataType.dtLByte;
            this.regTextBox10.dtDivValue = 1;
            this.regTextBox10.dtMaxValue = 20;
            this.regTextBox10.dtMinValue = 0;
            this.regTextBox10.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.regTextBox10.Location = new System.Drawing.Point(531, 259);
            this.regTextBox10.Name = "regTextBox10";
            this.regTextBox10.RegIndex = 7;
            this.regTextBox10.Size = new System.Drawing.Size(100, 39);
            this.regTextBox10.TabIndex = 101;
            this.regTextBox10.Text = "0";
            this.regTextBox10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // regTextBox9
            // 
            this.regTextBox9.dataType = CommCtrlSystem.RegTextBox.DataType.dtLByte;
            this.regTextBox9.dtDivValue = 1;
            this.regTextBox9.dtMaxValue = 0;
            this.regTextBox9.dtMinValue = 0;
            this.regTextBox9.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.regTextBox9.Location = new System.Drawing.Point(531, 209);
            this.regTextBox9.Name = "regTextBox9";
            this.regTextBox9.RegIndex = 6;
            this.regTextBox9.Size = new System.Drawing.Size(100, 39);
            this.regTextBox9.TabIndex = 101;
            this.regTextBox9.Text = "0";
            this.regTextBox9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // regTextBox8
            // 
            this.regTextBox8.dataType = CommCtrlSystem.RegTextBox.DataType.dtShort;
            this.regTextBox8.dtDivValue = 1;
            this.regTextBox8.dtMaxValue = 0;
            this.regTextBox8.dtMinValue = 0;
            this.regTextBox8.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.regTextBox8.Location = new System.Drawing.Point(531, 155);
            this.regTextBox8.Name = "regTextBox8";
            this.regTextBox8.RegIndex = 5;
            this.regTextBox8.Size = new System.Drawing.Size(100, 39);
            this.regTextBox8.TabIndex = 101;
            this.regTextBox8.Text = "0";
            this.regTextBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // regTextBox7
            // 
            this.regTextBox7.dataType = CommCtrlSystem.RegTextBox.DataType.dtShort;
            this.regTextBox7.dtDivValue = 1;
            this.regTextBox7.dtMaxValue = 0;
            this.regTextBox7.dtMinValue = 0;
            this.regTextBox7.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.regTextBox7.Location = new System.Drawing.Point(531, 101);
            this.regTextBox7.Name = "regTextBox7";
            this.regTextBox7.RegIndex = 3;
            this.regTextBox7.Size = new System.Drawing.Size(100, 39);
            this.regTextBox7.TabIndex = 101;
            this.regTextBox7.Text = "0";
            this.regTextBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // regTextBox6
            // 
            this.regTextBox6.dataType = CommCtrlSystem.RegTextBox.DataType.dtShort;
            this.regTextBox6.dtDivValue = 1;
            this.regTextBox6.dtMaxValue = 0;
            this.regTextBox6.dtMinValue = 0;
            this.regTextBox6.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.regTextBox6.Location = new System.Drawing.Point(531, 43);
            this.regTextBox6.Name = "regTextBox6";
            this.regTextBox6.RegIndex = 1;
            this.regTextBox6.Size = new System.Drawing.Size(100, 39);
            this.regTextBox6.TabIndex = 101;
            this.regTextBox6.Text = "0";
            this.regTextBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // regTextBox5
            // 
            this.regTextBox5.dataType = CommCtrlSystem.RegTextBox.DataType.dtHByte;
            this.regTextBox5.dtDivValue = 1;
            this.regTextBox5.dtMaxValue = 0;
            this.regTextBox5.dtMinValue = 0;
            this.regTextBox5.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.regTextBox5.Location = new System.Drawing.Point(210, 263);
            this.regTextBox5.Name = "regTextBox5";
            this.regTextBox5.RegIndex = 7;
            this.regTextBox5.Size = new System.Drawing.Size(100, 39);
            this.regTextBox5.TabIndex = 101;
            this.regTextBox5.Text = "0";
            this.regTextBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // regTextBox4
            // 
            this.regTextBox4.dataType = CommCtrlSystem.RegTextBox.DataType.dtHByte;
            this.regTextBox4.dtDivValue = 1;
            this.regTextBox4.dtMaxValue = 0;
            this.regTextBox4.dtMinValue = 0;
            this.regTextBox4.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.regTextBox4.Location = new System.Drawing.Point(210, 209);
            this.regTextBox4.Name = "regTextBox4";
            this.regTextBox4.RegIndex = 6;
            this.regTextBox4.Size = new System.Drawing.Size(100, 39);
            this.regTextBox4.TabIndex = 101;
            this.regTextBox4.Text = "0";
            this.regTextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // regTextBox3
            // 
            this.regTextBox3.dataType = CommCtrlSystem.RegTextBox.DataType.dtShort;
            this.regTextBox3.dtDivValue = 1;
            this.regTextBox3.dtMaxValue = 0;
            this.regTextBox3.dtMinValue = 0;
            this.regTextBox3.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.regTextBox3.Location = new System.Drawing.Point(210, 155);
            this.regTextBox3.Name = "regTextBox3";
            this.regTextBox3.RegIndex = 4;
            this.regTextBox3.Size = new System.Drawing.Size(100, 39);
            this.regTextBox3.TabIndex = 101;
            this.regTextBox3.Text = "0";
            this.regTextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // regTextBox2
            // 
            this.regTextBox2.dataType = CommCtrlSystem.RegTextBox.DataType.dtShort;
            this.regTextBox2.dtDivValue = 1;
            this.regTextBox2.dtMaxValue = 0;
            this.regTextBox2.dtMinValue = 0;
            this.regTextBox2.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.regTextBox2.Location = new System.Drawing.Point(210, 101);
            this.regTextBox2.Name = "regTextBox2";
            this.regTextBox2.RegIndex = 2;
            this.regTextBox2.Size = new System.Drawing.Size(100, 39);
            this.regTextBox2.TabIndex = 101;
            this.regTextBox2.Text = "0";
            this.regTextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // regTextBox1
            // 
            this.regTextBox1.dataType = CommCtrlSystem.RegTextBox.DataType.dtShort;
            this.regTextBox1.dtDivValue = 1;
            this.regTextBox1.dtMaxValue = 0;
            this.regTextBox1.dtMinValue = 0;
            this.regTextBox1.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.regTextBox1.Location = new System.Drawing.Point(210, 47);
            this.regTextBox1.Name = "regTextBox1";
            this.regTextBox1.RegIndex = 0;
            this.regTextBox1.Size = new System.Drawing.Size(100, 39);
            this.regTextBox1.TabIndex = 101;
            this.regTextBox1.Text = "0";
            this.regTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // WindowBaseSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.regTextBox10);
            this.Controls.Add(this.regTextBox9);
            this.Controls.Add(this.regTextBox8);
            this.Controls.Add(this.regTextBox7);
            this.Controls.Add(this.regTextBox6);
            this.Controls.Add(this.regTextBox5);
            this.Controls.Add(this.regTextBox4);
            this.Controls.Add(this.regTextBox3);
            this.Controls.Add(this.regTextBox2);
            this.Controls.Add(this.regTextBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonWrite);
            this.Controls.Add(this.buttonRead);
            this.Controls.Add(this.buttonMain);
            this.Name = "WindowBaseSetting";
            this.Size = new System.Drawing.Size(757, 481);
            this.Load += new System.EventHandler(this.WindowBaseSetting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonMain;
        private System.Windows.Forms.Button buttonRead;
        private System.Windows.Forms.Button buttonWrite;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private RegTextBox regTextBox1;
        private RegTextBox regTextBox2;
        private RegTextBox regTextBox3;
        private RegTextBox regTextBox4;
        private RegTextBox regTextBox5;
        private RegTextBox regTextBox6;
        private RegTextBox regTextBox7;
        private RegTextBox regTextBox8;
        private RegTextBox regTextBox9;
        private RegTextBox regTextBox10;
    }
}
