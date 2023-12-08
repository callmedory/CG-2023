using System.Drawing.Drawing2D;

namespace CGLab5
{
    public partial class Form1 : Form
    {
        public class GeometricShape
        {
            private RectangleF rectangle;
            public bool Visible { get; set; } = true;

            public GeometricShape(RectangleF rect)
            {
                rectangle = rect;
            }

            public void Draw(Graphics graphics)
            {
                if (Visible)
                {
                    using (Pen pen = new Pen(Color.Navy, 2))
                    {
                        graphics.DrawRectangle(pen, Rectangle.Round(rectangle));
                    }
                }
            }
        }

        private GeometricShape shape;
        private Matrix transformationMatrix = new Matrix();

        public Form1()
        {
            InitializeComponent();
            shape = new GeometricShape(new RectangleF(50, 50, 100, 60));

            button1.Click += (sender, e) => ApplyTransformation(CreateMoveMatrix());
            button2.Click += (sender, e) => ApplyTransformation(CreateRotateMatrix());
            button3.Click += (sender, e) => ApplyTransformation(CreateScaleMatrix());
            button4.Click += new EventHandler(toggleButton_Click);
            button5.Click += new EventHandler(button5_Click);
            button6.Click += new EventHandler(button6_Click);

            dxTextBox.SetPlaceholder("Enter x");
            dyTextBox.SetPlaceholder("Enter y");
            dxText.SetPlaceholder("Enter x");
            dyText.SetPlaceholder("Enter y");
            angleTextBox.SetPlaceholder("Enter angle");
            scalexTextBox.SetPlaceholder("Enter x");
            scaleyTextBox.SetPlaceholder("Enter y");

            pictureBox1.Paint += new PaintEventHandler(pictureBox1_Paint);

            textTextBox.SetPlaceholder("Enter text");
        }

        private Matrix CreateMoveMatrix()
        {
            if (float.TryParse(dxTextBox.Text, out float dx) && float.TryParse(dyTextBox.Text, out float dy))
            {
                Matrix moveMatrix = new Matrix();
                moveMatrix.Translate(dx, dy);
                return moveMatrix;
            }
            else
            {
                MessageBox.Show("Wrong value for dx or dy entered.");
                return null;
            }
        }

        private Matrix CreateRotateMatrix()
        {
            if (float.TryParse(angleTextBox.Text, out float angle))
            {
                Matrix rotateMatrix = new Matrix();
                rotateMatrix.Rotate(angle);
                return rotateMatrix;
            }
            else
            {
                MessageBox.Show("Wrong value for rotation angle entered.");
                return null;
            }
        }

        private Matrix CreateScaleMatrix()
        {
            if (float.TryParse(scalexTextBox.Text, out float scaleX) && float.TryParse(scaleyTextBox.Text, out float scaleY))
            {
                Matrix scaleMatrix = new Matrix();
                scaleMatrix.Scale(scaleX, scaleY);
                return scaleMatrix;
            }
            else
            {
                MessageBox.Show("Wrong value for scaleX or scaleY entered.");
                return null;
            }
        }

        private void toggleButton_Click(object sender, EventArgs e)
        {
            shape.Visible = !shape.Visible;
            pictureBox1.Invalidate();
        }

        private void UpdateMatrixTextBox()
        {
            string matrixString = string.Format("[{0}  {1}]\r\n[{2}  {3}]\r\n[{4}  {5}]",
                transformationMatrix.Elements[0], transformationMatrix.Elements[1],
                transformationMatrix.Elements[2], transformationMatrix.Elements[3],
                transformationMatrix.Elements[4], transformationMatrix.Elements[5]);

            textBoxMatrix.Text = matrixString;
        }

        private void ApplyTransformation(Matrix matrix)
        {
            try
            {
                transformationMatrix.Multiply(matrix, MatrixOrder.Append);
                pictureBox1.Invalidate();
                UpdateMatrixTextBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception occured when trying to apply a transformation: " + ex.Message);
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.Clear(Color.White);

            try
            {
                graphics.Transform = transformationMatrix;
                shape.Draw(graphics);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception occured when trying to draw a figure: " + ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string text = textTextBox.Text;
            DrawTextOnPictureBox2(text, pictureBox2.Width, pictureBox2.Height, 0, 0);
        }

        private void DrawTextOnPictureBox2(string text, int width, int height, int x, int y)
        {
            Bitmap bmp = new Bitmap(width, height);

            using (Graphics graphics = Graphics.FromImage(bmp))
            {
                graphics.Clear(Color.White);
                using (Font myFont = new Font("Arial", 14))
                {
                    graphics.DrawString(text, myFont, Brushes.Navy, new Point(x, y));
                }
            }

            pictureBox2.Image?.Dispose();
            pictureBox2.Image = (Image)bmp.Clone();
            bmp.Dispose();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (int.TryParse(dxText.Text, out int dx) && int.TryParse(dyText.Text, out int dy))
            {
                MoveTextOnPictureBox2(dx, dy);
            }
            else
            {
                MessageBox.Show("Wrong value for scaleX or scaleY entered.");
            }
        }

        private void MoveTextOnPictureBox2(int dx, int dy)
        {
            int newX = 2 + dx;
            int newY = 2 + dy;

            int width = pictureBox2.Width;
            int height = pictureBox2.Height;

            DrawTextOnPictureBox2(textTextBox.Text, width, height, newX, newY);
        }
    }

    public static class TextBoxExtensions
    {
        public static void SetPlaceholder(this System.Windows.Forms.TextBox textBox, string placeholderText)
        {
            textBox.Text = placeholderText;

            textBox.Enter += (sender, e) =>
            {
                if (textBox.Text == placeholderText)
                {
                    textBox.Text = "";
                }
            };

            textBox.Leave += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholderText;
                }
            };
        }
    }
}