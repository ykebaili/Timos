using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpGL;
using timos.data.composantphysique;
using System.Drawing;
using timos.composantphysique.ConvertOpenGL;


namespace timos.data.composantphysique
{
    public class CVue3D : OpenGLCtrl
    {
        private C2iComposant3D m_composant = null;
        private I3DPrimitive[] m_primitives = new I3DPrimitive[0];

        private float m_fRotationY = 0;
        private float m_fRotationX = 0;
        private float m_fDepth = 0;


        //----------------------------
        public CVue3D()
        {
            InitializeComponent();
            gl.Enable(OpenGL.DEPTH_TEST);
            gl.DepthMask((byte)OpenGL.TRUE);
            gl.Enable(OpenGL.LIGHTING);
            gl.LightModel(OpenGL.LIGHT_MODEL_AMBIENT, new float[] { 0.3f, 0.3f, 0.3f, 1.0f });
            gl.Enable(OpenGL.COLOR_MATERIAL);
            gl.ColorMaterial(OpenGL.FRONT, OpenGL.AMBIENT_AND_DIFFUSE);

            this.OpenGLDraw += new System.Windows.Forms.PaintEventHandler(CVue3D_OpenGLDraw);
            gl.Enable(OpenGL.TEXTURE_2D);

            

        }

        void CVue3D_OpenGLDraw(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            CreateScene();
        }

        //----------------------------
        public C2iComposant3D Composant
        {
            get
            {
                return m_composant;
            }
            set
            {
                m_composant = value;
            }
        }


        //----------------------------
        public void Refresh3D()
        {
            if (m_composant != null)
            {
                m_primitives = m_composant.Get3DPrimitives().ToArray();
            }
            Refresh();
        }

        //----------------------------
        private void CreateScene()
        {
            if (m_composant == null)
                return;

            float[] buffer = new float[8503480];
           
                        
            gl = OpenGL;
            gl.Clear(OpenGL.COLOR_BUFFER_BIT | OpenGL.DEPTH_BUFFER_BIT);	// Clear The Screen And The Depth Buffer
            gl.MatrixMode(OpenGL.MODELVIEW);
            gl.ClearColor(1.0f, 1.0f, 1.0f, 0.0f);
            gl.Enable(OpenGL.LINE_SMOOTH);
            gl.BlendFunc(OpenGL.SRC_ALPHA, OpenGL.ONE_MINUS_SRC_ALPHA);
            gl.Enable(OpenGL.BLEND);
            //gl.Enable(OpenGL.NORMALIZE);
            gl.LoadIdentity();

            gl.ShadeModel(OpenGL.SMOOTH);
            gl.LightModel(OpenGL.LIGHT_MODEL_AMBIENT, new float[] { 1.0f, 1.0f, 1.0f, 1.0f });

            gl.Light(OpenGL.LIGHT0, OpenGL.AMBIENT, new float[] { 0.1f, 0.0f, 0.0f, 1.0f });
            gl.Light(OpenGL.LIGHT0, OpenGL.DIFFUSE, new float[] { 1.0f, 1.0f, 1.0f, 0.3f });
            gl.Light(OpenGL.LIGHT0, OpenGL.SPECULAR, new float[] { 1.0f, 1.0f, 1.0f, 1.1f });
            gl.Disable(OpenGL.LIGHT0);

            gl.Light(OpenGL.LIGHT1, OpenGL.AMBIENT, new float[] { 0.1f, 0.0f, 0.0f, 1.0f });
            gl.Light(OpenGL.LIGHT1, OpenGL.DIFFUSE, new float[] { 1.0f, 1.0f, 1.0f, 0.3f });
            gl.Light(OpenGL.LIGHT1, OpenGL.SPECULAR, new float[] { 1.0f, 1.0f, 1.0f, 1.1f });
            gl.Disable(OpenGL.LIGHT1);

            gl.PolygonMode(OpenGL.FRONT_AND_BACK, OpenGL.FILL);

            


            float fEchelle = (float)(1.0f/(Math.Max(Math.Max ( (double)m_composant.Size.With, (double)m_composant.Size.Depth), (double)m_composant.Size.Height )));
            //gl.Translate(0, 0, -m_fDepth/100);
            gl.Scale(fEchelle, fEchelle, fEchelle);
            double fDepth = m_composant.Size.Depth * 4+m_fDepth*m_composant.Size.Depth/20;
            //gl.Translate(-0, 0, -3*m_composant.Size.Depth);
            gl.LookAt(m_composant.Size.With / 2 +fDepth*Math.Cos ( (m_fRotationY-90)/180.0*Math.PI ), 
                m_composant.Size.Height / 2 + fDepth * Math.Cos((m_fRotationX-90)/180.0*Math.PI),
                fDepth * Math.Sin((m_fRotationY - 90) / 180.0 * Math.PI) * Math.Sin((m_fRotationX - 90) / 180.0 * Math.PI), 
                m_composant.Size.With / 2, m_composant.Size.Height / 2, m_composant.Size.Depth/2, 0, 1, 0);
 
            gl.Light(OpenGL.LIGHT0, OpenGL.POSITION, new float[] { -m_composant.Size.With, m_composant.Size.Height, -m_composant.Size.Depth });
            gl.Light(OpenGL.LIGHT0, OpenGL.SPOT_DIRECTION, new float[] { 0.0f, 0.0f, -.0f });
            gl.Light(OpenGL.LIGHT0, OpenGL.CONSTANT_ATTENUATION, 0.0001f);
            gl.Light(OpenGL.LIGHT1, OpenGL.POSITION, new float[] { m_composant.Size.With, m_composant.Size.Height, -m_composant.Size.Depth });
            gl.Light(OpenGL.LIGHT1, OpenGL.SPOT_DIRECTION, new float[] { 0.0f, 0.0f, -.0f });

            //gl.Rotate(m_fRotationY, 0.0f, 1.0f, 0.0f);
            //gl.Rotate(m_fRotationX, 1.0f, 0.0f, 0.0f);
            //gl.Translate(-m_composant.Size.With/2, -m_composant.Size.Height/2, 0);*/

            

            

            //gl.Perspective(45.0f, 1.0f, -m_composant.Size.Height, 0);
            CConvertisseurOpenGL.ConvertScene(m_primitives, gl);

            uint nErreur = gl.GetError();

        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // CVue3D
            // 
            this.Name = "CVue3D";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CVue3D_MouseMove);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CVue3D_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CVue3D_MouseUp);
            this.ResumeLayout(false);

        }

        private Point m_ptStartRotation;
        private void CVue3D_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left || e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                m_ptStartRotation = new Point(e.X, e.Y);
                Capture = true;
            }
        }

        private void CVue3D_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                m_fRotationY += m_ptStartRotation.X - e.X;
                m_fRotationX -= m_ptStartRotation.Y - e.Y;
                if (m_fRotationX > 95)
                    m_fRotationX = 95;
                if (m_fRotationX < -95)
                    m_fRotationX = -95;
                if (m_fRotationX > 360)
                    m_fRotationX = m_fRotationX - 360;
                if (m_fRotationX < -360)
                    m_fRotationX = m_fRotationX + 360;
                m_ptStartRotation = new Point(e.X, e.Y);
                Refresh();
            }
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                m_fDepth += m_ptStartRotation.Y - e.Y;
                m_ptStartRotation = new Point(e.X, e.Y);
                Refresh();
            }
        }

        private void CVue3D_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Capture = false;
        }
    }
}
