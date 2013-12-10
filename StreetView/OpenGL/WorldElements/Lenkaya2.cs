using System.Collections.Generic;
using StreetView.OpenGL.Elements;

namespace StreetView.OpenGL.WorldElements
{
    public class Lenkaya2 : OpenGLObject
    {
        public Lenkaya2(float x, float y)
        {
            var brezhnevka = new BrezhnevkaBlock(-105, -60, true, 9, Textures.GreeTexture);
            OpenGLObjects.Add(brezhnevka);
            ShadowObjects.Add(brezhnevka);
            brezhnevka = new BrezhnevkaBlock(-135, -60, true, 9, Textures.GreeTexture);
            OpenGLObjects.Add(brezhnevka);
            ShadowObjects.Add(brezhnevka);
            brezhnevka = new BrezhnevkaBlock(-165, -60, true, 9, Textures.GreeTexture);
            OpenGLObjects.Add(brezhnevka);
            ShadowObjects.Add(brezhnevka);
            brezhnevka = new BrezhnevkaBlock(-195, -60, true, 9, Textures.GreeTexture);
            OpenGLObjects.Add(brezhnevka);
            ShadowObjects.Add(brezhnevka);
            brezhnevka = new BrezhnevkaBlock(-225, -60, true, 9, Textures.GreeTexture);
            OpenGLObjects.Add(brezhnevka);
            ShadowObjects.Add(brezhnevka);
            brezhnevka = new BrezhnevkaBlock(-85, -90, false, 9, Textures.GreeTexture);
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
