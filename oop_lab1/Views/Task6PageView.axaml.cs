using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace avalonia_demo8.Views;

public partial class Task6PageView : UserControl
{
    public Task6PageView()
    {
        InitializeComponent();
    }
    private void OnCheck(object sender, RoutedEventArgs e)
    {
        try
        {
            // Тут буде логіка перевірки
            var result = SolveLockPuzzle(new Dictionary<int, int>());
            ResultText.Text = $"Знайдено {result.Count} варіантів:\n" +
                            string.Join("\n", result.Take(5).Select(s => string.Join("-", s))) +
                            (result.Count > 5 ? "\n..." : "");
        }
        catch (Exception ex)
        {
            ResultText.Text = $"Помилка: {ex.Message}";
        }
    }

    public List<int[]> SolveLockPuzzle(Dictionary<int, int> fixedCubes)
    {
        List<int[]> solutions = new List<int[]>();
        int[] current = new int[10];

        // Ініціалізуємо фіксовані значення
        foreach (var kvp in fixedCubes)
        {
            if (kvp.Key < 0 || kvp.Key >= 10)
                throw new ArgumentException("Позиція повинна бути від 0 до 9");
            if (kvp.Value < 1 || kvp.Value > 6)
                throw new ArgumentException("Значення кубика повинно бути від 1 до 6");

            current[kvp.Key] = kvp.Value;
        }

        SolveRecursive(0, current, fixedCubes, solutions);
        return solutions;
    }

    private void SolveRecursive(int position, int[] current, Dictionary<int, int> fixedCubes, List<int[]> solutions)
    {
        if (position == 10)
        {
            if (IsValidSolution(current))
            {
                solutions.Add((int[])current.Clone());
            }
            return;
        }

        if (fixedCubes.ContainsKey(position))
        {
            SolveRecursive(position + 1, current, fixedCubes, solutions);
        }
        else
        {
            for (int value = 1; value <= 6; value++)
            {
                current[position] = value;

                // Перевірка на сумісність з попередніми значеннями
                bool valid = true;
                if (position >= 2)
                {
                    int sum = current[position - 2] + current[position - 1] + current[position];
                    if (sum != 10) valid = false;
                }

                if (valid)
                {
                    SolveRecursive(position + 1, current, fixedCubes, solutions);
                }
            }
        }
    }

    private bool IsValidSolution(int[] solution)
    {
        for (int i = 0; i <= 7; i++)
        {
            int sum = solution[i] + solution[i + 1] + solution[i + 2];
            if (sum != 10) return false;
        }
        return true;
    }

}