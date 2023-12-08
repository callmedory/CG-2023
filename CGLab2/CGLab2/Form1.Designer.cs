namespace CGLab2
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
            button2 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(131, 403);
            button1.Name = "button1";
            button1.Size = new Size(96, 38);
            button1.TabIndex = 0;
            button1.Text = "Візерунок з квадратів";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(482, 403);
            button2.Name = "button2";
            button2.Size = new Size(94, 38);
            button2.TabIndex = 1;
            button2.Text = "Трикутник Серпінського";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(142, 374);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(75, 23);
            textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(491, 374);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(75, 23);
            textBox2.TabIndex = 3;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(46, 92);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(273, 266);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(392, 92);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(268, 266);
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Unispace", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(249, 9);
            label1.Name = "label1";
            label1.Size = new Size(224, 23);
            label1.TabIndex = 6;
            label1.Text = "Лабораторна робота №2";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Unispace", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(228, 32);
            label2.Name = "label2";
            label2.Size = new Size(258, 19);
            label2.TabIndex = 7;
            label2.Text = "Виконала студентка групи ІО-з11";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Unispace", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(280, 51);
            label3.Name = "label3";
            label3.Size = new Size(149, 19);
            label3.TabIndex = 8;
            label3.Text = "Реу Дар'я Юріївна";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(707, 450);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Lab2";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private TextBox textBox1;
        private TextBox textBox2;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}