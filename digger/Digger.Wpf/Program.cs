using System;
using System.Windows;
using System.Windows.Media;
using DiggerClassic;

[assembly: ThemeInfo(ResourceDictionaryLocation.None, ResourceDictionaryLocation.SourceAssembly)]

namespace Digger.Wpf
{
	internal static class Program
	{
		[STAThread]
		private static void Main()
		{
			var frm = new WpfDigger(null);
			var game = new DiggerClassic.Digger(frm);
			frm.SetFocusable(true);
			game.Init();
			game.Start();

			var frame = new Window { Title = "Digger Remastered" };
			frame.Closed += delegate
			{
				var app = Application.Current;
				app.Shutdown();
				Environment.Exit(0);
			};
			var size = new Size((int)(game.width * 4.03), (int)(game.height * 4.15));
			frame.Width = size.Width;
			frame.Height = size.Height;
			frame.WindowStartupLocation = WindowStartupLocation.CenterScreen;
			frame.Background = Brushes.Black;

			var icon = Resources.FindResource("/icons/digger.png");
			frame.Icon = WpfResources.LoadImage(icon);

			frm._digger = game;
			frame.Content = frm;
			frame.Visibility = Visibility.Visible;

			Application app = new Application();
			app.Run(frame);
		}
	}
}