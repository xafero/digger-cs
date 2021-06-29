using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Media;
using Windows.UI;

namespace Digger.UWP
{
	internal class App : Application
	{
		private bool _contentLoaded;

		public App()
		{
			InitializeComponent();
			Suspending += OnSuspending;
		}

		public void InitializeComponent()
		{
			if (_contentLoaded)
				return;

			_contentLoaded = true;
		}

		protected override void OnLaunched(LaunchActivatedEventArgs e)
		{
			var rootFrame = Window.Current.Content as Frame;
			if (rootFrame == null)
			{
				rootFrame = new Frame { Background = new SolidColorBrush(Colors.Black) };
				RequestedTheme = ApplicationTheme.Dark;
				rootFrame.NavigationFailed += OnNavigationFailed;

				if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
				{
				}

				Window.Current.Content = rootFrame;
			}
			if (e.PrelaunchActivated == false)
			{
				(FrameworkElement, Action<Frame>) res = default;
				if (rootFrame.Content == null)
				{
					res = Program.Create();
					rootFrame.Content = res.Item1;
				}
				Window.Current.Activate();
				res.Item2?.Invoke(rootFrame);
			}
		}

		private void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
		{
			throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
		}

		private void OnSuspending(object sender, SuspendingEventArgs e)
		{
			var deferral = e.SuspendingOperation.GetDeferral();
			deferral.Complete();
		}
	}
}