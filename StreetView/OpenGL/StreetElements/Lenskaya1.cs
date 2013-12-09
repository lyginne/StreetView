using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace StreetView.OpenGL.StreetElements
{
    public class Lenskaya1 :OpenGLObject
    {
        public Lenskaya1(float x, float y){
            BrezhnevkaBlock brezhnevka = new BrezhnevkaBlock(-85,10,false,9,Textures.BeigeTexture);
            OpenGLObjects.Add(brezhnevka);
            brezhnevka = new BrezhnevkaBlock(-105, 0, true, 9, Textures.BeigeTexture);
            OpenGLObjects.Add(brezhnevka);
            brezhnevka = new BrezhnevkaBlock(-135, 0, true, 9, Textures.BeigeTexture);
            OpenGLObjects.Add(brezhnevka);
            brezhnevka = new BrezhnevkaBlock(-165, 0, true, 9, Textures.BeigeTexture);
            OpenGLObjects.Add(brezhnevka);
            brezhnevka = new BrezhnevkaBlock(-195, 0, true, 9, Textures.BeigeTexture);
            OpenGLObjects.Add(brezhnevka);
            brezhnevka = new BrezhnevkaBlock(-225, 0, true, 9, Textures.BeigeTexture);
            OpenGLObjects.Add(brezhnevka);
        }
    }
}
