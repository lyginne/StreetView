using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CsGL.OpenGL;
using StreetView.OpenGL.Elements;

namespace StreetView.OpenGL
{
    public  static class Textures
    {
        private static Texture _brickTexture;

        public static Texture BrickTexture
        {
            get
            {
                if (_brickTexture != null)
                    return _brickTexture;
                _brickTexture= GetTextureWithName("brick");
                return _brickTexture;

            }
        }
        private static Texture _windowTexture;

        public static Texture WindowTexture
        {
            get
            {
                if (_windowTexture != null)
                    return _windowTexture;
                _windowTexture= GetTextureWithName("window");
                return _windowTexture;

            }
        }

        private static Texture _snowTexture;

        public static Texture SnowTexture
        {
            get
            {
                if (_snowTexture != null)
                    return _snowTexture;
                _snowTexture = GetTextureWithName("snow");
                return _snowTexture;

            }
        }
        private static Texture _skyTexture;

        public static Texture SkyTexture
        {
            get
            {
                if (_skyTexture != null)
                    return _skyTexture;
                _skyTexture = GetTextureWithName("sky");
                return _skyTexture;

            }
        }

        private static Texture GetTextureWithName(string name)
        {
            Bitmap image = null;
            try
            {
                image = new Bitmap(@"Data/"+name +".bmp");
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Could not load texture" +name+ ".  Please make sure that Data is a subfolder from where the application is running.", "Error", MessageBoxButtons.OK);
            }

            Texture texture = null;
            if (image != null)
            {
                image.RotateFlip(RotateFlipType.Rotate90FlipY);
                System.Drawing.Imaging.BitmapData bitmapdata;
                Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);

                bitmapdata = image.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

                texture = new Texture(name);
                GL.glGenTextures(1, texture.TextureBytes);

                // Create Nearest Filtered Texture
                GL.glBindTexture(GL.GL_TEXTURE_2D, texture.TextureBytes[0]);
                GL.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, GL.GL_NEAREST);
                GL.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, GL.GL_NEAREST);
                GL.glTexImage2D(GL.GL_TEXTURE_2D, 0, (int)GL.GL_RGB, image.Width, image.Height, 0, GL.GL_BGR_EXT, GL.GL_UNSIGNED_BYTE, bitmapdata.Scan0);

                image.UnlockBits(bitmapdata);
                image.Dispose();


            }
            return texture;
            
        }
    }
}
