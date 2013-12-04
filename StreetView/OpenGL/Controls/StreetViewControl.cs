using System;
using System.Collections.Generic;
using System.Linq;
using CsGL.OpenGL;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using StreetView.OpenGL.Elements;

namespace StreetView.OpenGL.Controls
{   public class StreetViewControl : OpenGLControl
    {
        private float _heading;
        private float _xpos;
        private float _zpos;

        private float _lookupdown;        // Camera up and down

        private readonly List<Texture> _listTextures = new List<Texture>();
        private readonly Sector _sector1 = new Sector();	// Our Model Goes Here:

        protected override void InitGLContext()
        {
            LoadTextures();

            GL.glEnable(GL.GL_TEXTURE_2D);									// Enable Texture Mapping
            GL.glBlendFunc(GL.GL_SRC_ALPHA, GL.GL_ONE);						// Set The Blending Function For Translucency
            GL.glShadeModel(GL.GL_SMOOTH);									// Enable Smooth Shading
            GL.glClearColor(0.1f, 0.4f, 3.9f, 0f);						    // Black Background
            GL.glClearDepth(1.0f);											// Depth Buffer Setup
            GL.glEnable(GL.GL_DEPTH_TEST);									// Enables Depth Testing
            GL.glDepthFunc(GL.GL_LESS);										// The Type Of Depth Testing To Do
            GL.glHint(GL.GL_PERSPECTIVE_CORRECTION_HINT, GL.GL_NICEST);		// Really Nice Perspective Calculations

            SetupWorld();
        }

        private void LoadTexture(string fileName, string textureName)
        {
            Bitmap image = null;
            try
            {
                image = new Bitmap(fileName);
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Could not load " + fileName + ".  Please make sure that Data is a subfolder from where the application is running.", "Error", MessageBoxButtons.OK);
            }


            if (image != null)
            {
                image.RotateFlip(RotateFlipType.RotateNoneFlipY);
                System.Drawing.Imaging.BitmapData bitmapdata;
                Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);

                bitmapdata = image.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

                Texture texture = new Texture(textureName);
                _listTextures.Add(texture);
                GL.glGenTextures(1, _listTextures.Last().TextureBytes);

                // Create Nearest Filtered Texture
                GL.glBindTexture(GL.GL_TEXTURE_2D, _listTextures.Last().TextureBytes[0]);
                GL.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, GL.GL_NEAREST);
                GL.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, GL.GL_NEAREST);
                GL.glTexImage2D(GL.GL_TEXTURE_2D, 0, (int)GL.GL_RGB, image.Width, image.Height, 0, GL.GL_BGR_EXT, GL.GL_UNSIGNED_BYTE, bitmapdata.Scan0);

                image.UnlockBits(bitmapdata);
                image.Dispose();

            }
        }

        protected void LoadTextures()
        {
            LoadTexture(@"Data\glass.bmp", "glass");
            LoadTexture(@"Data\grass.bmp", "grass");
            LoadTexture(@"Data\green.bmp", "green");
            LoadTexture(@"Data\red.bmp", "red");
            LoadTexture(@"Data\yellow.bmp", "yellow");
            LoadTexture(@"Data\white.bmp", "white");
            LoadTexture(@"Data\road.bmp", "road");
            LoadTexture(@"Data\wood.bmp", "wood");
            LoadTexture(@"Data\tree.bmp", "tree");
        }

        public void SetupWorld()
        {
            string path = @"Data\World.txt";
            StreamReader filein = null;
            try
            {
                // If the file doesn't exist or can't be found, a FileNotFoundException is thrown instead of
                // just returning null, or if the directory as a whole isn't there, a DirectoryNotFound
                // exception will be thrown
                filein = new StreamReader(path, System.Text.Encoding.ASCII);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Could not load " + path + ".  Please make sure that Data is a subfolder from where the application is running.", "Error", MessageBoxButtons.OK);
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("Could not load " + path + ".  Please make sure that Data is a subfolder from where the application is running.", "Error", MessageBoxButtons.OK);
            }

            if (filein != null)
            {
                StreetElements.Prism prism;
                //line.IndexOf("NUMPOLLIES");
                string line = filein.ReadLine();
                string[] polystring = line.Split(' ');
                int count = int.Parse(polystring[1]);
                for (int i = 0; i < count; i++)
                {
                    var triangleVertexes = new Vertex[3];
                    for (int j = 0; j < 3; j++)
                    {
                        line = "";
                        while (line.Trim().Length == 0)
                            line = filein.ReadLine();
                        triangleVertexes[j] = Vertex.Parse(line);
                    }
                    Texture texture = _listTextures.FirstOrDefault(x => x.TextureName == Texture.ParseTextureName(line));
                    _sector1.Triangles.Add(new Triangle(triangleVertexes, texture));
                    prism = new StreetElements.Prism(0, 0, 0, 20f, 20f, 20f, texture);
                    _sector1.Triangles.AddRange(prism.Triangles);
                    line = "";
                }
                filein.Close();
                
                
            }
        }

        public override void glDraw()
        {
            GL.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            GL.glLoadIdentity();

            GL.glRotatef(_lookupdown, 1.0f, 0.0f, 0.0f);
            GL.glRotatef(360.0f - _heading, 0.0f, 1.0f, 0.0f);

            GL.glTranslatef(-_xpos -25,  - 1.25f, -_zpos +20);//камера

            foreach (Texture currentTexture in _listTextures)
                    DrawTrianglesWithTexture(currentTexture);
        }

        public void DrawTrianglesWithTexture(Texture currentTexture)
        {
            GL.glBindTexture(GL.GL_TEXTURE_2D, currentTexture.TextureBytes[0]);
            IEnumerable<Triangle> triangles = _sector1.Triangles.Where(x => x.Texture.TextureName.Equals(currentTexture.TextureName));
            foreach (Triangle triangle in triangles)
            {
                    GL.glBegin(GL.GL_TRIANGLES);

                    GL.glNormal3f(0.0f, 0.0f, 1.0f);

                    foreach (Vertex vertex in triangle.Vertex)
                    {
                        GL.glTexCoord2f(vertex.U, vertex.V);
                        GL.glVertex3f(vertex.X, vertex.Y, vertex.Z);
                    }

                    GL.glEnd();
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            Size s = Size;

            GL.glViewport(0, 0, s.Width, s.Height);

            GL.glMatrixMode(GL.GL_PROJECTION);
            GL.glLoadIdentity();
            GL.gluPerspective(45.0f, s.Width / (double)s.Height, 0.1f, 100.0f);
            GL.glMatrixMode(GL.GL_MODELVIEW);
            GL.glLoadIdentity();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Up)
            {
                _xpos -= (float)Math.Sin(_heading * Math.PI / 180.0) * 0.2f;
                _zpos -= (float)Math.Cos(_heading * Math.PI / 180.0) * 0.2f;
            }
            else if (keyData == Keys.Down)
            {
                _xpos += (float)Math.Sin(_heading * Math.PI / 180.0) * 0.2f;
                _zpos += (float)Math.Cos(_heading * Math.PI / 180.0) * 0.2f;
            }
            else if (keyData == Keys.Right)
                _heading -= 2.0f;
            else if (keyData == Keys.Left)
                _heading += 2.0f;
            else if (keyData== Keys.Escape)
                Application.Exit();
            else if (keyData == Keys.PageUp)			
                _lookupdown -= 2.0f;
            else if (keyData == Keys.PageDown)		
                _lookupdown += 2.0f;

            base.ProcessDialogKey(keyData);
            glDraw();            
            Parent.Refresh();

            return true;           
        }
    }
}
