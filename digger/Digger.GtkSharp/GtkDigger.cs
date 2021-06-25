using Cairo;
using Digger.API;

namespace Digger.GtkSharp
{
    internal class GtkDigger : AppletCompat, IFactory
    {
        public IDigger _digger;

        public GtkDigger(IDigger digger)
        {
            _digger = digger;
        }

        protected override bool OnDrawn(Context g)
        {
            g.Scale(4, 4);

            var pc = _digger.GetPc();

            var w = pc.GetWidth();
            var h = pc.GetHeight();
            var data = pc.GetPixels();

            const int shift = 1;

            for (var x = 0; x < w; x++)
            {
                for (var y = 0; y < h; y++)
                {
                    var arrayIndex = y * w + x;
                    var (sr, sg, sb) = pc.GetCurrentSource().Model.GetColor(data[arrayIndex]);
                    g.SetSourceRGB(sr, sg, sb);
                    g.Rectangle(x + shift, y + shift, 1, 1);
                    g.Fill();
                }
            }
            
            return false;
        }

        protected override bool KeyUp(int key) => _digger.KeyUp(key);
        protected override bool KeyDown(int key) => _digger.KeyDown(key);

        public IRefresher CreateRefresher(IDigger digger, IColorModel model)
            => new GtkRefresher(this, model);
    }
}