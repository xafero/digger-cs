using Gtk;

namespace DiggerClassic
{
    public class Refresher
    {
        private readonly DrawingArea _area;

        public Refresher(DrawingArea area, ColorModel model)
        {
            _area = area;
            Model = model;
        }

        public ColorModel Model { get; }

        public void NewPixels(int x, int y, int w, int h)
            => _area.QueueDrawArea(x, y, w, h);

        public void NewPixels()
            => _area.QueueDraw();
    }
}