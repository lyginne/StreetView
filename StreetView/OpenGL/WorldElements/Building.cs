using StreetView.OpenGL.Elements;

namespace StreetView.OpenGL.WorldElements
{
    public class Building : OpenGLObject
    {
        public Building(float x, float z) {
            var prism = new Prism(x,0,z,10f,15*2.5f, 20f,Textures.BrickTexture);
            OpenGLObjects.Add(prism);
            ShadowObjects.Add(prism);
            prism = new Prism(x+7.5f,0,z+15f,12.5f,13*2.5f,10f,Textures.BrickTexture);
            OpenGLObjects.Add(prism);
            ShadowObjects.Add(prism);
            prism = new Prism(x, 0, z + 10f, -15f, 14 * 2.5f, 10f, Textures.BrickTexture);
            OpenGLObjects.Add(prism);
            ShadowObjects.Add(prism);
            prism = new Prism(x-5f, 0, z + 20f, 10f, 14 * 2.5f, 15f, Textures.BrickTexture);
            OpenGLObjects.Add(prism);
            ShadowObjects.Add(prism);
            CreateWindows(x,z);
        }

        private void CreateWindows(float x, float z)
        {
            for (int stage = 0;stage<15;stage++)
            {
                //15 этажей
                var window = new Rectangle(x+4.6f, 0.5f + stage*2.5f, z-0.01f, 0.8f, 1, 0, Textures.WindowTexture);
                OpenGLObjects.Add(window);

                //боковые на фронт
                window = new Rectangle(x - 0.01f, 0.5f + stage * 2.5f, z+1,0, 1, 0.8f, Textures.WindowTexture);
                OpenGLObjects.Add(window);
                window = new Rectangle(x - 0.01f, 0.5f + stage * 2.5f, z+3 ,0, 1, 0.8f, Textures.WindowTexture);
                OpenGLObjects.Add(window);

                window = new Rectangle(x - 0.01f, 0.5f + stage * 2.5f, z + 5.5f, 0, 1, 0.8f, Textures.WindowTexture);
                OpenGLObjects.Add(window);
                window = new Rectangle(x - 0.01f, 0.5f + stage * 2.5f, z + 7.5f, 0, 1, 0.8f, Textures.WindowTexture);
                OpenGLObjects.Add(window);

                window = new Rectangle(x - 0.01f, 0.5f + stage * 2.5f, z + 9, 0, 1, 0.8f, Textures.WindowTexture);
                OpenGLObjects.Add(window);

                //боковые назад
                window = new Rectangle(x + 10.01f, 0.5f + stage * 2.5f, z + 1, 0, 1, 0.8f, Textures.WindowTexture);
                OpenGLObjects.Add(window);
                window = new Rectangle(x + 10.01f, 0.5f + stage * 2.5f, z + 3, 0, 1, 0.8f, Textures.WindowTexture);
                OpenGLObjects.Add(window);

                window = new Rectangle(x + 10.01f, 0.5f + stage * 2.5f, z + 5.5f, 0, 1, 0.8f, Textures.WindowTexture);
                OpenGLObjects.Add(window);
                window = new Rectangle(x + 10.01f, 0.5f + stage * 2.5f, z + 7.5f, 0, 1, 0.8f, Textures.WindowTexture);
                OpenGLObjects.Add(window);

                window = new Rectangle(x + 10.01f, 0.5f + stage * 2.5f, z + 10, 0, 1, 0.8f, Textures.WindowTexture);
                OpenGLObjects.Add(window);
                window = new Rectangle(x + 10.01f, 0.5f + stage * 2.5f, z + 12, 0, 1, 0.8f, Textures.WindowTexture);
                OpenGLObjects.Add(window);

                window = new Rectangle(x + 6f, 0.5f + stage * 2.5f, z + 20.01f, 0.8f, 1, 0, Textures.WindowTexture);
                OpenGLObjects.Add(window);

                if (stage <14){
                    //фронтальные окна
                    window = new Rectangle(x - 1f, 0.5f + stage * 2.5f, z + 9.99f, -0.8f, 1, 0, Textures.WindowTexture);
                    OpenGLObjects.Add(window);
                    window = new Rectangle(x - 3f, 0.5f + stage * 2.5f, z + 9.99f, -0.8f, 1, 0, Textures.WindowTexture);
                    OpenGLObjects.Add(window);

                    window = new Rectangle(x - 6f, 0.5f + stage * 2.5f, z + 9.99f, -0.8f, 1, 0, Textures.WindowTexture);
                    OpenGLObjects.Add(window);
                    window = new Rectangle(x - 8f, 0.5f + stage * 2.5f, z + 9.99f, -0.8f, 1, 0, Textures.WindowTexture);
                    OpenGLObjects.Add(window);

                    window = new Rectangle(x - 11f, 0.5f + stage * 2.5f, z + 9.99f, -0.8f, 1, 0, Textures.WindowTexture);
                    OpenGLObjects.Add(window);
                    window = new Rectangle(x - 13f, 0.5f + stage * 2.5f, z + 9.99f, -0.8f, 1, 0, Textures.WindowTexture);
                    OpenGLObjects.Add(window);

                

                    //Окна назад c фронта
                    window = new Rectangle(x - 11f, 0.5f + stage * 2.5f, z + 20.01f, -0.8f, 1, 0, Textures.WindowTexture);
                    OpenGLObjects.Add(window);
                    window = new Rectangle(x - 13f, 0.5f + stage * 2.5f, z + 20.01f, -0.8f, 1, 0, Textures.WindowTexture);
                    OpenGLObjects.Add(window);

                    window = new Rectangle(x - 6f, 0.5f + stage * 2.5f, z + 20.01f, -0.8f, 1, 0, Textures.WindowTexture);
                    OpenGLObjects.Add(window);
                    window = new Rectangle(x - 8f, 0.5f + stage * 2.5f, z + 20.01f, -0.8f, 1, 0, Textures.WindowTexture);
                    OpenGLObjects.Add(window);
                    //с торца
                    window = new Rectangle(x -15.01f, 0.5f + stage * 2.5f, z + 14.6f,0 , 1, 0.8f, Textures.WindowTexture);
                    OpenGLObjects.Add(window);

                    //боковые на фронт
                    window = new Rectangle(x - 5.01f, 0.5f + stage * 2.5f, z +35-1.8f, 0, 1, 0.8f, Textures.WindowTexture);
                    OpenGLObjects.Add(window);
                    window = new Rectangle(x - 5.01f, 0.5f + stage * 2.5f, z +35- 3.8f, 0, 1, 0.8f, Textures.WindowTexture);
                    OpenGLObjects.Add(window);

                    window = new Rectangle(x - 5.01f, 0.5f + stage * 2.5f, z +35- 6.3f, 0, 1, 0.8f, Textures.WindowTexture);
                    OpenGLObjects.Add(window);
                    window = new Rectangle(x - 5.01f, 0.5f + stage * 2.5f, z +35- 8.3f, 0, 1, 0.8f, Textures.WindowTexture);
                    OpenGLObjects.Add(window);

                    window = new Rectangle(x - 5.01f, 0.5f + stage * 2.5f, z +35- 10.8f, 0, 1, 0.8f, Textures.WindowTexture);
                    OpenGLObjects.Add(window);
                    window = new Rectangle(x - 5.01f, 0.5f + stage * 2.5f, z + 35 - 12.8f, 0, 1, 0.8f, Textures.WindowTexture);
                    OpenGLObjects.Add(window);

                    //боковые назад
                    window = new Rectangle(x + 5.01f, 0.5f + stage * 2.5f, z+35 - 1.8f, 0, 1, 0.8f, Textures.WindowTexture);
                    OpenGLObjects.Add(window);
                    window = new Rectangle(x + 5.01f, 0.5f + stage * 2.5f,z+35 - 3.8f, 0, 1, 0.8f, Textures.WindowTexture);
                    OpenGLObjects.Add(window);

                    window = new Rectangle(x + 5.01f, 0.5f + stage * 2.5f, z+35 - 6.3f, 0, 1, 0.8f, Textures.WindowTexture);
                    OpenGLObjects.Add(window);
                    window = new Rectangle(x + 5.01f, 0.5f + stage * 2.5f, z + 35 - 8.3f, 0, 1, 0.8f, Textures.WindowTexture);
                    OpenGLObjects.Add(window);

                    window = new Rectangle(x + 5.01f, 0.5f + stage * 2.5f, z + 35 - 10.8f, 0, 1, 0.8f, Textures.WindowTexture);
                    OpenGLObjects.Add(window);
                    window = new Rectangle(x + 5.01f, 0.5f + stage * 2.5f, z + 35 - 12.8f, 0, 1, 0.8f, Textures.WindowTexture);
                    OpenGLObjects.Add(window);

                    window = new Rectangle(x +.6f, 0.5f + stage * 2.5f, z + 35.01f, -0.8f, 1, 0, Textures.WindowTexture);
                    OpenGLObjects.Add(window);

                   


                }

                if (stage < 13)
                {
                    //окна на фронт сбоку
                    window = new Rectangle(x + 11f, 0.5f + stage*2.5f, z + 14.99f, 0.8f, 1, 0, Textures.WindowTexture);
                    OpenGLObjects.Add(window);
                    window = new Rectangle(x + 13f, 0.5f + stage*2.5f, z + 14.99f, 0.8f, 1, 0, Textures.WindowTexture);
                    OpenGLObjects.Add(window);

                    window = new Rectangle(x + 16f, 0.5f + stage*2.5f, z + 14.99f, 0.8f, 1, 0, Textures.WindowTexture);
                    OpenGLObjects.Add(window);
                    window = new Rectangle(x + 18f, 0.5f + stage*2.5f, z + 14.99f, 0.8f, 1, 0, Textures.WindowTexture);
                    OpenGLObjects.Add(window);

                    //окна назад сбоку
                    window = new Rectangle(x + 11f, 0.5f + stage*2.5f, z + 25.01f, 0.8f, 1, 0, Textures.WindowTexture);
                    OpenGLObjects.Add(window);
                    window = new Rectangle(x + 13f, 0.5f + stage*2.5f, z + 25.01f, 0.8f, 1, 0, Textures.WindowTexture);
                    OpenGLObjects.Add(window);

                    window = new Rectangle(x + 16f, 0.5f + stage*2.5f, z + 25.01f, 0.8f, 1, 0, Textures.WindowTexture);
                    OpenGLObjects.Add(window);
                    window = new Rectangle(x + 18f, 0.5f + stage*2.5f, z + 25.01f, 0.8f, 1, 0, Textures.WindowTexture);
                    OpenGLObjects.Add(window);

                    window = new Rectangle(x + 9f, 0.5f + stage*2.5f, z + 25.01f, 0.8f, 1, 0, Textures.WindowTexture);
                    OpenGLObjects.Add(window);
                }
            }
        }
    }
}
