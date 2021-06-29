using Digger.API;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace Digger.UWP
{
	internal class UwpDigger : AppletCompat, IFactory
	{
		public IDigger _digger;
		private WriteableBitmap _buffer;
		private bool _setup;

		public UwpDigger(IDigger digger)
		{
			_digger = digger;
			_setup = false;
		}

		internal void Initialize(Frame w)
		{
			if (_setup)
				return;
			_setup = true;
			var ctrl = this;
			var img = ctrl.Image;

			w.KeyDown += HandleKeyDown;
			w.KeyUp += HandleKeyUp;

			var pc = _digger.GetPc();
			var width = pc.GetWidth();
			var height = pc.GetHeight();
			_buffer = BitmapFactory.New(width, height);
			img.Source = _buffer;
		}

		internal void DoRender(int x, int y, int width, int height) => DoRender();

		internal void DoRender()
		{
			if (_buffer == null)
				return;
			using (var g = _buffer.GetBitmapContext())
				DoRender(g);
		}

		protected void DoRender(BitmapContext g)
		{
			var pc = _digger.GetPc();

			var w = pc.GetWidth();
			var h = pc.GetHeight();
			var data = pc.GetPixels();
			var source = pc.GetCurrentSource();
			var model = source.Model;

			for (var x = 0; x < w; x++)
			{
				for (var y = 0; y < h; y++)
				{
					var arrayIndex = y * w + x;
					var color = model.GetColor(data[arrayIndex]);
					g.Pixels[y * g.Width + x] = (255 << 24) | (color.r << 16) | (color.g << 8) | color.b;
				}
			}
		}

		protected override bool DoKeyUp(int key) => _digger.KeyUp(key);
		protected override bool DoKeyDown(int key) => _digger.KeyDown(key);

		public IRefresher CreateRefresher(IDigger digger, IColorModel model)
		   => new UwpRefresher(this, model);
	}
}