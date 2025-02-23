﻿using Digger.API;
using SkiaSharp;
using SkiaSharp.Views.Maui;

namespace Digger.Maui
{
	internal class MobileDigger : AppletCompat, IFactory
	{
		public IDigger _digger;

		public MobileDigger() : this(null)
        {
        }

		public MobileDigger(IDigger digger)
		{
			_digger = digger;
		}

		protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
		{
			base.OnPaintSurface(e);

			if (_digger == null)
				return;

			var g = e.Surface.Canvas;
			var pc = _digger.GetPc();

			var w = pc.GetWidth();
			var h = pc.GetHeight();

			var rw = e.Info.Width * 1d;
			var rh = e.Info.Height * 1d;

			var fw = rw / w;
			var fh = rh / h;
			var minF = (float)Math.Min(fw, fh);

			var data = pc.GetPixels();
			var model = pc.GetCurrentSource().Model;

			var shiftX = (float)(rw - (w * minF)) / 2;
			var shiftY = (float)(rh - (h * minF)) / 2;
			var paint = new SKPaint { Style = SKPaintStyle.Fill };

			for (var x = 0; x < w; x++)
			{
				for (var y = 0; y < h; y++)
				{
					var arrayIndex = y * w + x;
					var (sr, sg, sb) = model.GetColor(data[arrayIndex]);
					paint.Color = new SKColor((byte)sr, (byte)sg, (byte)sb);
					g.DrawRect(shiftX + (x * minF), shiftY + (y * minF), minF, minF, paint);
				}
			}
		}

		public override bool KeyUp(int key) => _digger.KeyUp(key);
		public override bool KeyDown(int key) => _digger.KeyDown(key);

		public IRefresher CreateRefresher(IDigger digger, IColorModel model)
			=> new MobileRefresher(this, model);
	}
}
