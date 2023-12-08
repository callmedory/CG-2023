namespace CGLab1
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            Paint += Form1_Paint;
        }

        private void About_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Pen pen = new Pen(Color.White);
            pen.Width = 3;

            g.DrawLine(pen, 95, 102, 95, 152);
            g.DrawLine(pen, 95, 102, 110, 102);
            g.DrawLine(pen, 110, 102, 115, 107);
            g.DrawLine(pen, 115, 107, 115, 120);
            g.DrawLine(pen, 115, 120, 110, 125);
            g.DrawLine(pen, 110, 125, 95, 125);

            g.DrawLine(pen, 135, 102, 135, 152);
            g.DrawLine(pen, 135, 102, 155, 102);
            g.DrawLine(pen, 135, 125, 155, 125);
            g.DrawLine(pen, 135, 150, 155, 150);

            g.DrawLine(pen, 175, 102, 190, 125);
            g.DrawLine(pen, 195, 102, 185, 150);

            pen.Dispose();
        }
    }
}