using Avalonia;
using Avalonia.Controls;
using System;

namespace avalonia_demo8.Views;

public partial class Task5PageView : UserControl
{
    public Task5PageView()
    {
        InitializeComponent();
    }

    private void OnCheck(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (double.TryParse(InputA.Text, out var a) &&
            double.TryParse(InputB.Text, out var b) &&
            double.TryParse(InputX.Text, out var x))
        {
            var min = Math.Min(a, b);
            var max = Math.Max(a, b);
            ResultText.Text = (x >= min && x <= max) ? "Належить" : "Не належить";
        }
        else
        {
            ResultText.Text = "Некоректні числа.";
        }
    }
}