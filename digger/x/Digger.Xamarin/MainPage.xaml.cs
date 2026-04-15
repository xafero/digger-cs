using System;
using System.Collections.Generic;
using Digger.Xamarin;
using Xamarin.Forms;

namespace Digger
{
	public partial class MainPage : ContentPage
	{
		private readonly Stack<int> _keys = new Stack<int>();

		public MainPage()
		{
			InitializeComponent();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			var moby = GetHandle();
			if (moby._digger != null)
				return;
			var game = new DiggerClassic.Digger(moby);
			moby._digger = game;
			moby.SetFocusable();
			game.Init();
			game.Start();
		}

		private MobileDigger GetHandle() => (MobileDigger)FindByName("myCanvas");

		private void DownButton_Clicked(object sender, EventArgs e) => SendKey(AppletCompat.Key_Down);
		private void UpButton_Clicked(object sender, EventArgs e) => SendKey(AppletCompat.Key_Up);
		private void RightButton_Clicked(object sender, EventArgs e) => SendKey(AppletCompat.Key_Right);
		private void LeftButton_Clicked(object sender, EventArgs e) => SendKey(AppletCompat.Key_Left);
		private void FireButton_Clicked(object sender, EventArgs e) => SendKey(AppletCompat.Key_F1);
		private void StopButton_Clicked(object sender, EventArgs e) => SendKey(AppletCompat.Key_F10);
		private void InputButton_Clicked(object sender, EventArgs e) => SendKey('a');

		private void SendKey(int key)
		{
			var dig = GetHandle();
			while (_keys.Count >= 1)
				dig.KeyUp(_keys.Pop());
			dig.KeyDown(key);
			_keys.Push(key);
		}

		private double lastWidth;
		private double lastHeight;

		private StackOrientation _orientation;
		public StackOrientation Orientation
		{
			get => _orientation;
			set
			{
				_orientation = value;
				OnPropertyChanged(nameof(Orientation));
				UpdateOrientation(_orientation);
			}
		}

		protected override void OnSizeAllocated(double width, double height)
		{
			base.OnSizeAllocated(width, height);
			if (width == lastWidth && height == lastHeight)
				return;
			lastWidth = width;
			lastHeight = height;
			StackOrientation orientation;
			if (width > height)
				orientation = StackOrientation.Horizontal;
			else
				orientation = StackOrientation.Vertical;
			Orientation = orientation;
		}

		private void UpdateOrientation(StackOrientation orientation)
		{
			switch (orientation)
			{
				case StackOrientation.Horizontal:
					leftButtons.IsVisible = true;
					rightButtons.IsVisible = true;
					allButtons.IsVisible = false;
					Grid.SetRow(diggerFrame, 0);
					Grid.SetColumn(diggerFrame, 1);
					Grid.SetRowSpan(diggerFrame, 2);
					Grid.SetColumnSpan(diggerFrame, 1);
					Grid.SetRow(leftButtons, 0);
					Grid.SetColumn(leftButtons, 0);
					Grid.SetRowSpan(leftButtons, 2);
					Grid.SetColumnSpan(leftButtons, 1);
					Grid.SetRow(rightButtons, 0);
					Grid.SetColumn(rightButtons, 2);
					Grid.SetRowSpan(rightButtons, 2);
					Grid.SetColumnSpan(rightButtons, 1);
					break;
				case StackOrientation.Vertical:
					leftButtons.IsVisible = false;
					rightButtons.IsVisible = false;
					allButtons.IsVisible = true;
					Grid.SetRow(diggerFrame, 0);
					Grid.SetColumn(diggerFrame, 0);
					Grid.SetRowSpan(diggerFrame, 1);
					Grid.SetColumnSpan(diggerFrame, 3);
					Grid.SetRow(allButtons, 1);
					Grid.SetColumn(allButtons, 0);
					Grid.SetRowSpan(allButtons, 1);
					Grid.SetColumnSpan(allButtons, 3);
					break;
			}
		}
	}
}
