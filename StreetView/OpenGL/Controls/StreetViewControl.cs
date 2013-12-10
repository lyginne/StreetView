using System;
using CsGL.OpenGL;
using System.Windows.Forms;
using StreetView.OpenGL.Elements;
using StreetView.OpenGL.WorldElements;
using Timer = System.Timers.Timer;

namespace StreetView.OpenGL.Controls
{   
    public class StreetViewControl : OpenGLControl
    {									// Object
        public delegate void RefreshDelegate();

        readonly float[] _lightPos = { 100f, 100f,-100f, 100f};			
        readonly float[] _lightAmb = { 100f, 100f, 100f, 100f};	
        readonly float[] _lightDif = { 0.6f, 0.6f, 0.6f, 1.0f};	
        readonly float[] _lightSpc = {-0.2f, -0.2f, -0.2f, 1.0f};

        readonly float[] _matAmb = {0.4f, 0.4f, 0.4f, 1.0f};
        readonly float[] _matDif = { 0.2f, 0.6f, 0.9f, 1.0f };
        readonly float[] _matSpc = { 0.0f, 0.0f, 0.0f, 1.0f };
        readonly float[] _matShn = { 0.0f };

        private float _yposition = 2;

        float _heading;
        private float _xpos;
        private float _zpos;

        private float _lookupdown;

        private readonly World _sector1 = new World();
        private GLUquadric _quadric;

        bool _ups = true;

        public StreetViewControl()
        {
            var timer = new Timer(50);
            timer.Elapsed += timer_Elapsed;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (_ups)
                _yposition++;
            else
                _yposition--;
            if (_yposition < 2)
            {
                _yposition = 2;
                _ups = true;
            }
            if (_yposition > 20)
            {
                _ups = false;
            }
            try
            {
                BeginInvoke(new RefreshDelegate(Refresh));
            }
            catch (InvalidOperationException)
            {}

        }

