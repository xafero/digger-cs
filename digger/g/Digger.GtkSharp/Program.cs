using System;
using DiggerClassic;
using Gtk;

namespace Digger.GtkSharp
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Application.Init();

            var gtk = new GtkDigger(null);
            var game = new DiggerClassic.Digger(gtk);
            gtk.SetFocusable(true);
            game.Init();
            game.Start();

            var frame = new Window("Digger Remastered");
            frame.DeleteEvent += delegate
            {
                Application.Quit();
                Environment.Exit(0);
            };
            frame.SetDefaultSize((int) (game.width * 4.03), (int) (game.height * 4.15));
            frame.SetPosition(WindowPosition.Center);

            var icon = Resources.FindResource("/icons/digger.png");
            frame.Icon = GtkResources.LoadImage(icon);

            gtk._digger = game;
            frame.Add(gtk);
            frame.ShowAll();

            Application.Run();
        }
    }
}