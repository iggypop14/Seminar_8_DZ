// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2
// Задайте двумерный массив из целых чисел. 
// Напишите программу, которая удалит строку и столбец, на пересечении которых расположен наименьший элемент массива.

int[,] FillMatrix(int row, int col, int leftRange, int rightRange)
{
    int[,] tempMatrix = new int[row, col];
    var rand = new Random();
    for (int i = 0; i < tempMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < tempMatrix.GetLength(1); j++)
        {
            tempMatrix[i, j] = rand.Next(leftRange, rightRange + 1);
        }
    }
    return tempMatrix;
}

//Печать двумерного массива
void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            System.Console.Write(matrix[i, j] + "\t");
        }
        System.Console.WriteLine();
    }
}

//Ввод данных
int[] ReadInt(string text)
{
    System.Console.Write(text);
    return Array.ConvertAll(Console.ReadLine()!.Split(","), int.Parse); ;
}
void FindMinIndexes(int[,] matrix, out int minI, out int minJ)
{
    minI = 0;
    minJ = 0;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[minI, minJ] > matrix[i, j])
            {
                minI = i;
                minJ = j;
            }
        }
    }
}

int[,] GetResultResult(int[,] matrix, int minI, int minJ)
{
    int[,] resultMatrix = new int[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];

    for (int i = 0, row = 0; i < matrix.GetLength(0); i++)
    {
        if (i == minI) continue;
        for (int j = 0, col = 0; j < matrix.GetLength(1); j++)
        {
            if (j == minJ) continue;
            resultMatrix[row, col] = matrix[i, j];
            col++;
        }
        row++;
    }

    return resultMatrix;
}
// ----------------------------------

int[] size = ReadInt("Задайте количество строк и столбцов через запятую: ");
int[,] matrix = FillMatrix(size[0], size[1], 0, 9);
PrintMatrix(matrix);

FindMinIndexes(matrix, out int minI, out int minJ);
System.Console.WriteLine();

PrintMatrix(GetResultResult(matrix, minI, minJ));
