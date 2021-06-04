using Gdk;
using Gtk;
using Key = Gdk.Key;

namespace DiggerClassic
{
    public abstract class AppletCompat : DrawingArea
    {
        public void SetFocusable(bool value) => CanFocus = value;

        protected static string GetParameter(string key) => null;

        protected void RequestFocus() => GrabFocus();

        protected override bool OnKeyPressEvent(EventKey e)
        {
            var num = ConvertToLegacy(e.Key);
            if (num >= 0)
                return KeyDown(num);
            return base.OnKeyPressEvent(e);
        }

        protected override bool OnKeyReleaseEvent(EventKey e)
        {
            var num = ConvertToLegacy(e.Key);
            if (num >= 0)
                return KeyUp(num);
            return base.OnKeyReleaseEvent(e);
        }

        protected abstract bool KeyUp(int key);

        protected abstract bool KeyDown(int key);

        private static int ConvertToLegacy(Key netCode)
        {
            switch (netCode)
            {
                case Key.Left:
                case Key.leftarrow:
                    return 1006;
                case Key.Right:
                case Key.rightarrow:
                    return 1007;
                case Key.Up:
                case Key.uparrow:
                    return 1004;
                case Key.Down:
                case Key.downarrow:
                    return 1005;
                case Key.F1:
                    return 1008;
                default:
                    var ascii = (int) netCode;
                    return ascii;
            }
        }
    }
}