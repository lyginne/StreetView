using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetView.OpenGL.StreetElements
{
    class Lenskaya4 : OpenGLObject
    {
        public Lenskaya4(float x, float y)
        {
            var brezhnevka = new BrezhnevkaBlock(-15, -60, true, 3,Textures.YellowWall);
            OpenGLObjects.Add(brezhnevka);
            brezhnevka = new BrezhnevkaBlock(-25, -79, false, 3, Textures.YellowWall);
            OpenGLObjects.Add(brezhnevka);
            brezhnevka = new BrezhnevkaBlock(15, -79, false, 3, Textures.YellowWall);
            OpenGLObjects.Add(brezhnevka);
        }
    }
}
