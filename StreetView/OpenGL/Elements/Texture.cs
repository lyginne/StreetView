using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using CsGL.OpenGL;

namespace StreetView.OpenGL.Elements
{
    public class Texture
    {
        public readonly uint[] TextureBytes;
        public readonly string TextureName;

        public Texture(string textureName){
            TextureBytes = new uint[1];
            TextureName = textureName;
            Bitmap image = null;
            try
            {
                image = new Bitmap(@"Data/" + textureName + ".bmp");
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Could not load texture" + textureName + ".", "Error", MessageBoxButtons.OK);
            }

            if (image != null)
            {
                image.RotateFlip(RotateFlipType.Rotate90FlipY);
                var rect = new System.Drawing.Rectangle(0, 0, image.Width, image.Height);

                BitmapData bitmapdata = image.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

                //Texture texture = new Texture(textureName);
                GL.glGenTextures(1, TextureBytes);

                // Create Nearest Filtered Texture
                GL.glBindTexture(GL.GL_TEXTURE_2D, TextureBytes[0]);
                GL.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, GL.GL_NEAREST);
                GL.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, GL.GL_NEAREST);
                GL.glTexImage2D(GL.GL_TEXTURE_2D, 0, (int)GL.GL_RGB, image.Width, image.Height, 0, GL.GL_BGR_EXT, GL.GL_UNSIGNED_BYTE, bitmapdata.Scan0);

                image.UnlockBits(bitmapdata);
                image.Dispose();


            }
        }
    }
}
