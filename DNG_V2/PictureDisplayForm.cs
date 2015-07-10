using System.Drawing;
using System.Windows.Forms;

namespace DNG_V2
{
    public partial class PictureDisplayForm : Form
    {
        public PictureDisplayForm()
        {
            InitializeComponent();
            var b = new Bitmap(500, 500);
            var DM = new DungeonMaster(500, 500);
            DM.Build();
            var e = DM.Export();

            for (int y = 0; y < DM.Height; y++)
            {
                for (int x = 0; x < DM.Width; x++)
                {
                    var c = e[x, y] == TileType.Floor ? Color.White : Color.Black;
                    b.SetPixel(x, y, c);
                }
            }

            Canvas.Image = Image.FromHbitmap(b.GetHbitmap());
        }
    }
}