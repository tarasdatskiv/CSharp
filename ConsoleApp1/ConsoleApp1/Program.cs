using System;

class Program
{
    static string ReplaceOnesAndZeros(string input, int startPosition)
    {
        // Перетворюємо рядок в масив символів для зручності редагування
        char[] charArray = input.ToCharArray();

        // Перевіряємо, чи startPosition знаходиться в межах рядка
        if (startPosition >= 0 && startPosition < charArray.Length)
        {
            // Починаємо ітерацію з заданої позиції і замінюємо символи
            for (int i = startPosition; i < charArray.Length; i++)
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

            // Повертаємо змінений рядок
            return new string(charArray);
        }
        else
        {
            // Якщо startPosition некоректна, повертаємо початковий рядок без змін
            return input;
        }
    }

    static void Main()
    {
        Console.WriteLine("Введіть нулі і одиниці для перетворення");
        string input = Convert.ToString(Console.ReadLine());
        Console.WriteLine("Введіть з якої позиції потібно міняти");
        int startPosition = Convert.ToInt32(Console.ReadLine());
        string result = ReplaceOnesAndZeros(input, startPosition);
        Console.WriteLine(result);
    }
}
