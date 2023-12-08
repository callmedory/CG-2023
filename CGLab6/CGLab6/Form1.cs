using SharpGL;
using SharpGL.Enumerations;

namespace CGLab6
{
    public partial class Form1 : Form
    {
        private OpenGL gl;
        private Tetrahedron tetrahedron;
        private float rotationAngle = 1.0f;
        private float translationSpeed = 0.07f;
        private float[] tetrahedronVertices = {
            0.0f, 1.0f, 0.0f,
            -1.0f, -1.0f, 1.0f,
            1.0f, -1.0f, 1.0f,

            0.0f, 1.0f, 0.0f,
            1.0f, -1.0f, 1.0f,
            0.0f, -1.0f, -1.0f,

            0.0f, 1.0f, 0.0f,
            0.0f, -1.0f, -1.0f,
            -1.0f, -1.0f, 1.0f,

            -1.0f, -1.0f, 1.0f,
            1.0f, -1.0f, 1.0f,
            0.0f, -1.0f, -1.0f
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void SetupViewport()
        {
            gl.MatrixMode(MatrixMode.Projection);
            gl.LoadIdentity();
            gl.Perspective(45.0f, (float)Width / (float)Height, 0.01f, 100.0f);
            gl.MatrixMode(MatrixMode.Modelview);
            gl.LoadIdentity();
        }

        private void CheckCollision()
        {
            float[] tetrahedronPosition = tetrahedron.GetPosition();

            for (int i = 0; i < 3; i++)
            {
                if (Math.Abs(tetrahedronPosition[i]) > 2.0f)
                {
                    translationSpeed = -translationSpeed;
                    break;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tetrahedron.Translate(translationSpeed, translationSpeed, translationSpeed);

            CheckCollision();

            rotationAngle += 1.0f;

            openglControl1.Invalidate();
        }

        private void openglControl1_Load(object sender, EventArgs e)
        {
            gl = openglControl1.OpenGL;
            gl.ClearColor(0, 0, 0, 0);
            tetrahedron = new Tetrahedron(tetrahedronVertices);
            SetupViewport();
            openglControl1.OpenGLDraw += openglControl1_OpenGLDraw;
            timer1.Start();
        }

        private void openglControl1_OpenGLDraw(object sender, RenderEventArgs args)
        {
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.LoadIdentity();
            gl.Translate(0.0f, 0.0f, -10.0f);
            gl.Translate(tetrahedron.GetPosition()[0], tetrahedron.GetPosition()[1], tetrahedron.GetPosition()[2]);
            gl.Rotate(rotationAngle, rotationAngle, rotationAngle);
            tetrahedron.Draw(gl);
        }
    }

    class Tetrahedron
    {
        private float[] vertices;
        private float[] position = { 0.0f, 0.0f, 0.0f };

        public Tetrahedron(float[] vertices)
        {
            this.vertices = vertices;
        }

        public void Draw(OpenGL gl)
        {
            int faceIndex = 0;

            gl.Begin(BeginMode.Triangles);

            for (int i = 0; i < vertices.Length; i += 9)
            {
                switch (faceIndex)
                {
                    case 0: //Face 1 color
                        gl.Color(0.9378f, 0.655f, 0.98f);
                        break;
                    case 1: //Face 2 color
                        gl.Color(0.725f, 0.659f, 0.98f);
                        break;
                    case 2: //Face 3 color
                        gl.Color(0.643f, 0.796f, 0.988f);
                        break;
                    case 3: //Face 4 color
                        gl.Color(0.565f, 0.95f, 0.988f);
                        break;
                }

                gl.Vertex(vertices[i], vertices[i + 1], vertices[i + 2]);
                gl.Vertex(vertices[i + 3], vertices[i + 4], vertices[i + 5]);
                gl.Vertex(vertices[i + 6], vertices[i + 7], vertices[i + 8]);

                faceIndex++;
            }

            gl.End();
        }

        public void Translate(float dx, float dy, float dz)
        {
            position[0] += dx;
            position[1] += dy;
            position[2] += dz;
        }

        public float[] GetPosition()
        {
            return position;
        }
    }
}