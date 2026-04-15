using AppKit;
using CoreGraphics;
using Digger.API;

namespace Digger.Cocoa
{
    internal class MacDigger : AppletCompat, IFactory
    {
        internal IDigger _digger;

        public MacDigger(IDigger game, CGRect frame) : base(frame)
        {
            _digger = game;
        }

        public override bool IsFlipped => true;

        public override void DrawRect(CGRect dirtyRect)
        {
            base.DrawRect(dirtyRect);

            var g = NSGraphicsContext.CurrentContext.CGContext;
            var factor = 3f;

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
                    g.SetFillColor(sr, sg, sb, 1);
                    g.FillRect(new CGRect((x * factor) + shift, (y * factor) + shift, factor, factor));
                }
            }

            g.Flush();                
        }

        protected override bool KeyUp(int key) => _digger.KeyUp(key);
        protected override bool KeyDown(int key) => _digger.KeyDown(key);

        public IRefresher CreateRefresher(IDigger digger, IColorModel model)
            => new MacRefresher(this, model);
    }
}
