using System.Drawing.Drawing2D;

namespace CGLab2
{
    public partial class Form1 : Form
    {
        private int generations;
        private int sierpinskiGenerations;

        public Form1()
        {
            InitializeComponent();
        }

        private void DrawPattern(int amountOfSquares)
        {
            pictureBox1.Image = null;

            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                float ratio = 0.08F;
                PointF point1 = new PointF(20, 20);
                PointF point2 = new PointF(220, 20);
                PointF point3 = new PointF(220, 220);
                PointF point4 = new PointF(20, 220);

                LinearGradientBrush linGrBrush = new LinearGradientBrush(
                    new Point(0, -90),
                    new Point(200, 10),
                    Color.Plum,
                    Color.MediumPurple);

                Pen pen = new Pen(linGrBrush);
                pen.Width = 1;

                for (int i = 0; i < amountOfSquares; i++)
                {
                    PointF[] points = new PointF[4] { point1, point2, point3, point4 };
                    g.DrawPolygon(pen, points);
                    point1.X += ((point2.X - point1.X) * ratio);
                    point1.Y += ((point2.Y - point1.Y) * ratio);
                    point2.X += ((point3.X - point2.X) * ratio);
                    point2.Y += ((point3.Y - point2.Y) * ratio);
                    point3.X += ((point4.X - point3.X) * ratio);
                    point3.Y += ((point4.Y - point3.Y) * ratio);
                    point4.X += ((point1.X - point4.X) * ratio);
                    point4.Y += ((point1.Y - point4.Y) * ratio);
                }
            }

            pictureBox1.Image = bmp;
        }

        private void DrawSierpinski(int gen)
        {
            pictureBox2.Image = null;

            Bitmap bmp = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                PointF p1 = new PointF(pictureBox2.Width / 2, 20);
                PointF p2 = new PointF(20, pictureBox2.Height - 20);
                PointF p3 = new PointF(pictureBox2.Width - 20, pictureBox2.Height - 20);

                Pen pen = new Pen(Color.RebeccaPurple);
                pen.Width = 1;

                DrawSierpinskiTriangle(g, gen, p1, p2, p3, pen);
            }

            pictureBox2.Image = bmp;
        }

        private void DrawSierpinskiTriangle(Graphics g, int gen, PointF p1, PointF p2, PointF p3, Pen pen)
        {
            if (gen == 0)
            {
                PointF[] points = new PointF[] { p1, p2, p3 };
                g.DrawPolygon(pen, points);
            }
            else
            {
                PointF mid1 = new PointF((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);
                PointF mid2 = new PointF((p2.X + p3.X) / 2, (p2.Y + p3.Y) / 2);
                PointF mid3 = new PointF((p1.X + p3.X) / 2, (p1.Y + p3.Y) / 2);

                DrawSierpinskiTriangle(g, gen - 1, p1, mid1, mid3, pen);
                DrawSierpinskiTriangle(g, gen - 1, mid1, p2, mid2, pen);
                DrawSierpinskiTriangle(g, gen - 1, mid3, mid2, p3, pen);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out generations))
            {
                if (generations > 50)
                {
                    MessageBox.Show("Maximum reasonable number of generations for the pattern is 50.");
                    return;
                }
                DrawPattern(generations);
            }
            else
            {
                MessageBox.Show("Enter a valid number of generations.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox2.Text, out sierpinskiGenerations))
            {
                if (sierpinskiGenerations > 5)
                {
                    MessageBox.Show("Maximum reasonable number of generations for the Sierpinski triangle is 5.");
                    return;
                }
                DrawSierpinski(sierpinskiGenerations);
            }
            else
            {
                MessageBox.Show("Enter a valid number of generations.");
            }
        }
    }
}