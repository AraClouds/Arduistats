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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btn_serielConnect = new System.Windows.Forms.Button();
            this.PortInfos = new System.Windows.Forms.Button();
            this.btn_listenToArduino = new System.Windows.Forms.Button();
            this.RichLogBox = new System.Windows.Forms.RichTextBox();
            this.btn_readShit = new System.Windows.Forms.Button();
            this.btn_startphpfetch = new System.Windows.Forms.Button();
            this.text_iSconnected = new System.Windows.Forms.TextBox();
            this.Btn_GetCurPortInfo = new System.Windows.Forms.Button();
            this.RichArduinoIsSpeaking = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.httpStatus = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.TabIndex = 0;
            // 
            // btn_serielConnect
            // 
            this.btn_serielConnect.Location = new System.Drawing.Point(139, 12);
            this.btn_serielConnect.Name = "btn_serielConnect";
            this.btn_serielConnect.Size = new System.Drawing.Size(108, 23);
            this.btn_serielConnect.TabIndex = 1;
            this.btn_serielConnect.Text = "Serial connect";
            this.btn_serielConnect.UseVisualStyleBackColor = true;
            this.btn_serielConnect.Click += new System.EventHandler(this.Btn_serielConnect_Click);
            // 
            // PortInfos
            // 
            this.PortInfos.Location = new System.Drawing.Point(431, 12);
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
            this.btn_listenToArduino.Location = new System.Drawing.Point(94, 61);
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
            this.RichLogBox.Location = new System.Drawing.Point(12, 159);
            this.RichLogBox.Name = "RichLogBox";
            this.RichLogBox.ReadOnly = true;
            this.RichLogBox.Size = new System.Drawing.Size(311, 254);
            this.RichLogBox.TabIndex = 4;
            this.RichLogBox.Text = "";
            // 
            // btn_readShit
            // 
            this.btn_readShit.Enabled = false;
            this.btn_readShit.Location = new System.Drawing.Point(431, 70);
            this.btn_readShit.Name = "btn_readShit";
            this.btn_readShit.Size = new System.Drawing.Size(75, 23);
            this.btn_readShit.TabIndex = 5;
            this.btn_readShit.Text = "Readphpuser";
            this.btn_readShit.UseVisualStyleBackColor = true;
            this.btn_readShit.Click += new System.EventHandler(this.btn_readShit_Click);
            // 
            // btn_startphpfetch
            // 
            this.btn_startphpfetch.Location = new System.Drawing.Point(431, 41);
            this.btn_startphpfetch.Name = "btn_startphpfetch";
            this.btn_startphpfetch.Size = new System.Drawing.Size(75, 23);
            this.btn_startphpfetch.TabIndex = 6;
            this.btn_startphpfetch.Text = "Start php loop";
            this.btn_startphpfetch.UseVisualStyleBackColor = true;
            this.btn_startphpfetch.Click += new System.EventHandler(this.Btn_StartPHPfetch_Click);
            // 
            // text_iSconnected
            // 
            this.text_iSconnected.Location = new System.Drawing.Point(253, 12);
            this.text_iSconnected.Name = "text_iSconnected";
            this.text_iSconnected.Size = new System.Drawing.Size(100, 23);
            this.text_iSconnected.TabIndex = 7;
            // 
            // Btn_GetCurPortInfo
            // 
            this.Btn_GetCurPortInfo.Enabled = false;
            this.Btn_GetCurPortInfo.Location = new System.Drawing.Point(13, 61);
            this.Btn_GetCurPortInfo.Name = "Btn_GetCurPortInfo";
            this.Btn_GetCurPortInfo.Size = new System.Drawing.Size(75, 23);
            this.Btn_GetCurPortInfo.TabIndex = 8;
            this.Btn_GetCurPortInfo.Text = "COM Info";
            this.Btn_GetCurPortInfo.UseVisualStyleBackColor = true;
            this.Btn_GetCurPortInfo.Click += new System.EventHandler(this.Btn_GetCurPortInfo_Click);
            // 
            // RichArduinoIsSpeaking
            // 
            this.RichArduinoIsSpeaking.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RichArduinoIsSpeaking.Location = new System.Drawing.Point(12, 496);
            this.RichArduinoIsSpeaking.Name = "RichArduinoIsSpeaking";
            this.RichArduinoIsSpeaking.ReadOnly = true;
            this.RichArduinoIsSpeaking.Size = new System.Drawing.Size(275, 80);
            this.RichArduinoIsSpeaking.TabIndex = 9;
            this.RichArduinoIsSpeaking.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 478);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "is Arduino speaking ? (Serial.write)";
            // 
            // httpStatus
            // 
            this.httpStatus.Location = new System.Drawing.Point(13, 420);
            this.httpStatus.Name = "httpStatus";
            this.httpStatus.Size = new System.Drawing.Size(53, 23);
            this.httpStatus.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 423);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "HTTP STATUS";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 588);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.httpStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RichArduinoIsSpeaking);
            this.Controls.Add(this.Btn_GetCurPortInfo);
            this.Controls.Add(this.text_iSconnected);
            this.Controls.Add(this.btn_startphpfetch);
            this.Controls.Add(this.btn_readShit);
            this.Controls.Add(this.RichLogBox);
            this.Controls.Add(this.btn_listenToArduino);
            this.Controls.Add(this.PortInfos);
            this.Controls.Add(this.btn_serielConnect);
            this.Controls.Add(this.comboBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Arduistats - Araclouds";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btn_serielConnect;
        private System.Windows.Forms.Button PortInfos;
        private System.Windows.Forms.Button btn_listenToArduino;
        private System.Windows.Forms.RichTextBox RichLogBox;
        private System.Windows.Forms.Button btn_readShit;
        private System.Windows.Forms.Button btn_startphpfetch;
        private System.Windows.Forms.TextBox text_iSconnected;
        private System.Windows.Forms.Button Btn_GetCurPortInfo;
        private System.Windows.Forms.RichTextBox RichArduinoIsSpeaking;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox httpStatus;
        private System.Windows.Forms.Label label2;
    }
}

