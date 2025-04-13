using Avalonia;
using Avalonia.Controls;
using System;

namespace avalonia_demo8.Views;

public partial class Task1PageView : UserControl
{
    public Task1PageView()
    {
        InitializeComponent();
    }
    private void OnCalculate(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (double.TryParse(InputX.Text, out double x))
        {
            double result = 2 * (1 / Math.Tan(3 * x)) - 1 / (12 * x * x + 7 * x - 5);
            ResultText.Text = $"Результат: {result}";
        }
        else
        {
            ResultText.Text = "Некоректне значення x!";
        }
    }
}