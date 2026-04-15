using Windows.System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace Digger.UWP
{
	internal abstract class AppletCompat
	{
		public Image Image { get; } = new Image();

		public void SetFocusable(bool value) => Image.AllowFocusOnInteraction = value;

		public string GetSubmitParameter() => null;

		public int GetSpeedParameter() => 66;

		public void RequestFocus() { }

		protected void HandleKeyDown(object _, KeyRoutedEventArgs e)
		{
			var num = ConvertToLegacy(e.Key);
			if (num >= 0)
			{
				DoKeyDown(num);
				return;
			}
		}

		protected void HandleKeyUp(object _, KeyRoutedEventArgs e)
		{
			var num = ConvertToLegacy(e.Key);
			if (num >= 0)
			{
				DoKeyUp(num);
				return;
			}
		}

		protected abstract bool DoKeyUp(int key);

		protected abstract bool DoKeyDown(int key);

		private static int ConvertToLegacy(VirtualKey netCode)
		{
			switch (netCode)
			{
				case VirtualKey.Left:
					return 1006;
				case VirtualKey.Right:
					return 1007;
				case VirtualKey.Up:
					return 1004;
				case VirtualKey.Down:
					return 1005;
				case VirtualKey.F1:
					return 1008;
				case VirtualKey.F10:
					return 1021;
				case VirtualKey.PageUp:
				case VirtualKey.Add:
					return 1031;
				case VirtualKey.PageDown:
				case VirtualKey.Subtract:
					return 1032;
				default:
					var ascii = (int)netCode;
					return ascii;
			}
		}
	}
}