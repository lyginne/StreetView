using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetView.OpenGL.StreetElements
{
    class Ground : OpenGLObject
    {
        public Ground()
        {
            var rectangle = new Rectangle(-500f, 0, -500f, 1000f, 0, 1000f, 1000f,1000f,Textures.SnowTexture);
            OpenGLObjects.Add(rectangle);
            rectangle = new Rectangle(-500f, 0.1f, -6f,1000f,0,-6f,100f,1f, Textures.AsphalTexture);
            OpenGLObjects.Add(rectangle);
            rectangle = new Rectangle(-500f, 0.1f, -18f, 1000f, 0, -12f, 100f, 1f, Textures.AsphalTexture);
            OpenGLObjects.Add(rectangle);
            rectangle = new Rectangle(-500f, 0.1f, -36f, 1000f, 0, -6f, 100f, 1f, Textures.AsphalTexture);
            OpenGLObjects.Add(rectangle);
        }
    }
}
