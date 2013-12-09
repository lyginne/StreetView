using System;
using System.Collections.Generic;
using System.Linq;
using CsGL.OpenGL;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using StreetView.OpenGL.Elements;
using StreetView.OpenGL.StreetElements;
using Rectangle = System.Drawing.Rectangle;

namespace StreetView.OpenGL.Controls
{   public class StreetViewControl : OpenGLControl
    {

    public void DrawBackground()
    {
        GL.glMatrixMode(GL.GL_PROJECTION);
        GL.glPushMatrix();
        GL.glOrtho(0, 1, 0, 1, 0, 1);

        GL.glMatrixMode(GL.GL_MODELVIEW);
        GL.glPushMatrix();
        GL.glLoadIdentity();

        // No depth buffer writes for background.
        GL.glDepthMask(0);

        GL.glBindTexture(GL.GL_TEXTURE_2D, Textures.SkyTexture.TextureBytes[0]);
        GL.glBegin(GL.GL_QUADS);
        {
            GL.glTexCoord2f(0f, 0f);
            GL.glVertex2f(0, 0);
            GL.glTexCoord2f(0f, 1f);
            GL.glVertex2f(0, 1f);
            GL.glTexCoord2f(1f, 1f);
            GL.glVertex2f(1f, 1f);
            GL.glTexCoord2f(1f, 0f);
            GL.glVertex2f(1f, 0);
        } GL.glEnd();

        GL.glDepthMask(1);

        GL.glPopMatrix();
        GL.glMatrixMode(GL.GL_PROJECTION);
        GL.glPopMatrix();
        GL.glMatrixMode(GL.GL_MODELVIEW);
    }
        private float _heading;
        private float _xpos;
        private float _zpos;

        private float _lookupdown;        // Camera up and down

        private readonly List<Texture> _listTextures = new List<Texture>();
        private readonly Sector _sector1 = new Sector();	// Our Model Goes Here:

        protected override void InitGLContext()
        {
            GL.glEnable(GL.GL_TEXTURE_2D);                                  // Enable Texture Mapping
            GL.glBlendFunc(GL.GL_SRC_ALPHA, GL.GL_ONE);						// Set The Blending Function For Translucency
            GL.glShadeModel(GL.GL_SMOOTH);									// Enable Smooth Shading
            GL.glClearColor(0.1f, 0.4f, 3.9f, 0f);						    // Black Background
            GL.glClearDepth(1.0f);											// Depth Buffer Setup
            GL.glEnable(GL.GL_DEPTH_TEST);									// Enables Depth Testing
            GL.glDepthFunc(GL.GL_LESS);										// The Type Of Depth Testing To Do
            GL.glHint(GL.GL_PERSPECTIVE_CORRECTION_HINT, GL.GL_NICEST);		// Really Nice Perspective Calculations

            LoadTextures();
            SetupWorld();
        }

        protected void LoadTextures()
        {
            _listTextures.Add(Textures.BrickTexture);
            _listTextures.Add(Textures.WindowTexture);
            _listTextures.Add(Textures.SnowTexture);
            _listTextures.Add(Textures.YellowWall);
            _listTextures.Add(Textures.AsphalTexture);
            _listTextures.Add(Textures.GreeTexture);
            _listTextures.Add(Textures.BeigeTexture);
            _listTextures.Add(Textures.WhiteTexture);
            DrawBackground();
        }

        public void SetupWorld()
        {
            var building = new Building(0, 0);
            var lenskya3 = new Building(-50, 50);
            var ground = new Ground();
            //var brezhnevka = new BrezhnevkaBlock(0, -50, false, 9);
            Lenskaya1 lenskaya1 = new Lenskaya1(0, -50);
            var lenskaya2 = new Lenkaya2(-60,-50);
            var lenskaya4 = new Lenskaya4(-15, -50);
            var lenskaya6 = new Lenskaya6(70, -70, 15);
            _sector1.Triangles.AddRange(lenskaya6.GetPolygons());
            _sector1.Triangles.AddRange(lenskaya4.GetPolygons());
            _sector1.Triangles.AddRange(lenskaya2.GetPolygons());
            _sector1.Triangles.AddRange(lenskaya1.GetPolygons());
            _sector1.Triangles.AddRange(lenskya3.GetPolygons());
            _sector1.Triangles.AddRange(ground.GetPolygons());
            _sector1.Triangles.AddRange(building.GetPolygons());
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
            var triangles = _sector1.Triangles.Where(x => x.Texture.TextureName.Equals(currentTexture.TextureName));
            foreach (var triangle in triangles)
            {
                    GL.glBegin(GL.GL_TRIANGLES);

                    GL.glNormal3f(0.0f, 0.0f, 1.0f);

                    foreach (var vertex in triangle.Vertex)
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
            Parent.Refresh();

            return true;           
        }
    }
}
