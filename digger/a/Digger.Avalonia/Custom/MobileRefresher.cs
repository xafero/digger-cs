using Digger.API;
using Digger.API;
using Digger.Xamarin;

namespace Digger.Maui
{
	internal class MobileRefresher : IRefresher
	{
		private readonly MobileDigger _area;

		public MobileRefresher(MobileDigger area, IColorModel model)
		{
			_area = area;
			Model = model;
		}

		public IColorModel Model { get; }

		public void NewPixels(int x, int y, int w, int h) => NewPixels();

		public void NewPixels()
		{
			void Refresh()
			{
				_area?.InvalidateSurface();
			}

			if (!_area.Dispatcher.CheckAccess())
			{
				_area.Dispatcher.Invoke(Refresh);
				return;
			}

			Refresh();
		}
	}
}