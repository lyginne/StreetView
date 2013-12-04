namespace StreetView.OpenGL.Elements
{
    public class Triangle
    {
        public readonly Vertex[] Vertex=new Vertex[3];

        public Texture Texture;

        public Triangle()
        {            
        }
        public Triangle(Vertex firstVertex, Vertex secondVertex, Vertex thirdVertex, Texture texture)
        {
            Texture = texture;
            Vertex[0] = firstVertex;
            Vertex[1] = secondVertex;
            Vertex[2] = thirdVertex;
        }
        public Triangle(Vertex[] triangleVertexes, Texture texture)
        {
            Texture = texture;
            for (int i=0;i<3;i++){
                Vertex[i]=triangleVertexes[i];
            }
        }
    }
}
