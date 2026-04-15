using Digger.API;
using Gtk;

namespace Digger.GtkSharp
{
    public class GtkRefresher : IRefresher
    {
        private readonly DrawingArea _area;

        public GtkRefresher(DrawingArea area, IColorModel model)
        {
            _area = area;
            Model = model;
        }

        public IColorModel Model { get; }

        public void NewPixels(int x, int y, int w, int h)
            => Application.Invoke((o, e) => _area.QueueDrawArea(x, y, w, h));

        public void NewPixels()
            => Application.Invoke((o, e) => _area.QueueDraw());
    }
}