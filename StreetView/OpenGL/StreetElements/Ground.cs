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
        }
    }
}
