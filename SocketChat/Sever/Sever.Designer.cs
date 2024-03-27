namespace Form1
{
    partial class Sever
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
            btSend = new Button();
            lvScreen = new ListView();
            tbSend = new TextBox();
            tbPort = new TextBox();
            label2 = new Label();
            tbSIP = new TextBox();
            label1 = new Label();
            btConnect = new Button();
            SuspendLayout();
            // 
            // btSend
            // 
            btSend.Location = new Point(657, 341);
            btSend.Name = "btSend";
            btSend.Size = new Size(112, 89);
            btSend.TabIndex = 23;
            btSend.Text = "Send";
            btSend.UseVisualStyleBackColor = true;
            btSend.Click += btSend_Click;
            // 
            // lvScreen
            // 
            lvScreen.Location = new Point(12, 56);
            lvScreen.Name = "lvScreen";
            lvScreen.RightToLeft = RightToLeft.Yes;
            lvScreen.Size = new Size(776, 269);
            lvScreen.TabIndex = 22;
            lvScreen.UseCompatibleStateImageBehavior = false;
            lvScreen.View = View.List;
            // 
            // tbSend
            // 
            tbSend.Location = new Point(12, 341);
            tbSend.Multiline = true;
            tbSend.Name = "tbSend";
            tbSend.Size = new Size(616, 93);
            tbSend.TabIndex = 21;
            // 
            // tbPort
            // 
            tbPort.Location = new Point(417, 17);
            tbPort.Name = "tbPort";
            tbPort.Size = new Size(150, 31);
            tbPort.TabIndex = 20;
            tbPort.Text = "11111";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(367, 23);
            label2.Name = "label2";
            label2.Size = new Size(44, 25);
            label2.TabIndex = 19;
            label2.Text = "Port";
            // 
            // tbSIP
            // 
            tbSIP.Location = new Point(93, 17);
            tbSIP.Name = "tbSIP";
            tbSIP.Size = new Size(150, 31);
            tbSIP.TabIndex = 18;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 25);
            label1.Name = "label1";
            label1.Size = new Size(75, 25);
            label1.TabIndex = 17;
            label1.Text = "Sever IP";
            // 
            // btConnect
            // 
            btConnect.Location = new Point(613, 17);
            btConnect.Name = "btConnect";
            btConnect.Size = new Size(112, 34);
            btConnect.TabIndex = 16;
            btConnect.Text = "Connect";
            btConnect.UseVisualStyleBackColor = true;
            // 
            // Sever
            // 
            AcceptButton = btSend;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btSend);
            Controls.Add(lvScreen);
            Controls.Add(tbSend);
            Controls.Add(tbPort);
            Controls.Add(label2);
            Controls.Add(tbSIP);
            Controls.Add(label1);
            Controls.Add(btConnect);
            Name = "Sever";
            Text = "Sever";
            FormClosed += Sever_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btSend;
        private ListView lvScreen;
        private TextBox tbSend;
        private TextBox tbPort;
        private Label label2;
        private TextBox tbSIP;
        private Label label1;
        private Button btConnect;
    }
}
