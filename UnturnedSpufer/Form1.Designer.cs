namespace UnturnedSpufer
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
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.System;
            button1.Font = new Font("Consolas", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(12, 214);
            button1.Name = "button1";
            button1.Size = new Size(367, 35);
            button1.TabIndex = 0;
            button1.Text = "Spoof";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Consolas", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(138, 9);
            label1.Name = "label1";
            label1.Size = new Size(112, 14);
            label1.TabIndex = 1;
            label1.Text = "[ INFORMATION ]";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(-6, 23);
            label2.Name = "label2";
            label2.Size = new Size(407, 15);
            label2.TabIndex = 2;
            label2.Text = "________________________________________________________________________________";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Consolas", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(12, 47);
            label3.Name = "label3";
            label3.Size = new Size(98, 14);
            label3.TabIndex = 3;
            label3.Text = "[+] BattleEye";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Consolas", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label4.ForeColor = Color.Lime;
            label4.Location = new Point(116, 47);
            label4.Name = "label4";
            label4.Size = new Size(77, 14);
            label4.TabIndex = 4;
            label4.Text = "Undetected";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Consolas", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label5.ForeColor = SystemColors.Control;
            label5.Location = new Point(12, 61);
            label5.Name = "label5";
            label5.Size = new Size(91, 14);
            label5.TabIndex = 5;
            label5.Text = "[+] Unturned";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Consolas", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label6.ForeColor = Color.Lime;
            label6.Location = new Point(116, 61);
            label6.Name = "label6";
            label6.Size = new Size(77, 14);
            label6.TabIndex = 6;
            label6.Text = "Undetected";
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.MenuText;
            textBox1.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox1.ForeColor = Color.Lime;
            textBox1.Location = new Point(12, 78);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(367, 130);
            textBox1.TabIndex = 7;
            textBox1.Text = "Idle...";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(391, 261);
            Controls.Add(textBox1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            Opacity = 0.75D;
            ShowIcon = false;
            Text = "Unturned Cleaner [By Not-Seil]";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox textBox1;
    }
}
