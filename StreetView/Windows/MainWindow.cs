using System.Windows.Forms;
using StreetView.OpenGL.Controls;

namespace StreetView.Windows
{
    public class MainWindow : Form
    {
        public MainWindow()
        {
            MinimumSize = new System.Drawing.Size(600, 600);
            ClientSize = new System.Drawing.Size(800, 600);
            Name = "Street View";
            Text = "Street View";
            var streetView = new StreetViewControl {Parent = this};
            streetView.Focus();
            streetView.Dock = DockStyle.Fill;
            Show();
        }
    }
}
