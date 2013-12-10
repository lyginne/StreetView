using System.Collections.Generic;
using StreetView.OpenGL.Elements;

namespace StreetView.OpenGL.WorldElements
{
    public class Lenskaya1 :OpenGLObject
    {
        public Lenskaya1(float x, float y){
            var brezhnevka = new BrezhnevkaBlock(-85,10,false,9,Textures.BeigeTexture);
            OpenGLObjects.Add(brezhnevka);
            ShadowObjects.Add(brezhnevka);
            brezhnevka = new BrezhnevkaBlock(-105, 0, true, 9, Textures.BeigeTexture);
            OpenGLObjects.Add(brezhnevka);
            ShadowObjects.Add(brezhnevka);
            brezhnevka = new BrezhnevkaBlock(-135, 0, true, 9, Textures.BeigeTexture);
            OpenGLObjects.Add(brezhnevka);
            ShadowObjects.Add(brezhnevka);
            brezhnevka = new BrezhnevkaBlock(-165, 0, true, 9, Textures.BeigeTexture);
            OpenGLObjects.Add(brezhnevka);
            ShadowObjects.Add(brezhnevka);
            brezhnevka = new BrezhnevkaBlock(-195, 0, true, 9, Textures.BeigeTexture);
            OpenGLObjects.Add(brezhnevka);
            ShadowObjects.Add(brezhnevka);
            brezhnevka = new BrezhnevkaBlock(-225, 0, true, 9, Textures.BeigeTexture);
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
