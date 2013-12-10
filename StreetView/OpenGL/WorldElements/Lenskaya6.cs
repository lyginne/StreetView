using StreetView.OpenGL.Elements;

namespace StreetView.OpenGL.WorldElements
{
    internal class Lenskaya6 : OpenGLObject
    {
        public Lenskaya6(float x, float z, int stages)
        {
            var prism = new Prism(x, 0, z, 20, stages*2.5f, 20, Textures.WhiteTexture);
            OpenGLObjects.Add(prism);
            ShadowObjects.Add(prism);
            CreateWindows(x,z,stages);
        }

        private void CreateWindows(float x, float z, int stages)
        {
            for (int stage = 0; stage < stages; stage++)
            {
                for (float windowX = x; windowX < x + 20-1e-15; windowX = windowX + (float)20/6)
                {
                    var window = new Rectangle(windowX + (((float)20/6) - 0.8f)/2, 0.5f + stage*2.5f, z - 0.01f, 0.8f, 1, 0,
                        Textures.WindowTexture);
                    OpenGLObjects.Add(window);
                    window = new Rectangle(windowX + (((float)20/6) - 0.8f)/2, 0.5f + stage*2.5f, z + 20 + 0.01f, 0.8f,
                        1, 0, Textures.WindowTexture);
                    OpenGLObjects.Add(window);

                }

                for (float windowZ = z; windowZ < z + 20-1e-5; windowZ = windowZ + (float)20/6)
                {
                    var window = new Rectangle(x - 0.01f, 0.5f + stage*2.5f, windowZ + (((float)20/6) - 0.8f)/2, 0, 1, 0.8f,
                        Textures.WindowTexture);
                    OpenGLObjects.Add(window);
                    window = new Rectangle(x + 20 + 0.01f, 0.5f + stage*2.5f, windowZ + (((float)20/6) - 0.8f)/2, 0, 1,
                        0.8f, Textures.WindowTexture);
                    OpenGLObjects.Add(window);

                }
            }
        }
    }
}
