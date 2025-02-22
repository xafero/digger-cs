using SkiaSharp.Views.Maui.Controls.Hosting;

namespace Digger.Maui.Droid
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder
                .UseSharedMauiApp()
                .UseSkiaSharp();


            return builder.Build();
        }
    }
}
