namespace AsyncScenarios2
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
            gbCPUBound = new GroupBox();
            textBox2 = new TextBox();
            btnCalculate = new Button();
            gbIOBound = new GroupBox();
            textBox1 = new TextBox();
            btnDownload = new Button();
            label1 = new Label();
            textBox3 = new TextBox();
            gbCPUBound.SuspendLayout();
            gbIOBound.SuspendLayout();
            SuspendLayout();
            // 
            // gbCPUBound
            // 
            gbCPUBound.Controls.Add(textBox2);
            gbCPUBound.Controls.Add(btnCalculate);
            gbCPUBound.Location = new Point(12, 21);
            gbCPUBound.Name = "gbCPUBound";
            gbCPUBound.Size = new Size(357, 159);
            gbCPUBound.TabIndex = 3;
            gbCPUBound.TabStop = false;
            gbCPUBound.Text = "CPU Bound";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(17, 59);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(322, 94);
            textBox2.TabIndex = 5;
            // 
            // btnCalculate
            // 
            btnCalculate.Location = new Point(17, 22);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(116, 23);
            btnCalculate.TabIndex = 1;
            btnCalculate.Text = "CalculateDamage";
            btnCalculate.UseVisualStyleBackColor = true;
            // 
            // gbIOBound
            // 
            gbIOBound.Controls.Add(textBox3);
            gbIOBound.Controls.Add(label1);
            gbIOBound.Controls.Add(textBox1);
            gbIOBound.Controls.Add(btnDownload);
            gbIOBound.Location = new Point(12, 186);
            gbIOBound.Name = "gbIOBound";
            gbIOBound.Size = new Size(357, 240);
            gbIOBound.TabIndex = 4;
            gbIOBound.TabStop = false;
            gbIOBound.Text = "I/O Bound";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(17, 78);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(322, 156);
            textBox1.TabIndex = 4;
            // 
            // btnDownload
            // 
            btnDownload.Location = new Point(17, 48);
            btnDownload.Name = "btnDownload";
            btnDownload.Size = new Size(75, 23);
            btnDownload.TabIndex = 3;
            btnDownload.Text = "Download";
            btnDownload.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 20);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 5;
            label1.Text = "URL:";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(55, 20);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(271, 23);
            textBox3.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(381, 450);
            Controls.Add(gbIOBound);
            Controls.Add(gbCPUBound);
            Name = "Form1";
            Text = "Form1";
            gbCPUBound.ResumeLayout(false);
            gbCPUBound.PerformLayout();
            gbIOBound.ResumeLayout(false);
            gbIOBound.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox gbCPUBound;
        private Button btnCalculate;
        private TextBox textBox2;
        private GroupBox gbIOBound;
        private TextBox textBox1;
        private Button btnDownload;
        private TextBox textBox3;
        private Label label1;
    }
}