        public void InitGl()
        {
            GL.glEnable(GL.GL_TEXTURE_2D); 

            GL.glShadeModel(GL.GL_SMOOTH);							
            GL.glClearColor(0.0f, 0.0f, 0.0f, 0.5f);				
            GL.glClearDepth(1.0f);									
            GL.glClearStencil(0);									
            GL.glEnable(GL.GL_DEPTH_TEST);							
            GL.glDepthFunc(GL.GL_LEQUAL);								
            GL.glHint(GL.GL_PERSPECTIVE_CORRECTION_HINT, GL.GL_NICEST);	

            GL.glLightfv(GL.GL_LIGHT1, GL.GL_POSITION, _lightPos);		
            GL.glLightfv(GL.GL_LIGHT1, GL.GL_AMBIENT, _lightAmb);			
            GL.glLightfv(GL.GL_LIGHT1, GL.GL_DIFFUSE, _lightDif);			
            GL.glLightfv(GL.GL_LIGHT1, GL.GL_SPECULAR, _lightSpc);		
            GL.glEnable(GL.GL_LIGHT1);								
            GL.glEnable(GL.GL_LIGHTING);								

            GL.glMaterialfv(GL.GL_FRONT, GL.GL_AMBIENT, _matAmb);			
            GL.glMaterialfv(GL.GL_FRONT, GL.GL_DIFFUSE, _matDif);			
            GL.glMaterialfv(GL.GL_FRONT, GL.GL_SPECULAR, _matSpc);		
            GL.glMaterialfv(GL.GL_FRONT, GL.GL_SHININESS, _matShn);		

            GL.glCullFace(GL.GL_BACK);								
            GL.glClearColor(0.1f, 1.0f, 0.5f, 1.0f);

            _quadric = GL.gluNewQuadric();
            GL.gluQuadricNormals(_quadric, GL.GL_SMOOTH);
            GL.gluQuadricTexture(_quadric, (byte) GL.GL_TRUE);	

        }
	    void  CastShadow(Vertex vertex){
	        GL.glDisable(GL.GL_LIGHTING);
	        GL.glDepthMask((byte) GL.GL_FALSE);
	        GL.glDepthFunc(GL.GL_LEQUAL);

	        GL.glEnable(GL.GL_STENCIL_TEST);
	        GL.glColorMask(0, 0, 0, 0);
	        GL.glStencilFunc(GL.GL_ALWAYS, 1, 0xffffffff);

	        GL.glColorMask(1, 1, 1, 1);

	        GL.glColor4f(0.0f, 0.0f, 0.0f, 0.03f);
	        GL.glEnable(GL.GL_BLEND);
	        GL.glBlendFunc(GL.GL_SRC_ALPHA, GL.GL_ONE_MINUS_SRC_ALPHA);
	        GL.glStencilFunc(GL.GL_NOTEQUAL, 0, 0xffffffff);
            GL.glStencilOp(GL.GL_KEEP, GL.GL_KEEP, GL.GL_INCR);
	        GL.glPushMatrix();
            foreach (var triangle in _sector1.ShadowObjects)
            {
                for (int j = 0; j < 3; j++)
                {
                    var vertex1 = triangle.Vertex[j];
                    var vertex2 = triangle.Vertex[(j + 1) % 3];

                    var vertex3 = new Vertex((vertex1.X - vertex.X) * 1000,
                        (vertex1.Y - vertex.Y) * 1000, (vertex1.Z - vertex.Z) * 1000, 0, 0);
                    var vertex4 = new Vertex((vertex2.X - vertex.X) * 1000,
                        (vertex2.Y - vertex.Y) * 1000, (vertex2.Z - vertex.Z) * 1000, 0, 0);
                    GL.glBegin(GL.GL_TRIANGLE_STRIP);
                    GL.glVertex3f(vertex1.X, vertex1.Y, vertex1.Z);
                    GL.glVertex3f(vertex1.X + vertex3.X, vertex1.Y + vertex3.Y, vertex1.Z + vertex3.Z);
                    GL.glVertex3f(vertex2.X, vertex2.Y, vertex2.Z);
                    GL.glVertex3f(vertex2.X + vertex4.X, vertex2.Y + vertex4.Y, vertex2.Z + vertex4.Z);
                    GL.glEnd();
                }

            }
	        GL.glPopMatrix();
            GL.glStencilOp(GL.GL_KEEP, GL.GL_KEEP, GL.GL_DECR);
            GL.glPushMatrix();
            foreach (var triangle in _sector1.ShadowObjects)
            {
                for (int j = 0; j < 3; j++)
                {
                    var vertex1 = triangle.Vertex[j];
                    var vertex2 = triangle.Vertex[(j + 1) % 3];

                    var vertex3 = new Vertex((vertex1.X - vertex.X) * 1000,
                        (vertex1.Y - vertex.Y) * 1000, (vertex1.Z - vertex.Z) * 1000, 0, 0);
                    var vertex4 = new Vertex((vertex2.X - vertex.X) * 1000,
                        (vertex2.Y - vertex.Y) * 1000, (vertex2.Z - vertex.Z) * 1000, 0, 0);
                    GL.glBegin(GL.GL_TRIANGLE_STRIP);
                    GL.glVertex3f(vertex1.X, vertex1.Y, vertex1.Z);
                    GL.glVertex3f(vertex1.X + vertex3.X, vertex1.Y + vertex3.Y, vertex1.Z + vertex3.Z);
                    GL.glVertex3f(vertex2.X, vertex2.Y, vertex2.Z);
                    GL.glVertex3f(vertex2.X + vertex4.X, vertex2.Y + vertex4.Y, vertex2.Z + vertex4.Z);
                    GL.glEnd();
                }

            }
            GL.glPopMatrix();
	        GL.glDisable(GL.GL_BLEND);

	        GL.glDepthFunc(GL.GL_LEQUAL);
	        GL.glDepthMask((byte) GL.GL_TRUE);
	        GL.glEnable(GL.GL_LIGHTING);
	        GL.glDisable(GL.GL_STENCIL_TEST);
	        GL.glShadeModel(GL.GL_SMOOTH);
        }


        protected override void InitGLContext()
        {
            InitGl();
            SetupWorld();
        }

