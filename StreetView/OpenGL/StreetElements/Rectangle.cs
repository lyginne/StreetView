using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StreetView.OpenGL.Elements;

namespace StreetView.OpenGL.StreetElements
{
    //todo maybe you should make in not so ortogonar or rename (move to another namespace)
    class Rectangle
    {
        public readonly List<Triangle> Triangles = new List<Triangle>();

        public Rectangle(float x, float y, float z, float xSize, float ySize, float zSize, Texture texture)
        {
            
            var firstTriangle = new Triangle(new Vertex(x,y,z,0,0),new Vertex(x+xSize,y+ySize,z,0,0),new Vertex(x+xSize,y+ySize,z+zSize,0,0), texture);
            var secondTriangle = new Triangle(new Vertex(x, y, z, 0, 0), new Vertex(x + xSize, y + ySize, z, 0, 0), new Vertex(x + xSize, y + ySize, z + zSize, 0, 0), texture);
            Triangles.Add(firstTriangle);
            Triangles.Add(secondTriangle);
        }
    }
}
