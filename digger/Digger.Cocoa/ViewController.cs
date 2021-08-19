using System;
using System.Drawing;
using AppKit;
using Foundation;

namespace Digger.Cocoa
{
    public partial class ViewController : NSViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }

        public override void ViewDidAppear()
        {
            base.ViewDidAppear();

            var window = View.Window;

            var frame = window.ContentView.Frame;
            var macView = new MacDigger(null, frame)
            {
                AutoresizingMask = NSViewResizingMask.HeightSizable | NSViewResizingMask.WidthSizable
            };
            AppDelegate.Init(macView);

            window.ContentView.AddSubview(macView);
            window.MakeKeyAndOrderFront(this);
        }

        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
            }
        }
    }
}
