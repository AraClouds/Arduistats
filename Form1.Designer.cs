namespace Arduistats
{
    partial class Form1
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
            this.write = new System.Windows.Forms.Button();
            this.RichLogBox = new System.Windows.Forms.RichTextBox();
            this.btn_readShit = new System.Windows.Forms.Button();
            this.btn_startphpfetch = new System.Windows.Forms.Button();
            this.text_iSconnected = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
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
            this.btn_serielConnect.Click += new System.EventHandler(this.btn_serielConnect_Click);
            // 
            // PortInfos
            // 
            this.PortInfos.Location = new System.Drawing.Point(758, 12);
            this.PortInfos.Name = "PortInfos";
            this.PortInfos.Size = new System.Drawing.Size(75, 23);
            this.PortInfos.TabIndex = 2;
            this.PortInfos.Text = "Info ports";
            this.PortInfos.UseVisualStyleBackColor = true;
            this.PortInfos.Click += new System.EventHandler(this.PortInfos_Click);
            // 
            // write
            // 
            this.write.Location = new System.Drawing.Point(588, 12);
            this.write.Name = "write";
            this.write.Size = new System.Drawing.Size(75, 23);
            this.write.TabIndex = 3;
            this.write.Text = "write";
            this.write.UseVisualStyleBackColor = true;
            this.write.Click += new System.EventHandler(this.write_Click);
            // 
            // RichLogBox
            // 
            this.RichLogBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.RichLogBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RichLogBox.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.RichLogBox.Location = new System.Drawing.Point(12, 159);
            this.RichLogBox.Name = "RichLogBox";
            this.RichLogBox.Size = new System.Drawing.Size(276, 254);
            this.RichLogBox.TabIndex = 4;
            this.RichLogBox.Text = "";
            // 
            // btn_readShit
            // 
            this.btn_readShit.Enabled = false;
            this.btn_readShit.Location = new System.Drawing.Point(758, 90);
            this.btn_readShit.Name = "btn_readShit";
            this.btn_readShit.Size = new System.Drawing.Size(75, 23);
            this.btn_readShit.TabIndex = 5;
            this.btn_readShit.Text = "Readphpuser";
            this.btn_readShit.UseVisualStyleBackColor = true;
            this.btn_readShit.Click += new System.EventHandler(this.btn_readShit_Click);
            // 
            // btn_startphpfetch
            // 
            this.btn_startphpfetch.Location = new System.Drawing.Point(758, 61);
            this.btn_startphpfetch.Name = "btn_startphpfetch";
            this.btn_startphpfetch.Size = new System.Drawing.Size(75, 23);
            this.btn_startphpfetch.TabIndex = 6;
            this.btn_startphpfetch.Text = "Start php loop";
            this.btn_startphpfetch.UseVisualStyleBackColor = true;
            this.btn_startphpfetch.Click += new System.EventHandler(this.btn_startphpfetch_Click);
            // 
            // text_iSconnected
            // 
            this.text_iSconnected.Location = new System.Drawing.Point(13, 130);
            this.text_iSconnected.Name = "text_iSconnected";
            this.text_iSconnected.Size = new System.Drawing.Size(100, 23);
            this.text_iSconnected.TabIndex = 7;
            this.text_iSconnected.TextChanged += new System.EventHandler(this.text_iSconnected_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(681, 260);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 582);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.text_iSconnected);
            this.Controls.Add(this.btn_startphpfetch);
            this.Controls.Add(this.btn_readShit);
            this.Controls.Add(this.RichLogBox);
            this.Controls.Add(this.write);
            this.Controls.Add(this.PortInfos);
            this.Controls.Add(this.btn_serielConnect);
            this.Controls.Add(this.comboBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btn_serielConnect;
        private System.Windows.Forms.Button PortInfos;
        private System.Windows.Forms.Button write;
        private System.Windows.Forms.RichTextBox RichLogBox;
        private System.Windows.Forms.Button btn_readShit;
        private System.Windows.Forms.Button btn_startphpfetch;
        private System.Windows.Forms.TextBox text_iSconnected;
        private System.Windows.Forms.Button button1;
    }
}