        public void SetupWorld()
        {
            var building = new Building(0, 0);
            var lenskya3 = new Building(-50, 50);
            var ground = new Ground();
            var lenskaya1 = new Lenskaya1(0, -50);
            var lenskaya2 = new Lenkaya2(-60,-50);
            var lenskaya4 = new Lenskaya4(-15, -50);
            var lenskaya6 = new Lenskaya6(70, -70, 15);
            var sky = new Sky();
            _sector1.Triangles.AddRange(sky.GetPolygons());
             _sector1.Triangles.AddRange(lenskaya6.GetPolygons());
            _sector1.Triangles.AddRange(lenskaya4.GetPolygons());
            _sector1.Triangles.AddRange(lenskaya2.GetPolygons());
            _sector1.Triangles.AddRange(lenskaya1.GetPolygons());
            _sector1.Triangles.AddRange(lenskya3.GetPolygons());
            _sector1.Triangles.AddRange(ground.GetPolygons());
            _sector1.Triangles.AddRange(building.GetPolygons());

            _sector1.ShadowObjects.AddRange(lenskaya6.GetShadowObjects());
            _sector1.ShadowObjects.AddRange(lenskaya4.GetShadowObjects());
            _sector1.ShadowObjects.AddRange(lenskaya2.GetShadowObjects());
            _sector1.ShadowObjects.AddRange(lenskaya1.GetShadowObjects());
            _sector1.ShadowObjects.AddRange(lenskya3.GetShadowObjects());
            _sector1.ShadowObjects.AddRange(building.GetShadowObjects());
        }

        public override void glDraw()
        {
            
            GL.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            GL.glLoadIdentity();

            GL.glRotatef(_lookupdown, 1.0f, 0.0f, 0.0f);
            GL.glRotatef(360.0f - _heading, 0.0f, 1.0f, 0.0f);

            GL.glTranslatef(-_xpos -25,  - 1.25f, -_zpos +20);

            DrawGLObject();
            GL.glBindTexture(GL.GL_TEXTURE_2D, Textures.BrickTexture.TextureBytes[0]);// Reset Modelview Matrix
            GL.glPushMatrix();
            GL.glTranslatef(25, _yposition, -40);
            GL.gluSphere(_quadric, 2, 32, 16);
            GL.glPopMatrix();
            CastShadow(new Vertex(499,499,499,0,0));

           
        }

        private void DrawGLObject()
        {
            foreach (Triangle triangle in _sector1.Triangles)
                    DrawTriangle(triangle);
        }

        public void DrawTriangle(Triangle triangle)
        {
            GL.glBindTexture(GL.GL_TEXTURE_2D, triangle.Texture.TextureBytes[0]);
            GL.glBegin(GL.GL_TRIANGLES);

            GL.glNormal3f(0.0f, 0.0f, 1.0f);

            foreach (var vertex in triangle.Vertex)
            {
                GL.glTexCoord2f(vertex.U, vertex.V);
                GL.glVertex3f(vertex.X, vertex.Y, vertex.Z);
            }

            GL.glEnd();
        }
        #region events
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var s = Size;

            GL.glViewport(0, 0, s.Width, s.Height);

            GL.glMatrixMode(GL.GL_PROJECTION);
            GL.glLoadIdentity();
            GL.gluPerspective(45.0f, s.Width / (double)s.Height, 0.1f, 10000.0f);
            GL.glMatrixMode(GL.GL_MODELVIEW);
            GL.glLoadIdentity();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Up)
            {
                _xpos -= (float)Math.Sin(_heading * Math.PI / 180.0) * 2f;
                _zpos -= (float)Math.Cos(_heading * Math.PI / 180.0) * 2f;
            }
            else if (keyData == Keys.Down)
            {
                _xpos += (float)Math.Sin(_heading * Math.PI / 180.0) * 2f;
                _zpos += (float)Math.Cos(_heading * Math.PI / 180.0) * 2f;
            }
            else if (keyData == Keys.Right)
                _heading -= 6.0f;
            else if (keyData == Keys.Left)
                _heading += 6.0f;
            else if (keyData== Keys.Escape)
                Application.Exit();
            else if (keyData == Keys.PageUp)			
                _lookupdown -= 6.0f;
            else if (keyData == Keys.PageDown)		
                _lookupdown += 6.0f;

            base.ProcessDialogKey(keyData);
            glDraw();  
            Refresh();

            return true;
        }
        #endregion events
    }
}
