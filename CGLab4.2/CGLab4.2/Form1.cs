using System.Drawing.Drawing2D;

namespace CGLab4._2
{
    public partial class Form1 : Form
    {
        private readonly PictureBox pictureBox;
        private Point objectPosition;
        private Size objectSize;
        private readonly Region[] obstacles;
        private Image objectImage;

        public Form1()
        {
            InitializeComponent();

            pictureBox = new PictureBox();
            pictureBox.Size = ClientSize;
            pictureBox.BackColor = Color.AliceBlue;
            Controls.Add(pictureBox);

            pictureBox.MouseMove += PictureBox_MouseMove;

            objectSize = new Size(50, 50);
            objectPosition = new Point(50, ClientSize.Height / 2 - objectSize.Height / 2);
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

            objectImage = Image.FromFile("skeleton-4844553_960_720.png");
            objectImage = ResizeImage(objectImage, 50, 50);

            pictureBox.Paint += PictureBox_Paint;
            this.DoubleBuffered = true;
        }

        private Image ResizeImage(Image source, int width, int height)
        {
            Bitmap resizedImage = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(resizedImage))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(source, 0, 0, width, height);
            }
            return resizedImage;
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(objectImage, objectPosition);

            foreach (var obstacle in obstacles)
            {
                e.Graphics.FillRegion(Brushes.MidnightBlue, obstacle);
            }
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            Point newPosition = e.Location;
            newPosition.X -= objectSize.Width / 2;
            newPosition.Y -= objectSize.Height / 2;

            Rectangle newObjectRect = new Rectangle(newPosition, objectSize);
            bool obstacleCollision = false;

            foreach (var obstacle in obstacles)
            {
                if (obstacle.IsVisible(newObjectRect))
                {
                    float overlapX = Math.Max(0, Math.Min(newObjectRect.Right, obstacle.GetBounds(pictureBox.CreateGraphics()).Right) - Math.Max(newObjectRect.Left, obstacle.GetBounds(pictureBox.CreateGraphics()).Left));
                    float overlapY = Math.Max(0, Math.Min(newObjectRect.Bottom, obstacle.GetBounds(pictureBox.CreateGraphics()).Bottom) - Math.Max(newObjectRect.Top, obstacle.GetBounds(pictureBox.CreateGraphics()).Top));

                    if (overlapX > 0 && overlapY > 0)
                    {
                        obstacleCollision = true;
                        break;
                    }
                }
            }

            if (!obstacleCollision)
            {
                objectPosition = newPosition;
                objectPosition.X = Math.Max(0, Math.Min(pictureBox.ClientSize.Width - objectSize.Width, objectPosition.X));
                objectPosition.Y = Math.Max(0, Math.Min(pictureBox.ClientSize.Height - objectSize.Height, objectPosition.Y));
                pictureBox.Invalidate();
            }
        }
    }
}
