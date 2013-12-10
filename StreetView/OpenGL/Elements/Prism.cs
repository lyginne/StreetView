using StreetView.OpenGL.WorldElements;

namespace StreetView.OpenGL.Elements
{
    class Prism : OpenGLObject
    {
        public Prism(float x, float y, float z, float xSize, float ySize, float zSize, Texture texture)
        {
            var leftWall = new Rectangle(x, y, z, 0, ySize, zSize, texture);
            var rigthWall = new Rectangle(x + xSize, y, z, 0, ySize, zSize, texture);

            var frontWall = new Rectangle(x, y, z, xSize, ySize, 0, texture);
            var backWall = new Rectangle(x, y, z + zSize, xSize, ySize, 0, texture);

            var floor = new Rectangle(x, y, z, xSize, 0, zSize,texture);
            var ceiling = new Rectangle(x, y + ySize, z, xSize, 0, zSize, texture);

            OpenGLObjects.Add(leftWall);
            OpenGLObjects.Add(frontWall);
            OpenGLObjects.Add(rigthWall);
            OpenGLObjects.Add(backWall);
            OpenGLObjects.Add(ceiling);
            OpenGLObjects.Add(floor);
        }
    }
}
