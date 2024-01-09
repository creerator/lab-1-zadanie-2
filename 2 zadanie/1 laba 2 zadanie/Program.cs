using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите количество строк матрицы m:");
        int m = ReadPositiveInteger();

        Console.WriteLine("Введите количество столбцов матрицы n:");
        int n = ReadPositiveInteger();

        Console.WriteLine("Введите величину сдвига N:");
        int shift = ReadPositiveInteger();

        Console.WriteLine("Выберите режим сдвига: введите 'вправо' или 'вниз'.");

        string mode = Console.ReadLine().ToLower();

        while (mode != "вправо" && mode != "вниз")
        {
            mode = Console.ReadLine().ToLower();
        }

        int[,] matrix = GenerateMatrix(m, n);
        Console.WriteLine("\nИсходная матрица:");
        PrintMatrix(matrix);

        if (mode == "вправо")
        {
            ShiftMatrixRight(ref matrix, shift);
        }
        else if (mode == "вниз")
        {
            ShiftMatrixDown(ref matrix, shift);
        }

        Console.WriteLine("\nМатрица после сдвига:");
        PrintMatrix(matrix);
    }

    static int ReadPositiveInteger()
    {
        int result;
        while (!int.TryParse(Console.ReadLine(), out result) || result <= 0)
        {
            Console.WriteLine("Ошибка! Введите корректное положительное число.");
        }
        return result;
    }

    static int[,] GenerateMatrix(int rows, int cols)
    {
        int[,] matrix = new int[rows, cols];
        Random rand = new Random();
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = rand.Next(1, 101);
            }
        }
        return matrix;
    }

    static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j].ToString().PadRight(4));
            }
            Console.WriteLine();
        }
    }

    static void ShiftMatrixRight(ref int[,] matrix, int shift)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        shift %= cols;

        for (int i = 0; i < rows; i++)
        {
            int[] tempRow = new int[cols];
            for (int j = 0; j < cols; j++)
            {
                tempRow[(j + shift) % cols] = matrix[i, j];
            }

            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = tempRow[j];
            }
        }
    }

    static void ShiftMatrixDown(ref int[,] matrix, int shift)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        shift %= rows;

        for (int j = 0; j < cols; j++)
        {
            int[] tempCol = new int[rows];
            for (int i = 0; i < rows; i++)
            {
                tempCol[(i + shift) % rows] = matrix[i, j];
            }

            for (int i = 0; i < rows; i++)
            {
                matrix[i, j] = tempCol[i];
            }
        }
    }
}