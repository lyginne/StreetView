using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StreetView.OpenGL.Elements;

namespace StreetView.OpenGL.StreetElements
{
    //todo maybe you should make in not so ortogonar or rename (move to another namespace)
    class Rectangle : OpenGLObject
    {

        public Rectangle(float x, float y, float z, float xSize, float ySize, float zSize, Texture texture)
        {
            Triangle firstTriangle = null;
            Triangle secondTriangle = null;
            if (Math.Abs(xSize) < 1e-15)
            {
                firstTriangle = new Triangle(new Vertex(x, y, z, 0, 0), new Vertex(x, y, z+zSize, 0, 1f), new Vertex(x, y + ySize, z + zSize, 1f, 1f), texture);
                secondTriangle = new Triangle(new Vertex(x, y, z, 0, 0), new Vertex(x, y + ySize, z, 1f, 0), new Vertex(x, y + ySize, z + zSize, 1f, 1f), texture);
            }
           else if (Math.Abs(ySize) < 1e-15)
            {
                firstTriangle = new Triangle(new Vertex(x, y, z, 0, 0), new Vertex(x, y, z + zSize, 0, 1f), new Vertex(x + xSize, y, z + zSize, 1f, 1f), texture);
                secondTriangle = new Triangle(new Vertex(x, y, z, 0, 0), new Vertex(x+xSize, y, z, 1f, 0), new Vertex(x+xSize, y, z + zSize, 1f, 1f), texture);
            }
            else if (Math.Abs(zSize) < 1e-15)
            {
                firstTriangle = new Triangle(new Vertex(x, y, z, 0, 0), new Vertex(x+xSize, y, z, 0, 1f), new Vertex(x+xSize, y + ySize, z, 1f, 1f), texture);
                secondTriangle = new Triangle(new Vertex(x, y, z, 0, 0), new Vertex(x, y + ySize, z, 1f, 0), new Vertex(x+xSize, y + ySize, z, 1f, 1f), texture);
            }
            if (firstTriangle != null) Triangles.Add(firstTriangle);
            if (secondTriangle != null) Triangles.Add(secondTriangle);
        }
        
        public Rectangle(float x, float y, float z, float xSize, float ySize, float zSize, float xTexture, float yTexture, Texture texture)
        {
            Triangle firstTriangle = null;
            Triangle secondTriangle = null;
            if (Math.Abs(xSize) < 1e-15)
            {
                firstTriangle = new Triangle(new Vertex(x, y, z, 0, 0), new Vertex(x, y, z+zSize, 0, yTexture), new Vertex(x, y + ySize, z + zSize, xTexture, yTexture), texture);
                secondTriangle = new Triangle(new Vertex(x, y, z, 0, 0), new Vertex(x, y + ySize, z, xTexture, 0), new Vertex(x, y + ySize, z + zSize, xTexture, yTexture), texture);
            }
           else if (Math.Abs(ySize) < 1e-15)
            {
                firstTriangle = new Triangle(new Vertex(x, y, z, 0, 0), new Vertex(x, y, z + zSize, 0, yTexture), new Vertex(x + xSize, y, z + zSize, xTexture, yTexture), texture);
                secondTriangle = new Triangle(new Vertex(x, y, z, 0, 0), new Vertex(x+xSize, y, z,xTexture, 0), new Vertex(x+xSize, y, z + zSize, xTexture, yTexture), texture);
            }
            else if (Math.Abs(zSize) < 1e-15)
            {
                firstTriangle = new Triangle(new Vertex(x, y, z, 0, 0), new Vertex(x+xSize, y, z, 0, yTexture), new Vertex(x+xSize, y + ySize, z, xTexture, yTexture), texture);
                secondTriangle = new Triangle(new Vertex(x, y, z, 0, 0), new Vertex(x, y + ySize, z, xTexture, 0), new Vertex(x+xSize, y + ySize, z, xTexture, yTexture), texture);
            }
            if (firstTriangle != null) Triangles.Add(firstTriangle);
            if (secondTriangle != null) Triangles.Add(secondTriangle);
        }
    }
}
