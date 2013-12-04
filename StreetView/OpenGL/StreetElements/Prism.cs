using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StreetView.OpenGL.Elements;

namespace StreetView.OpenGL.StreetElements
{
    class Prism
    {
        private readonly List<Rectangle> _rectangles = new List<Rectangle>();  
        public List<Triangle> Triangles
        {
            get
            {
                var triangles = new List<Triangle>();
                foreach (var rectangle in _rectangles)
                {
                    triangles.AddRange(rectangle.Triangles);
                }
                return triangles;

            }
        }

        public Prism(float x, float y, float z, float xSize, float ySize, float zSize, Texture texture)
        {
            //Стены
            var leftWall = new Rectangle(x, y, z, 0, ySize, zSize, texture);
            var rigthWall = new Rectangle(x + xSize, y, z, 0, ySize, zSize, texture);

            var frontWall = new Rectangle(x, y, z, xSize, ySize, 0, texture);
            var backWall = new Rectangle(x, y, z + zSize, xSize, ySize, 0, texture);

            var floor = new Rectangle(x, y, z, xSize, 0, zSize,texture);
            var ceiling = new Rectangle(x, y + ySize, z, xSize, 0, zSize, texture);
            _rectangles.Add(leftWall);
            _rectangles.Add(frontWall);
            _rectangles.Add(rigthWall);
            _rectangles.Add(backWall);
            _rectangles.Add(ceiling);
            _rectangles.Add(floor);
        }
    }
}
