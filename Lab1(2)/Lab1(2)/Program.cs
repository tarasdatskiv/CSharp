using System;

class Program
{
    static void Main()
    {
        Console.Write("Введіть розмірність матриці (n): ");
        int n = int.Parse(Console.ReadLine());

        int[,] matrix = new int[n, n];

        // Введення матриці
        Console.WriteLine("Введіть елементи матриці:");
        for (int i = 0; i < n; i++)
        {
            string[] rowElements = Console.ReadLine().Split(' ');
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = int.Parse(rowElements[j]);
            }
        }

        int[] sequence = BuildSequence(matrix, n);

        Console.WriteLine("Побудована послідовність:");
        foreach (int value in sequence)
        {
            Console.Write(value + " ");
        }

        Console.ReadLine();
    }

    static int[] BuildSequence(int[,] matrix, int n)
    {
        int[] sequence = new int[n];

        for (int k = 0; k < n; k++)
        {
            int min = matrix[k, 0];

            for (int j = 1; j <= k; j++)
            {
                if (matrix[k, j] < min)
                {
                    min = matrix[k, j];
                }
            }

            sequence[k] = min;
        }

        return sequence;
    }
}
