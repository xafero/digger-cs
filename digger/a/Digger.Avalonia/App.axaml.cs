using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Digger.Avalonia.ViewModels;
using Digger.Avalonia.Views;

namespace Digger.Avalonia
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainViewModel()
                };
            }
            else if (ApplicationLifetime is IActivityApplicationLifetime mobile)
            {
                mobile.MainViewFactory = () => new MainView
                {
                    DataContext = new MainViewModel()
                };
            }
            else if (ApplicationLifetime is ISingleViewApplicationLifetime single)
            {
                single.MainView = new MainView
                {
                    DataContext = new MainViewModel()
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}