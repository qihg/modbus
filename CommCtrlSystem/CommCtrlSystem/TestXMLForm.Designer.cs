namespace CommCtrlSystem
{
    partial class TestXMLForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textUserName = new System.Windows.Forms.TextBox();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.textAnalysis = new System.Windows.Forms.TextBox();
            this.textResult = new System.Windows.Forms.TextBox();
            this.btnTestXML = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 68);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "密码";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 101);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "分析方法";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 167);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "结果";
            // 
            // textUserName
            // 
            this.textUserName.Location = new System.Drawing.Point(128, 31);
            this.textUserName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textUserName.Name = "textUserName";
            this.textUserName.Size = new System.Drawing.Size(149, 21);
            this.textUserName.TabIndex = 1;
            this.textUserName.Text = "test";
            this.textUserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textPassword
            // 
            this.textPassword.Location = new System.Drawing.Point(128, 64);
            this.textPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textPassword.Name = "textPassword";
            this.textPassword.Size = new System.Drawing.Size(149, 21);
            this.textPassword.TabIndex = 2;
            this.textPassword.Text = "123456";
            this.textPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textAnalysis
            // 
            this.textAnalysis.Location = new System.Drawing.Point(128, 97);
            this.textAnalysis.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textAnalysis.Name = "textAnalysis";
            this.textAnalysis.Size = new System.Drawing.Size(149, 21);
            this.textAnalysis.TabIndex = 3;
            this.textAnalysis.Text = "System";
            this.textAnalysis.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textResult
            // 
            this.textResult.Location = new System.Drawing.Point(128, 163);
            this.textResult.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textResult.Name = "textResult";
            this.textResult.Size = new System.Drawing.Size(149, 21);
            this.textResult.TabIndex = 5;
            this.textResult.Text = "100";
            this.textResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnTestXML
            // 
            this.btnTestXML.Location = new System.Drawing.Point(40, 196);
            this.btnTestXML.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTestXML.Name = "btnTestXML";
            this.btnTestXML.Size = new System.Drawing.Size(83, 60);
            this.btnTestXML.TabIndex = 6;
            this.btnTestXML.Text = "生成XML";
            this.btnTestXML.UseVisualStyleBackColor = true;
            this.btnTestXML.Click += new System.EventHandler(this.btnTestXML_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(196, 196);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 60);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 134);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "序号";
            // 
            // textID
            // 
            this.textID.Location = new System.Drawing.Point(128, 130);
            this.textID.Margin = new System.Windows.Forms.Padding(4);
            this.textID.Name = "textID";
            this.textID.Size = new System.Drawing.Size(149, 21);
            this.textID.TabIndex = 4;
            this.textID.Text = "1";
            this.textID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TestXMLForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 289);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnTestXML);
            this.Controls.Add(this.textID);
            this.Controls.Add(this.textResult);
            this.Controls.Add(this.textAnalysis);
            this.Controls.Add(this.textPassword);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textUserName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "TestXMLForm";
            this.Text = "TestXMLForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textUserName;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.TextBox textAnalysis;
        private System.Windows.Forms.TextBox textResult;
        private System.Windows.Forms.Button btnTestXML;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textID;
    }
}