using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Просимо користувача ввести текстовий рядок.
        Console.WriteLine("Введіть текстовий рядок:");
        string inputText = Console.ReadLine();

        // Розділяємо введений текст на окремі слова, використовуючи роздільники пробіл, кома, крапка, знаки оклику і питання.
        string[] words = inputText.Split(new char[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

        // Ініціалізуємо лічильники для слів, які закінчуються на голосну літеру і коротких слів.
        int vowelEndingWordsCount = 0;
        int shortWordsCount = 0;

        // Створюємо масив латинських літер для перевірки на наявність латинських символів у словах.
        char[] latinLetters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

        // Виводимо заголовок для слів, які закінчуються на голосну літеру.
        Console.WriteLine("Слова, які закінчуються на голосну літеру:");

        // Проходимося по кожному слову у масиві слів.
        foreach (string word in words)
        {
            // Отримуємо останній символ у слові.
            char lastChar = word[word.Length - 1];

            // Перевіряємо, чи останній символ є голосною літерою (англійські та українські голосні).
            if ("AEIOUaeiouАЕІОУаеіоу".Contains(lastChar))
            {
                Console.WriteLine(word); // Виводимо слово, яке закінчується на голосну літеру.
                vowelEndingWordsCount++; // Збільшуємо лічильник слів, які закінчуються на голосну літеру.
            }

            // Перевіряємо довжину слова і збільшуємо лічильник коротких слів (менше 5 символів).
            if (word.Length < 5)
            {
                shortWordsCount++;
            }

            // Перевіряємо, чи слово містить латинські літери.
            bool containsLatinLetters = false;
            foreach (char letter in latinLetters)
            {
                if (word.Contains(letter))
                {
                    containsLatinLetters = true;
                    break;
                }
            }

            // Якщо слово містить латинські літери, видаляємо його з вихідного тексту.
            if (containsLatinLetters)
            {
                inputText = inputText.Replace(word, "");
            }
        }

        // Виводимо результати після обробки тексту.
        Console.WriteLine($"Кількість слів, які закінчуються на голосну літеру: {vowelEndingWordsCount}");
        Console.WriteLine($"Слова, довжина яких менше п'яти символів: {shortWordsCount}");
        Console.WriteLine("Текст без слів, які містять латинські літери:");
        Console.WriteLine(inputText);
    }
}
