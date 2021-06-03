using System;
using Gtk;

namespace DiggerClassic
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Application.Init();

            Digger game = new Digger();
            game.SetFocusable(true);
            game.init();
            game.start();

            JFrame frame = new JFrame("Digger Remastered");
            frame.SetDefaultCloseOperation();
            frame.SetSize((int) (game.width * 4.03), (int) (game.height * 4.15));
            frame.SetLocationRelativeTo();

            frame.Add(game);
            frame.SetVisible(true);

            Application.Run();
        }

        #region Helper
        private class JFrame : Window
        {
            public JFrame(string title) : base(title)
            {
            }

            public void SetSize(int width, int height) => SetDefaultSize(width, height);

            public void SetLocationRelativeTo(WindowPosition pos = WindowPosition.Center) => SetPosition(pos);

            public void SetVisible(bool b) => ShowAll();

            public void SetDefaultCloseOperation()
            {
                DeleteEvent += delegate
                {
                    Application.Quit();
                    Environment.Exit(0);
                };
            }
        }
        #endregion
    }
}