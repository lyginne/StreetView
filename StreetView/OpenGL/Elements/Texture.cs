namespace StreetView.OpenGL.Elements
{
    public class Texture
    {
        public readonly uint[] TextureBytes;
        public readonly string TextureName;

        public Texture(string textureName){
            TextureBytes = new uint[1];
            TextureName = textureName;
        }

        public static string ParseTextureName(string line) 
        {
            string[] coords = line.Split(' ');
            return coords[5];
        }
    }
}
