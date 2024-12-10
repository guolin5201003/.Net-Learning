namespace test
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
            this.textBoxComPort = new System.Windows.Forms.TextBox();
            this.textBoxFrame = new System.Windows.Forms.TextBox();
            this.textBoxColumn = new System.Windows.Forms.TextBox();
            this.labelComPort = new System.Windows.Forms.Label();
            this.labelFrame = new System.Windows.Forms.Label();
            this.labelColumn = new System.Windows.Forms.Label();
            this.buttonSend = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxDrawer = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxComPort
            // 
            this.textBoxComPort.Location = new System.Drawing.Point(113, 63);
            this.textBoxComPort.Name = "textBoxComPort";
            this.textBoxComPort.Size = new System.Drawing.Size(100, 20);
            this.textBoxComPort.TabIndex = 0;
            this.textBoxComPort.Text = "COM4";
            // 
            // textBoxFrame
            // 
            this.textBoxFrame.Location = new System.Drawing.Point(113, 111);
            this.textBoxFrame.Name = "textBoxFrame";
            this.textBoxFrame.Size = new System.Drawing.Size(100, 20);
            this.textBoxFrame.TabIndex = 1;
            // 
            // textBoxColumn
            // 
            this.textBoxColumn.Location = new System.Drawing.Point(113, 166);
            this.textBoxColumn.Name = "textBoxColumn";
            this.textBoxColumn.Size = new System.Drawing.Size(100, 20);
            this.textBoxColumn.TabIndex = 2;
            // 
            // labelComPort
            // 
            this.labelComPort.AutoSize = true;
            this.labelComPort.Location = new System.Drawing.Point(35, 69);
            this.labelComPort.Name = "labelComPort";
            this.labelComPort.Size = new System.Drawing.Size(64, 13);
            this.labelComPort.TabIndex = 3;
            this.labelComPort.Text = "COM PORT";
            // 
            // labelFrame
            // 
            this.labelFrame.AutoSize = true;
            this.labelFrame.Location = new System.Drawing.Point(38, 117);
            this.labelFrame.Name = "labelFrame";
            this.labelFrame.Size = new System.Drawing.Size(36, 13);
            this.labelFrame.TabIndex = 4;
            this.labelFrame.Text = "Frame";
            // 
            // labelColumn
            // 
            this.labelColumn.AutoSize = true;
            this.labelColumn.Location = new System.Drawing.Point(38, 172);
            this.labelColumn.Name = "labelColumn";
            this.labelColumn.Size = new System.Drawing.Size(42, 13);
            this.labelColumn.TabIndex = 5;
            this.labelColumn.Text = "Column";
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(38, 250);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(75, 23);
            this.buttonSend.TabIndex = 6;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 210);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Drawer";
            // 
            // textBoxDrawer
            // 
            this.textBoxDrawer.Location = new System.Drawing.Point(113, 210);
            this.textBoxDrawer.Name = "textBoxDrawer";
            this.textBoxDrawer.Size = new System.Drawing.Size(100, 20);
            this.textBoxDrawer.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 312);
            this.Controls.Add(this.textBoxDrawer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.labelColumn);
            this.Controls.Add(this.labelFrame);
            this.Controls.Add(this.labelComPort);
            this.Controls.Add(this.textBoxColumn);
            this.Controls.Add(this.textBoxFrame);
            this.Controls.Add(this.textBoxComPort);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxComPort;
        private System.Windows.Forms.TextBox textBoxFrame;
        private System.Windows.Forms.TextBox textBoxColumn;
        private System.Windows.Forms.Label labelComPort;
        private System.Windows.Forms.Label labelFrame;
        private System.Windows.Forms.Label labelColumn;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDrawer;
    }
}

