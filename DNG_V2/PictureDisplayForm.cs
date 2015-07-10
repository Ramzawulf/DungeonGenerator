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

            foreach (var kv in DM.UsedPoints)
            {
                var c = kv.Value == TileType.Floor ? Color.Beige : kv.Value == TileType.Wall ? Color.Black : Color.White;
                b.SetPixel(kv.Key.X, kv.Key.Y, c);
            }

            Canvas.Image = Image.FromHbitmap(b.GetHbitmap());


        }
    }
}
