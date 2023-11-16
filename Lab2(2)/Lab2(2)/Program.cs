using System;

class Program
{
    static void Main()
    {
        double[][] matrix = new double[][]
        {
            new double[] { 2, 1, -1 },
            new double[] { -3, -1, 2 },
            new double[] { -2, 1, 2 }
        };

        int rowCount = matrix.Length; // Отримуємо кількість рядків у матриці
        int colCount = matrix[0].Length; // Отримуємо кількість стовпців у матриці

        for (int i = 0; i < rowCount; i++)
        {
            double maxElement = 0; // Ініціалізація максимального елемента
            int maxRowIndex = -1; // Ініціалізація індексу рядка з максимальним елементом
            for (int j = i; j < rowCount; j++)
            {
                if (Math.Abs(matrix[j][i]) > maxElement)
                {
                    maxElement = Math.Abs(matrix[j][i]); // Знаходимо максимальний елемент у стовпці
                    maxRowIndex = j; // Запам'ятовуємо індекс рядка з максимальним елементом
                }
            }

            if (maxRowIndex != -1)
            {
                double[] temp = matrix[i]; // Обмін поточного рядка з рядком з максимальним елементом
                matrix[i] = matrix[maxRowIndex];
                matrix[maxRowIndex] = temp;
            }

            for (int j = i + 1; j < rowCount; j++)
            {
                double coefficient = matrix[j][i] / matrix[i][i]; // Знаходимо коефіцієнт для нулювання елементів нижче головної діагоналі
                for (int k = i; k < colCount; k++)
                {
                    matrix[j][k] -= coefficient * matrix[i][k]; // Віднімаємо коефіцієнт, помножений на головний рядок, від інших рядків
                }
            }
        }

        Console.WriteLine("Трикутна матриця:");
        for (int i = 0; i < rowCount; i++)
        {
            for (int j = 0; j < colCount; j++)
            {
                Console.Write(matrix[i][j] + " "); // Виводимо трикутну матрицю
            }
            Console.WriteLine();
        }
    }
}
