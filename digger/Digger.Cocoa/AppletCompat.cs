using AppKit;
using CoreGraphics;

namespace Digger.Cocoa
{
    internal abstract class AppletCompat : NSView
    {
        protected AppletCompat(CGRect frame) : base(frame)
        {
            NSEvent.AddLocalMonitorForEventsMatchingMask(NSEventMask.KeyDown, (o) =>
            {
                KeyDown(o);
                return o;
            });
            NSEvent.AddLocalMonitorForEventsMatchingMask(NSEventMask.KeyUp, (o) =>
            {
                KeyUp(o);
                return o;
            });
        }

        public void SetFocusable(bool _) => RequestFocus();

        public string GetSubmitParameter() => null;

        public int GetSpeedParameter() => 66;

        public void RequestFocus() { }

        public override void KeyDown(NSEvent e)
        {
            var num = ConvertToLegacy(e.KeyCode, e.Characters);
            if (num >= 0)
            {
                KeyDown(num);
                return;
            }
            base.KeyDown(e);
        }

        public override void KeyUp(NSEvent e)
        {
            var num = ConvertToLegacy(e.KeyCode, e.Characters);
            if (num >= 0)
            {
                KeyUp(num);
                return;
            }
            base.KeyUp(e);
        }

        protected abstract bool KeyUp(int key);

        protected abstract bool KeyDown(int key);

        private static int ConvertToLegacy(ushort macCode, string chars)
        {
            switch ((NSKey)macCode)
            {
                case NSKey.LeftArrow:
                    return 1006;
                case NSKey.RightArrow:
                    return 1007;
                case NSKey.UpArrow:
                    return 1004;
                case NSKey.DownArrow:
                    return 1005;
                case NSKey.F1:
                    return 1008;
                case NSKey.F10:
                    return 1021;
                case NSKey.KeypadPlus:
                    return 1031;
                case NSKey.KeypadMinus:
                    return 1032;
                default:
                    var ascii = chars.Length == 1 ? chars[0] : -1;
                    return ascii;
            }
        }
    }
}
