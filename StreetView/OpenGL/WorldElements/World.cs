using System.Collections.Generic;
using StreetView.OpenGL.Elements;

namespace StreetView.OpenGL.WorldElements
{
    public class World
    {
       public readonly List<Triangle> Triangles = new List<Triangle>();
        public readonly List<Triangle> ShadowObjects = new List<Triangle>(); 
    }
}
