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
            Triangle firstTriangle = null;
            Triangle secondTriangle = null;
            if (Math.Abs(xSize) < 1e-15)
            {
                firstTriangle = new Triangle(new Vertex(x, y, z, 0, 0), new Vertex(x, y, z+zSize, 0, 0), new Vertex(x, y + ySize, z + zSize, 0, 0), texture);
                secondTriangle = new Triangle(new Vertex(x, y, z, 0, 0), new Vertex(x, y + ySize, z, 0, 0), new Vertex(x, y + ySize, z + zSize, 0, 0), texture);
            }
           else if (Math.Abs(ySize) < 1e-15)
            {
                firstTriangle = new Triangle(new Vertex(x, y, z, 0, 0), new Vertex(x, y, z + zSize, 0, 0), new Vertex(x+xSize, y, z + zSize, 0, 0), texture);
                secondTriangle = new Triangle(new Vertex(x, y, z, 0, 0), new Vertex(x+xSize, y, z, 0, 0), new Vertex(x+xSize, y, z + zSize, 0, 0), texture);
            }
            else if (Math.Abs(zSize) < 1e-15)
            {
                firstTriangle = new Triangle(new Vertex(x, y, z, 0, 0), new Vertex(x+xSize, y, z, 0, 0), new Vertex(x+xSize, y + ySize, z, 0, 0), texture);
                secondTriangle = new Triangle(new Vertex(x, y, z, 0, 0), new Vertex(x, y + ySize, z, 0, 0), new Vertex(x+xSize, y + ySize, z, 0, 0), texture);
            }
            if (firstTriangle != null) Triangles.Add(firstTriangle);
            if (secondTriangle != null) Triangles.Add(secondTriangle);
        }
    }
}
