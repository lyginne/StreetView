using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StreetView.OpenGL.Elements;

namespace StreetView.OpenGL.StreetElements
{
    class BrezhnevkaBlock : OpenGLObject
    {
        public BrezhnevkaBlock(float x, float z, bool alongX,int stages, Texture texture)
        {
            var prism = new Prism(x, 0, z, alongX ? 30 : 10, stages * 2.5f, alongX ? 10 : 30,texture);
            OpenGLObjects.Add(prism);
            CreateWindows(x,z,stages,alongX);
            
        }
        private void CreateWindows(float x, float z,int stages,bool alongX)
        {
            for (int stage = 0; stage < stages; stage++)
            {
                if (alongX)
                {
                    for (float windowX = x; windowX < x + 30; windowX = windowX + 30/8)
                    {
                        var window = new Rectangle(windowX + ((30/8) - 0.8f)/2, 0.5f + stage*2.5f, z - 0.01f, 0.8f, 1, 0,
                            Textures.WindowTexture);
                        OpenGLObjects.Add(window);

                    }
                    for (float windowX = x; windowX < x + 30; windowX = windowX + 30/8)
                    {
                        var window = new Rectangle(windowX + ((30/8) - 0.8f)/2, 0.5f + stage*2.5f, z + 10 + 0.01f, 0.8f,
                            1, 0, Textures.WindowTexture);
                        OpenGLObjects.Add(window);

                    }
                }
                else
                {
                    for (float windowZ = z; windowZ < z + 30; windowZ = windowZ + 30/8)
                    {
                        var window = new Rectangle(x - 0.01f, 0.5f + stage*2.5f, windowZ + ((30/8) - 0.8f)/2, 0, 1, 0.8f,
                            Textures.WindowTexture);
                        OpenGLObjects.Add(window);

                    }
                    for (float windowZ = z; windowZ < z + 30; windowZ = windowZ + 30/8)
                    {
                        var window = new Rectangle(x + 10 + 0.01f, 0.5f + stage*2.5f, windowZ + ((30/8) - 0.8f)/2, 0, 1,
                            0.8f, Textures.WindowTexture);
                        OpenGLObjects.Add(window);

                    }
                }

            }
        }
    }
}
