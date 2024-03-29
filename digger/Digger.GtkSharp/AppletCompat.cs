using Gdk;
using Gtk;
using Key = Gdk.Key;

namespace Digger.GtkSharp
{
    internal abstract class AppletCompat : DrawingArea
    {
        public void SetFocusable(bool value) => CanFocus = value;

        public string GetSubmitParameter() => null;

        public int GetSpeedParameter() => 66;

        public void RequestFocus() => GrabFocus();

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
                case Key.F10:
                    return 1021;
                case Key.plus:
                    return 1031;
                case Key.minus:
                    return 1032;
                default:
                    var ascii = (int) netCode;
                    return ascii;
            }
        }
    }
}