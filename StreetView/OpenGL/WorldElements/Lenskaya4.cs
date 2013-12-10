using System.Collections.Generic;
using StreetView.OpenGL.Elements;

namespace StreetView.OpenGL.WorldElements
{
    class Lenskaya4 : OpenGLObject
    {
        public Lenskaya4(float x, float y)
        {
            var brezhnevka = new BrezhnevkaBlock(-15, -60, true, 3,Textures.YellowWall);
            OpenGLObjects.Add(brezhnevka);
            ShadowObjects.Add(brezhnevka);
            brezhnevka = new BrezhnevkaBlock(-25, -79, false, 3, Textures.YellowWall);
            OpenGLObjects.Add(brezhnevka);
            ShadowObjects.Add(brezhnevka);
            brezhnevka = new BrezhnevkaBlock(15, -79, false, 3, Textures.YellowWall);
            OpenGLObjects.Add(brezhnevka);
            ShadowObjects.Add(brezhnevka);
        }
        public override List<Triangle> GetShadowObjects()
        {
            var triangles = new List<Triangle>();
            foreach (var openGLObject in ShadowObjects)
            {
                triangles.AddRange(openGLObject.GetShadowObjects());
            }
            return triangles;

        }
    }
}
