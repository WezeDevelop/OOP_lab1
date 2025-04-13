using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using System;

namespace avalonia_demo8.Views;

public partial class Task4PageView : UserControl
{
    public Task4PageView()
    {
        InitializeComponent();
    }

    private void OnCheck(object sender, RoutedEventArgs e)
    {
        if (double.TryParse(InputR.Text, out double R) &&
            double.TryParse(InputA.Text, out double a))
        {
            if (R <= 0 || a <= 0)
            {
                ResultText.Text = "Значення повинні бути додатніми";
                ResultText.Foreground = Brushes.Red;
                return;
            }

            double minRadius = a / Math.Sqrt(3);
            bool fits = R >= minRadius;

            ResultText.Text = fits ? "Трикутник поміститься в колі" : "Трикутник не поміститься в колі";
            ResultText.Foreground = fits ? Brushes.Green : Brushes.Red;
        }
        else
        {
            ResultText.Text = "Некоректні вхідні дані";
            ResultText.Foreground = Brushes.Red;
        }
    }
}