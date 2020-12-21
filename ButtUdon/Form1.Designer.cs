namespace ButtUdon
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
            this.connectLocal = new System.Windows.Forms.Button();
            this.serverAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.serverConnect = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.VRCStatus = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.discover = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.startUdonReader = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // connectLocal
            // 
            this.connectLocal.Enabled = false;
            this.connectLocal.Location = new System.Drawing.Point(274, 91);
            this.connectLocal.Name = "connectLocal";
            this.connectLocal.Size = new System.Drawing.Size(210, 34);
            this.connectLocal.TabIndex = 0;
            this.connectLocal.Text = "Connect using local";
            this.connectLocal.UseVisualStyleBackColor = true;
            this.connectLocal.Click += new System.EventHandler(this.connectLocal_Click);
            // 
            // serverAddress
            // 
            this.serverAddress.Location = new System.Drawing.Point(274, 178);
            this.serverAddress.Name = "serverAddress";
            this.serverAddress.Size = new System.Drawing.Size(306, 20);
            this.serverAddress.TabIndex = 1;
            this.serverAddress.Text = "ws://localhost:12345/buttplug";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(271, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Remote connection address";
            // 
            // serverConnect
            // 
            this.serverConnect.Location = new System.Drawing.Point(274, 206);
            this.serverConnect.Name = "serverConnect";
            this.serverConnect.Size = new System.Drawing.Size(75, 32);
            this.serverConnect.TabIndex = 3;
            this.serverConnect.Text = "Connect";
            this.serverConnect.UseVisualStyleBackColor = true;
            this.serverConnect.Click += new System.EventHandler(this.serverConnect_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "VRChat Status:";
            // 
            // VRCStatus
            // 
            this.VRCStatus.AutoSize = true;
            this.VRCStatus.ForeColor = System.Drawing.Color.Red;
            this.VRCStatus.Location = new System.Drawing.Point(122, 9);
            this.VRCStatus.Name = "VRCStatus";
            this.VRCStatus.Size = new System.Drawing.Size(60, 15);
            this.VRCStatus.TabIndex = 5;
            this.VRCStatus.Text = "Not active";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Bluetooth Status:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(134, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Not found";
            // 
            // discover
            // 
            this.discover.Enabled = false;
            this.discover.Location = new System.Drawing.Point(12, 178);
            this.discover.Name = "discover";
            this.discover.Size = new System.Drawing.Size(210, 43);
            this.discover.TabIndex = 8;
            this.discover.Text = "Discover devices";
            this.discover.UseVisualStyleBackColor = true;
            this.discover.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Devices connected:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "None";
            // 
            // startUdonReader
            // 
            this.startUdonReader.Location = new System.Drawing.Point(12, 245);
            this.startUdonReader.Name = "startUdonReader";
            this.startUdonReader.Size = new System.Drawing.Size(124, 36);
            this.startUdonReader.TabIndex = 11;
            this.startUdonReader.Text = "Start Udon reader";
            this.startUdonReader.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.startUdonReader);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.discover);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.VRCStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.serverConnect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.serverAddress);
            this.Controls.Add(this.connectLocal);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button connectLocal;
        private System.Windows.Forms.TextBox serverAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button serverConnect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label VRCStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button discover;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button startUdonReader;
    }
}

