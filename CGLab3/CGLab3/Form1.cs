namespace CGLab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            button1.Click += new EventHandler(buttonDrawKoch_Click);
        }

        private void buttonDrawKoch_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            Graphics g = Graphics.FromImage(pictureBox1.Image);

            if (int.TryParse(textBox1.Text, out int depth) && depth >= 0 && depth <= 4)
            {
                Point p1 = new Point(100, 300);
                Point p2 = new Point(400, 300);
                Point p3 = new Point(250, 30);

                Pen myPen = new Pen(Color.Purple, 1.0f);

                DrawKochSnowflake(g, depth, p1, p3, myPen);
                DrawKochSnowflake(g, depth, p3, p2, myPen);
                DrawKochSnowflake(g, depth, p2, p1, myPen);

                myPen.Dispose();

                pictureBox1.Invalidate();
            }
            else
            {
                MessageBox.Show("Enter a correct value for recursion depth - from 0 to 4.");
            }
        }

        private void DrawKochSnowflake(Graphics g, int depth, Point p1, Point p2, Pen pen)
        {
            if (depth == 0)
            {
                g.DrawLine(pen, p1, p2);
            }
            else
            {
                Point p3 = new Point(
                    p1.X + (p2.X - p1.X) / 3,
                    p1.Y + (p2.Y - p1.Y) / 3
                );

                Point p4 = new Point(
                    p1.X + (p2.X - p1.X) / 2 + (int)((p2.Y - p1.Y) * Math.Sin(Math.PI / 3) / 3),
                    p1.Y + (p2.Y - p1.Y) / 2 - (int)((p2.X - p1.X) * Math.Sin(Math.PI / 3) / 3)
                );

                Point p5 = new Point(
                    p1.X + 2 * (p2.X - p1.X) / 3,
                    p1.Y + 2 * (p2.Y - p1.Y) / 3
                );

                DrawKochSnowflake(g, depth - 1, p1, p3, pen);
                DrawKochSnowflake(g, depth - 1, p3, p4, pen);
                DrawKochSnowflake(g, depth - 1, p4, p5, pen);
                DrawKochSnowflake(g, depth - 1, p5, p2, pen);
            }
        }
    }
}