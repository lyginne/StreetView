using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StreetView.OpenGL.Elements;

namespace StreetView.OpenGL
{
    public abstract class OpenGLObject
    {
        public virtual List<Triangle> GetPolygons()
        {
            var triangles = new List<Triangle>();
            triangles.AddRange(Triangles);
            foreach (var openGLObject in OpenGLObjects)
            {
                triangles.AddRange(openGLObject.GetPolygons());
            }
            return triangles;
        }

        protected readonly List<Triangle> Triangles = new List<Triangle>();
        protected readonly List<OpenGLObject> OpenGLObjects = new List<OpenGLObject>(); 

    }
}
