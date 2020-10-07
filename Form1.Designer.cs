namespace Arduistats
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.listPort = new System.Windows.Forms.ComboBox();
            this.btn_serielConnect = new System.Windows.Forms.Button();
            this.PortInfos = new System.Windows.Forms.Button();
            this.btn_listenToArduino = new System.Windows.Forms.Button();
            this.RichLogBox = new System.Windows.Forms.RichTextBox();
            this.btn_startphpfetch = new System.Windows.Forms.Button();
            this.text_iSconnected = new System.Windows.Forms.TextBox();
            this.Btn_GetCurPortInfo = new System.Windows.Forms.Button();
            this.httpStatus = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_httpTickRate = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Input_UserTimeout = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Inp_Domain = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Inp_NumericHours = new System.Windows.Forms.NumericUpDown();
            this.BtnVerifyUsrUrl = new System.Windows.Forms.Button();
            this.ClearDomain = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.TitleBar = new System.Windows.Forms.Panel();
            this.Arduistats = new System.Windows.Forms.Label();
            this.LaBouleMagique = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Inp_NumericHours)).BeginInit();
            this.TitleBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // listPort
            // 
            this.listPort.BackColor = System.Drawing.Color.White;
            this.listPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listPort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.listPort.FormattingEnabled = true;
            this.listPort.Location = new System.Drawing.Point(13, 116);
            this.listPort.Name = "listPort";
            this.listPort.Size = new System.Drawing.Size(121, 23);
            this.listPort.TabIndex = 0;
            this.listPort.SelectedIndexChanged += new System.EventHandler(this.listPort_SelectedIndexChanged);
            // 
            // btn_serielConnect
            // 
            this.btn_serielConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_serielConnect.Location = new System.Drawing.Point(139, 116);
            this.btn_serielConnect.Name = "btn_serielConnect";
            this.btn_serielConnect.Size = new System.Drawing.Size(108, 23);
            this.btn_serielConnect.TabIndex = 1;
            this.btn_serielConnect.Text = "Serial connect";
            this.btn_serielConnect.UseVisualStyleBackColor = true;
            this.btn_serielConnect.Click += new System.EventHandler(this.Btn_serielConnect_Click);
            // 
            // PortInfos
            // 
            this.PortInfos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PortInfos.Location = new System.Drawing.Point(353, 414);
            this.PortInfos.Name = "PortInfos";
            this.PortInfos.Size = new System.Drawing.Size(75, 23);
            this.PortInfos.TabIndex = 2;
            this.PortInfos.Text = "Info ports";
            this.PortInfos.UseVisualStyleBackColor = true;
            this.PortInfos.Click += new System.EventHandler(this.PortInfos_Click);
            // 
            // btn_listenToArduino
            // 
            this.btn_listenToArduino.Enabled = false;
            this.btn_listenToArduino.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_listenToArduino.Location = new System.Drawing.Point(521, 385);
            this.btn_listenToArduino.Name = "btn_listenToArduino";
            this.btn_listenToArduino.Size = new System.Drawing.Size(75, 23);
            this.btn_listenToArduino.TabIndex = 3;
            this.btn_listenToArduino.Text = "listen";
            this.btn_listenToArduino.UseVisualStyleBackColor = true;
            this.btn_listenToArduino.Click += new System.EventHandler(this.Btn_listenToArduino_Click);
            // 
            // RichLogBox
            // 
            this.RichLogBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.RichLogBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RichLogBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RichLogBox.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.RichLogBox.Location = new System.Drawing.Point(12, 144);
            this.RichLogBox.Name = "RichLogBox";
            this.RichLogBox.ReadOnly = true;
            this.RichLogBox.Size = new System.Drawing.Size(311, 252);
            this.RichLogBox.TabIndex = 4;
            this.RichLogBox.Text = "";
            // 
            // btn_startphpfetch
            // 
            this.btn_startphpfetch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_startphpfetch.Location = new System.Drawing.Point(434, 414);
            this.btn_startphpfetch.Name = "btn_startphpfetch";
            this.btn_startphpfetch.Size = new System.Drawing.Size(75, 23);
            this.btn_startphpfetch.TabIndex = 6;
            this.btn_startphpfetch.Text = "Start php loop";
            this.btn_startphpfetch.UseVisualStyleBackColor = true;
            this.btn_startphpfetch.Click += new System.EventHandler(this.Btn_StartPHPfetch_Click);
            // 
            // text_iSconnected
            // 
            this.text_iSconnected.Location = new System.Drawing.Point(253, 116);
            this.text_iSconnected.Name = "text_iSconnected";
            this.text_iSconnected.Size = new System.Drawing.Size(70, 23);
            this.text_iSconnected.TabIndex = 7;
            // 
            // Btn_GetCurPortInfo
            // 
            this.Btn_GetCurPortInfo.Enabled = false;
            this.Btn_GetCurPortInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_GetCurPortInfo.Location = new System.Drawing.Point(353, 385);
            this.Btn_GetCurPortInfo.Name = "Btn_GetCurPortInfo";
            this.Btn_GetCurPortInfo.Size = new System.Drawing.Size(116, 23);
            this.Btn_GetCurPortInfo.TabIndex = 8;
            this.Btn_GetCurPortInfo.Text = "Cur port Info";
            this.Btn_GetCurPortInfo.UseVisualStyleBackColor = true;
            this.Btn_GetCurPortInfo.Click += new System.EventHandler(this.Btn_GetCurPortInfo_Click);
            // 
            // httpStatus
            // 
            this.httpStatus.Location = new System.Drawing.Point(13, 415);
            this.httpStatus.Name = "httpStatus";
            this.httpStatus.Size = new System.Drawing.Size(53, 23);
            this.httpStatus.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 419);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "HTTP STATUS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(353, 339);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 28);
            this.label3.TabIndex = 13;
            this.label3.Text = "Toolbox";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(353, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 28);
            this.label4.TabIndex = 13;
            this.label4.Text = "Setup";
            // 
            // comboBox_httpTickRate
            // 
            this.comboBox_httpTickRate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox_httpTickRate.FormattingEnabled = true;
            this.comboBox_httpTickRate.Location = new System.Drawing.Point(353, 157);
            this.comboBox_httpTickRate.Name = "comboBox_httpTickRate";
            this.comboBox_httpTickRate.Size = new System.Drawing.Size(63, 23);
            this.comboBox_httpTickRate.TabIndex = 14;
            this.comboBox_httpTickRate.Text = "3000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(422, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 15);
            this.label5.TabIndex = 15;
            this.label5.Text = "HTTP Tick rate";
            // 
            // Input_UserTimeout
            // 
            this.Input_UserTimeout.Location = new System.Drawing.Point(353, 186);
            this.Input_UserTimeout.MaxLength = 3;
            this.Input_UserTimeout.Name = "Input_UserTimeout";
            this.Input_UserTimeout.Size = new System.Drawing.Size(63, 23);
            this.Input_UserTimeout.TabIndex = 16;
            this.Input_UserTimeout.Text = "50";
            this.Input_UserTimeout.TextChanged += new System.EventHandler(this.Input_UserTimeout_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(422, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(153, 15);
            this.label6.TabIndex = 17;
            this.label6.Text = "secs to consider user offline";
            // 
            // Inp_Domain
            // 
            this.Inp_Domain.Location = new System.Drawing.Point(353, 99);
            this.Inp_Domain.Name = "Inp_Domain";
            this.Inp_Domain.PlaceholderText = "https://yourdomain.com";
            this.Inp_Domain.Size = new System.Drawing.Size(243, 23);
            this.Inp_Domain.TabIndex = 20;
            this.Inp_Domain.TextChanged += new System.EventHandler(this.Inp_Domain_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Gray;
            this.label8.Location = new System.Drawing.Point(441, 350);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 15);
            this.label8.TabIndex = 21;
            this.label8.Text = "At your own risk";
            // 
            // Inp_NumericHours
            // 
            this.Inp_NumericHours.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Inp_NumericHours.Location = new System.Drawing.Point(353, 215);
            this.Inp_NumericHours.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.Inp_NumericHours.Minimum = new decimal(new int[] {
            12,
            0,
            0,
            -2147483648});
            this.Inp_NumericHours.Name = "Inp_NumericHours";
            this.Inp_NumericHours.Size = new System.Drawing.Size(63, 19);
            this.Inp_NumericHours.TabIndex = 23;
            this.Inp_NumericHours.ValueChanged += new System.EventHandler(this.Inp_NumericHours_ValueChanged);
            // 
            // BtnVerifyUsrUrl
            // 
            this.BtnVerifyUsrUrl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnVerifyUsrUrl.Location = new System.Drawing.Point(353, 129);
            this.BtnVerifyUsrUrl.Name = "BtnVerifyUsrUrl";
            this.BtnVerifyUsrUrl.Size = new System.Drawing.Size(170, 23);
            this.BtnVerifyUsrUrl.TabIndex = 24;
            this.BtnVerifyUsrUrl.Text = "Verify";
            this.BtnVerifyUsrUrl.UseVisualStyleBackColor = true;
            this.BtnVerifyUsrUrl.Click += new System.EventHandler(this.BtnVerifyUsrUrl_Click);
            // 
            // ClearDomain
            // 
            this.ClearDomain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearDomain.Location = new System.Drawing.Point(529, 129);
            this.ClearDomain.Name = "ClearDomain";
            this.ClearDomain.Size = new System.Drawing.Size(67, 23);
            this.ClearDomain.TabIndex = 25;
            this.ClearDomain.Text = "clr";
            this.ClearDomain.UseVisualStyleBackColor = true;
            this.ClearDomain.Click += new System.EventHandler(this.ClearDomain_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(422, 219);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "+/- H | adjust time server";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Indigo;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(561, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(44, 38);
            this.button1.TabIndex = 26;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TitleBar
            // 
            this.TitleBar.BackColor = System.Drawing.Color.Indigo;
            this.TitleBar.Controls.Add(this.Arduistats);
            this.TitleBar.Controls.Add(this.button1);
            this.TitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleBar.Location = new System.Drawing.Point(0, 0);
            this.TitleBar.Name = "TitleBar";
            this.TitleBar.Size = new System.Drawing.Size(605, 38);
            this.TitleBar.TabIndex = 27;
            this.TitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseDown);
            // 
            // Arduistats
            // 
            this.Arduistats.AutoSize = true;
            this.Arduistats.Font = new System.Drawing.Font("Montserrat", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Arduistats.ForeColor = System.Drawing.Color.Thistle;
            this.Arduistats.Location = new System.Drawing.Point(0, 3);
            this.Arduistats.Name = "Arduistats";
            this.Arduistats.Size = new System.Drawing.Size(120, 29);
            this.Arduistats.TabIndex = 27;
            this.Arduistats.Text = "Arduistats";
            // 
            // LaBouleMagique
            // 
            this.LaBouleMagique.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LaBouleMagique.Location = new System.Drawing.Point(353, 262);
            this.LaBouleMagique.Name = "LaBouleMagique";
            this.LaBouleMagique.Size = new System.Drawing.Size(243, 56);
            this.LaBouleMagique.TabIndex = 28;
            this.LaBouleMagique.Text = "Start";
            this.LaBouleMagique.UseVisualStyleBackColor = true;
            this.LaBouleMagique.Click += new System.EventHandler(this.LaBouleMagique_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Roboto Mono", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(139, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 29);
            this.label7.TabIndex = 29;
            this.label7.Text = "2";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(353, 233);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(33, 23);
            this.textBox1.TabIndex = 30;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(521, 414);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 31;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(605, 453);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.LaBouleMagique);
            this.Controls.Add(this.listPort);
            this.Controls.Add(this.TitleBar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ClearDomain);
            this.Controls.Add(this.BtnVerifyUsrUrl);
            this.Controls.Add(this.Inp_NumericHours);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Inp_Domain);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Input_UserTimeout);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox_httpTickRate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.httpStatus);
            this.Controls.Add(this.Btn_GetCurPortInfo);
            this.Controls.Add(this.text_iSconnected);
            this.Controls.Add(this.btn_startphpfetch);
            this.Controls.Add(this.RichLogBox);
            this.Controls.Add(this.btn_listenToArduino);
            this.Controls.Add(this.PortInfos);
            this.Controls.Add(this.btn_serielConnect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Arduistats";
            ((System.ComponentModel.ISupportInitialize)(this.Inp_NumericHours)).EndInit();
            this.TitleBar.ResumeLayout(false);
            this.TitleBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox listPort;
        private System.Windows.Forms.Button btn_serielConnect;
        private System.Windows.Forms.Button PortInfos;
        private System.Windows.Forms.Button btn_listenToArduino;
        private System.Windows.Forms.RichTextBox RichLogBox;
        private System.Windows.Forms.Button btn_startphpfetch;
        private System.Windows.Forms.TextBox text_iSconnected;
        private System.Windows.Forms.Button Btn_GetCurPortInfo;
        private System.Windows.Forms.TextBox httpStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_httpTickRate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Input_UserTimeout;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Inp_Domain;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown Inp_NumericHours;
        private System.Windows.Forms.Button BtnVerifyUsrUrl;
        private System.Windows.Forms.Button ClearDomain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel TitleBar;
        private System.Windows.Forms.Label Arduistats;
        private System.Windows.Forms.Button LaBouleMagique;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
    }
}

