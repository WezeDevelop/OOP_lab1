using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using System;

namespace avalonia_demo8.Views;

public partial class Task3PageView : UserControl
{
    public Task3PageView()
    {
        InitializeComponent();
    }

    private void OnCheck(object sender, RoutedEventArgs e)
    {
        if (double.TryParse(InputA.Text, out double a) &&
            double.TryParse(InputB.Text, out double b) &&
            double.TryParse(InputC.Text, out double c))
        {
            bool result = Math.Abs((a + b) / 2 - c) < 0.0001;
            ResultText.Text = $"Результат: {result}";
            ResultText.Foreground = result ? Brushes.Green : Brushes.Red;
        }
        else
        {
            ResultText.Text = "Некоректні вхідні дані";
            ResultText.Foreground = Brushes.Red;
        }
    }
}