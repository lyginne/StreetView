using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetView.OpenGL.StreetElements
{
    public class Lenkaya2 : OpenGLObject
    {
        public Lenkaya2(float x, float y)
        {
            var brezhnevka = new BrezhnevkaBlock(-105, -60, true, 9, Textures.GreeTexture);
            OpenGLObjects.Add(brezhnevka);
            brezhnevka = new BrezhnevkaBlock(-135, -60, true, 9, Textures.GreeTexture);
            OpenGLObjects.Add(brezhnevka);
            brezhnevka = new BrezhnevkaBlock(-165, -60, true, 9, Textures.GreeTexture);
            OpenGLObjects.Add(brezhnevka);
            brezhnevka = new BrezhnevkaBlock(-195, -60, true, 9, Textures.GreeTexture);
            OpenGLObjects.Add(brezhnevka);
            brezhnevka = new BrezhnevkaBlock(-225, -60, true, 9, Textures.GreeTexture);
            OpenGLObjects.Add(brezhnevka);
            brezhnevka = new BrezhnevkaBlock(-85, -90, false, 9, Textures.GreeTexture);
            OpenGLObjects.Add(brezhnevka); 
        }
    }
}
