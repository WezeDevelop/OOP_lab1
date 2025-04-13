using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using System;
using System.Linq;

namespace avalonia_demo8.Views;

public partial class Task7PageView : UserControl
{
    public Task7PageView()
    {
        InitializeComponent();
    }

    private void OnCheck(object sender, RoutedEventArgs e)
    {
        string input = InputText.Text?.Trim();

        if (string.IsNullOrWhiteSpace(input))
        {
            ResultText.Text = "Введіть текст для аналізу";
            ResultText.Foreground = Brushes.Red;
            return;
        }

        // Видаляємо двокрапку в кінці, якщо вона є
        if (input.EndsWith(":"))
        {
            input = input[..^1];
        }

        var words = input.Split(';')
                       .Select(w => w.Trim())
                       .Where(w => !string.IsNullOrWhiteSpace(w));

        int count = words.Count(w => w.EndsWith("а", StringComparison.OrdinalIgnoreCase));

        ResultText.Text = $"Знайдено {count} слів, що закінчуються на 'a'";
        ResultText.Foreground = Brushes.Green;
    }
}