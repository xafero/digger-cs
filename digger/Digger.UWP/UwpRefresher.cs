using Digger.API;
using Windows.UI.Core;

namespace Digger.UWP
{
	internal class UwpRefresher : IRefresher
	{
		private readonly UwpDigger _area;

		public UwpRefresher(UwpDigger area, IColorModel model)
		{
			_area = area;
			Model = model;
		}

		public IColorModel Model { get; }

		public void NewPixels(int x, int y, int width, int height)
		{
			void a() => _area.DoRender(x, y, width, height);
			if (!_area.Image.Dispatcher.HasThreadAccess)
			{
				_ = _area.Image.Dispatcher.RunAsync(CoreDispatcherPriority.High, a);
				return;
			}
			a();
		}

		public void NewPixels()
		{
			void a() => _area.DoRender();
			if (!_area.Image.Dispatcher.HasThreadAccess)
			{
				_ = _area.Image.Dispatcher.RunAsync(CoreDispatcherPriority.High, a);
				return;
			}
			a();
		}
	}
}