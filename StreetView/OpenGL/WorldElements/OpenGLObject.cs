using System.Collections.Generic;
using StreetView.OpenGL.Elements;

namespace StreetView.OpenGL.WorldElements
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
        public virtual List<Triangle> GetShadowObjects()
        {
            var triangles = new List<Triangle>();
            triangles.AddRange(Triangles);
            foreach (var shadowObject in ShadowObjects)
            {
                triangles.AddRange(shadowObject.GetPolygons());
            }
            return triangles;
        }


        protected readonly List<Triangle> Triangles = new List<Triangle>();
        public readonly List<OpenGLObject> ShadowObjects = new List<OpenGLObject>(); 
        protected readonly List<OpenGLObject> OpenGLObjects = new List<OpenGLObject>(); 

    }
}
