using Digger.API;

namespace Digger.Xamarin
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
				_area.InvalidateSurface();
			}

			if (_area.Dispatcher.IsDispatchRequired)
			{
				_area.Dispatcher.Dispatch(Refresh);
				return;
			}

			Refresh();
		}
	}
}
