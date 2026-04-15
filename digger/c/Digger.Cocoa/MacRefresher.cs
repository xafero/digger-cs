using System;
using Digger.API;
using AppKit;

namespace Digger.Cocoa
{
    public class MacRefresher : IRefresher
    {
        private readonly NSView _area;

        public MacRefresher(NSView area, IColorModel model)
        {
            _area = area;
            Model = model;
        }

        public IColorModel Model { get; }

        public void NewPixels(int x, int y, int w, int h)
            => NewPixels();

        public void NewPixels()
        {
            _area.InvokeOnMainThread(() =>
            {
                _area.NeedsDisplay = true;
            });
        }
    }
}
