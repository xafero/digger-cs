using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Digger.UWP
{
	internal static class Program
	{
		[MTAThread]
		private static void Main()
		{
			Application.Start(_ => new App());
		}

		internal static (FrameworkElement, Action<Frame>) Create()
		{
			var frm = new UwpDigger(null);
			var game = new DiggerClassic.Digger(frm);
			frm.SetFocusable(true);
			game.Init();
			game.Start();

			frm._digger = game;
			Action<Frame> callback = frame =>
			{
				frame.Unloaded += (o, e) =>
				{
					var app = Application.Current;
					app.Exit();
					Environment.Exit(0);
				};

				frm.Initialize(frame);
			};

			var border = new Border { BorderThickness = new Thickness(10) };
			border.Child = frm.Image;
			return (border, callback);
		}
	}
}