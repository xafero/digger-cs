using AppKit;
using Foundation;

namespace Digger.Cocoa
{
    [Register("AppDelegate")]
    public class AppDelegate : NSApplicationDelegate
    {
        internal static MacDigger _view;

        public AppDelegate()
        {
        }

        internal static void Init(MacDigger mac)
        {
            var game = new DiggerClassic.Digger(mac);
            mac._digger = game;
            mac.SetFocusable(true);
            game.Init();
            game.Start();
            _view = mac;
        }

        public override void DidFinishLaunching(NSNotification notification)
        {
        }

        public override void WillTerminate(NSNotification notification)
        {
        }
    }
}
