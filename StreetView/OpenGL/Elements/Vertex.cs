﻿namespace StreetView.OpenGL.Elements
{
    public class Vertex
    {
        //Coordinates
        public readonly float X;
        public readonly float Y;
        public readonly float Z;
        //Texture
        public readonly float U;
        public readonly float V;

        public Vertex(float x, float y, float z, float u, float v)
        {
            V = v;
            X = x;
            Y = y;
            Z = z;
            U = u;
        }
    }
}
