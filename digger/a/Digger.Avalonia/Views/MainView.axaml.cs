using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using System.Collections.Generic;
using Avalonia;
using Digger.Xamarin;
using Avalonia.Controls;

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
    }
}