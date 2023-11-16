using System;

class Program
{
    static string SwapZerosAndOnes(string input, int position)
    {
        if (position < 0 || position >= input.Length)
        {
            // Перевіряємо, чи позиція в допустимих межах
            Console.WriteLine("Позиція виходить за межі рядку.");
            return input;
        }

        char[] charArray = input.ToCharArray();
        for (int i = position; i < input.Length; i++)
        {
            if (charArray[i] == '0')
            {
                charArray[i] = '1';
            }
            else if (charArray[i] == '1')
            {
                charArray[i] = '0';
            }
        }

        return new string(charArray);
    }

    static void Main()
    {
        Console.WriteLine("Введіть рядок: ");
        string input = Console.ReadLine();
        int position = 3; // Позиція, з якої почнеться заміна

        string result = SwapZerosAndOnes(input, position);
        Console.WriteLine("Початковий рядок: " + input);
        Console.WriteLine("Результат: " + result);
    }
}
