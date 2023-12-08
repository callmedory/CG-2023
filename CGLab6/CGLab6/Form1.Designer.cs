namespace CGLab6
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
            components = new System.ComponentModel.Container();
            openglControl1 = new SharpGL.OpenGLControl();
            timer1 = new System.Windows.Forms.Timer(components);
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)openglControl1).BeginInit();
            SuspendLayout();
            // 
            // openglControl1
            // 
            openglControl1.DrawFPS = false;
            openglControl1.Location = new Point(-1, 66);
            openglControl1.Margin = new Padding(4, 3, 4, 3);
            openglControl1.Name = "openglControl1";
            openglControl1.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            openglControl1.RenderContextType = SharpGL.RenderContextType.DIBSection;
            openglControl1.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            openglControl1.Size = new Size(551, 450);
            openglControl1.TabIndex = 0;
            openglControl1.Load += openglControl1_Load;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Unispace", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(187, 9);
            label1.Name = "label1";
            label1.Size = new Size(190, 19);
            label1.TabIndex = 1;
            label1.Text = "Лабораторна робота №6";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Unispace", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(226, 28);
            label2.Name = "label2";
            label2.Size = new Size(94, 18);
            label2.TabIndex = 2;
            label2.Text = "Реу Дар'я";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(550, 516);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(openglControl1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)openglControl1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private SharpGL.OpenGLControl openglControl1;
        private System.Windows.Forms.Timer timer1;
        private Label label1;
        private Label label2;
    }
}