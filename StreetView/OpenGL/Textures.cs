﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CsGL.OpenGL;
using StreetView.OpenGL.Elements;

namespace StreetView.OpenGL
{
    public  static class Textures
    {
        public static readonly Texture BrickTexture=new Texture("brick");
        public static readonly Texture WindowTexture = new Texture("window");
        public static readonly Texture SnowTexture = new Texture("snow");
        public static readonly Texture YellowWall = new Texture("yellow");
        public static readonly Texture SkyTexture = new Texture("sky");
        public static readonly Texture AsphalTexture = new Texture("asphalt");
        public static readonly Texture GreeTexture = new Texture("green");
        public static readonly Texture BeigeTexture = new Texture("beige");
        public static readonly Texture WhiteTexture = new Texture("white");
    }
}
