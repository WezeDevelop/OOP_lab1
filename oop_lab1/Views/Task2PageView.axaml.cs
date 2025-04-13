using Avalonia;
using Avalonia.Controls;
using System;

namespace avalonia_demo8.Views;

public partial class Task2PageView : UserControl
{
    public Task2PageView()
    {
        InitializeComponent();
    }
    private void OnCalculate(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (double.TryParse(InputR.Text, out double R) &&
            double.TryParse(Inputr.Text, out double r) && R > r)
        {
            double area = Math.PI * (R * R - r * r);
            ResultText.Text = $"Площа кільця: {area}";
        }
        else
        {
            ResultText.Text = "Некоректні дані!";
        }
    }

}