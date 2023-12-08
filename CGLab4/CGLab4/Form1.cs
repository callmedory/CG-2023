using System.Drawing.Drawing2D;

namespace CGLab4
{
    public partial class Form1 : Form
    {
        private readonly PictureBox pictureBox;
        private readonly System.Windows.Forms.Timer timer;
        private Point objectPosition;
        private Size objectSize;
        private Point objectVelocity;
        private readonly Region[] obstacles;

        public Form1()
        {
            InitializeComponent();

            pictureBox = new PictureBox();
            pictureBox.Size = ClientSize;
            pictureBox.BackColor = Color.AliceBlue;
            Controls.Add(pictureBox);

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 30;
            timer.Tick += Timer_Tick;
            timer.Start();

            objectSize = new Size(20, 20);
            objectPosition = new Point(50, ClientSize.Height / 2 - objectSize.Height / 2);
            objectVelocity = new Point(4, 4);
            obstacles = new Region[]
            {
                new Region(new Rectangle(100, 200, 100, 100)),
                new Region(new Rectangle(600, 150, 70, 50)),
                new Region(new Rectangle(300, 100, 75, 75))
            };

            GraphicsPath path1 = new GraphicsPath();
            path1.AddEllipse(250, 350, 100, 100);
            obstacles[0].Union(path1);

            GraphicsPath path2 = new GraphicsPath();
            path2.AddEllipse(500, 420, 150, 50);
            obstacles[1].Union(path2);

            pictureBox.Paint += PictureBox_Paint;
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(Brushes.DodgerBlue, new Rectangle(objectPosition, objectSize));

            foreach (var obstacle in obstacles)
            {
                e.Graphics.FillRegion(Brushes.MidnightBlue, obstacle);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            objectPosition.X += objectVelocity.X;
            objectPosition.Y += objectVelocity.Y;

            Rectangle pictureBoxBounds = pictureBox.ClientRectangle;

            foreach (var obstacle in obstacles)
            {
                Rectangle objectRect = new Rectangle(objectPosition, objectSize);
                if (obstacle.IsVisible(objectRect))
                {
                    float overlapX = Math.Max(0, Math.Min(objectRect.Right, obstacle.GetBounds(pictureBox.CreateGraphics()).Right) - Math.Max(objectRect.Left, obstacle.GetBounds(pictureBox.CreateGraphics()).Left));
                    float overlapY = Math.Max(0, Math.Min(objectRect.Bottom, obstacle.GetBounds(pictureBox.CreateGraphics()).Bottom) - Math.Max(objectRect.Top, obstacle.GetBounds(pictureBox.CreateGraphics()).Top));

                    if (overlapX < overlapY)
                    {
                        objectVelocity.X = -objectVelocity.X;
                    }
                    else
                    {
                        objectVelocity.Y = -objectVelocity.Y;
                    }
                }
            }

            if (objectPosition.X < pictureBoxBounds.Left || objectPosition.X + objectSize.Width > pictureBoxBounds.Right)
            {
                objectVelocity.X = -objectVelocity.X;
            }
            if (objectPosition.Y < pictureBoxBounds.Top || objectPosition.Y + objectSize.Height > pictureBoxBounds.Bottom)
            {
                objectVelocity.Y = -objectVelocity.Y;
            }

            objectPosition.X = Math.Max(pictureBoxBounds.Left, Math.Min(pictureBoxBounds.Right - objectSize.Width, objectPosition.X));
            objectPosition.Y = Math.Max(pictureBoxBounds.Top, Math.Min(pictureBoxBounds.Bottom - objectSize.Height, objectPosition.Y));

            pictureBox.Invalidate();
        }
    }
}