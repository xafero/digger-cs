using Gtk;

namespace DiggerClassic
{
    public class Refresher
    {
        private readonly DrawingArea _area;

        public Refresher(DrawingArea area)
        {
            _area = area;
        }

        public void NewPixels(int x, int y, int w, int h)
            => _area.QueueDrawArea(x, y, w, h);

        public void NewPixels()
            => _area.QueueDraw();
    }
}