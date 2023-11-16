using System;

class Program
{
    static void Main()
    {
        // Створення масиву чисел
        double[] arr = { 4, 6, 1, 2, 7, 8, 2 };

        // Знаходження максимального за модулем значення в масиві
        double maxAbsValue = FindMaxAbsoluteValue(arr);
        Console.WriteLine($"Максимальний за модулем елемент: {maxAbsValue}");

        // Перетворення масиву, переставляючи всі 0 та 1 на початок
        RearrangeArray(arr);
        Console.WriteLine("Масив після перетворення:");
        foreach (var element in arr)
        {
            Console.Write($"{element} ");
        }
    }

    static double FindMaxAbsoluteValue(double[] arr)
    {
        // Ініціалізація максимального значення за модулем
        double maxAbsValue = Math.Abs(arr[0]);
        for (int i = 1; i < arr.Length; i++)
        {
            double absValue = Math.Abs(arr[i]);
            // Порівняння з поточним максимальним значенням
            if (absValue > maxAbsValue)
            {
                maxAbsValue = absValue;
            }
        }
        // Повернення максимального значення за модулем
        return maxAbsValue;
    }

    static void RearrangeArray(double[] arr)
    {
        // Лічильник кількості 0 і 1 в масиві
        int zeroAndOneCount = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == 0 || arr[i] == 1)
            {
                zeroAndOneCount++;
            }
        }

        // Перетворення масиву, переставляючи всі елементи, відмінні від 0 та 1, на початок
        int currentIndex = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] != 0 && arr[i] != 1)
            {
                arr[currentIndex] = arr[i];
                currentIndex++;
            }
        }

        // Додавання всіх 0 та 1 до кінця масиву
        for (int i = 0; i < zeroAndOneCount; i++)
        {
            arr[currentIndex] = i == zeroAndOneCount - 1 ? 1 : 0;
            currentIndex++;
        }
    }
}