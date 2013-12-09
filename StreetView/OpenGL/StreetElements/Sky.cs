using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetView.OpenGL.StreetElements
{
    class Sky : OpenGLObject
    {
        public Sky()
        {
            var rectangle = new Rectangle(-500f, 0, -500f, 0, 1000f, 1000f, 5f, 5f, Textures.SkyTexture);
            OpenGLObjects.Add(rectangle);
            rectangle = new Rectangle(-500f, 0, -500f, 1000, 1000f, 0, 5f, 5f, Textures.SkyTexture);
            OpenGLObjects.Add(rectangle);
            rectangle = new Rectangle(-500f, 0, 500f, 1000, 1000f, 0, 5f, 5f, Textures.SkyTexture);
            OpenGLObjects.Add(rectangle);
            rectangle = new Rectangle(500f, 0, -500f, 0, 1000f, 1000, 5f, 5f, Textures.SkyTexture);
            OpenGLObjects.Add(rectangle);
            rectangle = new Rectangle(-500f, 1000f, -500f, 1000f, 0, 1000f, 5f, 5f, Textures.SkyTexture);
            OpenGLObjects.Add(rectangle);
        }
    }
}
