using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using System.Collections.Generic;
using Avalonia;
using Digger.Xamarin;
using Avalonia.Controls;
using Avalonia.Layout;

// ReSharper disable InconsistentNaming

namespace Digger.Views
{
    public partial class MainView : UserControl
    {
        private readonly Stack<int> _keys = new();

        public MainView()
        {
            InitializeComponent();
        }

        protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
        {
            base.OnAttachedToVisualTree(e);
            OnAppearing();
        }

        private void OnAppearing()
        {
            var moby = GetHandle();
            if (moby._digger != null)
                return;
            var game = new DiggerClassic.Digger(moby);
            moby._digger = game;
            moby.SetFocusable();
            game.Init();
            game.Start();
        }

        private MobileDigger GetHandle() => myCanvas;

        private void DownButton_Clicked(object? sender, RoutedEventArgs e) => SendKey(AppletCompat.Key_Down);
        private void UpButton_Clicked(object? sender, RoutedEventArgs e) => SendKey(AppletCompat.Key_Up);
        private void RightButton_Clicked(object? sender, RoutedEventArgs e) => SendKey(AppletCompat.Key_Right);
        private void LeftButton_Clicked(object? sender, RoutedEventArgs e) => SendKey(AppletCompat.Key_Left);
        private void FireButton_Clicked(object? sender, RoutedEventArgs e) => SendKey(AppletCompat.Key_F1);
        private void StopButton_Clicked(object? sender, RoutedEventArgs e) => SendKey(AppletCompat.Key_F10);
        private void InputButton_Clicked(object? sender, RoutedEventArgs e) => SendKey('a');

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

        private Orientation _myOrientation;

        public Orientation MyOrientation
        {
            get => _myOrientation;
            set { _myOrientation = value; UpdateOrientation(_myOrientation); }
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            var size = base.ArrangeOverride(finalSize);
            OnSizeAllocated(size.Width, size.Height);
            return size;
        }

        protected void OnSizeAllocated(double width, double height)
        {
            if ((int)width == (int)lastWidth && (int)height == (int)lastHeight)
                return;
            lastWidth = width;
            lastHeight = height;
            Orientation orientation;
            if (width > height)
                orientation = Orientation.Horizontal;
            else
                orientation = Orientation.Vertical;
            MyOrientation = orientation;
        }

        private void UpdateOrientation(Orientation orientation)
        {
            switch (orientation)
            {
                case Orientation.Horizontal:
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
                case Orientation.Vertical:
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