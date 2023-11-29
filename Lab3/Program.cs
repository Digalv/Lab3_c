internal class Program
{
    private static void Main(string[] args)
    {
        Random rnd = new Random();
        double[,] matrix = getRandomMatrix();
        printMatrix(matrix);
        Console.WriteLine(task913(matrix));
        printMatrix(task920(getRandomMatrix()));
        Console.WriteLine(task939(matrix, rnd.Next(2, matrix.GetLength(0))));
        printMatrix(task976());
    }

    public static double[,] getRandomMatrix() 
    {
        Random rnd = new Random();
        int size = rnd.Next(2, 11);
        double[,] matrix = new double[size, size];
        for (int i = 0; i < size; i++)
        {
            for(int j = 0; j < size; j++) 
            {
                matrix[i,j] = Math.Round(rnd.NextDouble() * 100);
            }
        }
        return matrix;
    }
    static void printMatrix(double[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"{matrix[i, j],-8}"); // Используем форматирование для выравнивания
            }
            Console.WriteLine(); // Переход на новую строку после вывода всех элементов строки
        }
    }
    static void printMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"{matrix[i, j],-8}"); // Используем форматирование для выравнивания
            }
            Console.WriteLine(); // Переход на новую строку после вывода всех элементов строки
        }
    }

    static int task913 (double[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        double minAverage = double.MaxValue;
        int minAvgRow = -1;

        for (int i = 0; i < rows; i++)
        {
            double rowSum = 0;

            for (int j = 0; j < cols; j++)
            {
                rowSum += matrix[i, j];
            }

            double rowAverage = rowSum / cols;

            if (rowAverage < minAverage)
            {
                minAverage = rowAverage;
                minAvgRow = i;
            }
        }

        return minAvgRow;
    }
    static double[,] task920(double[,] matrix)
    {
        Console.WriteLine("Before:");
        printMatrix(matrix);
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = i + 1; j < cols; j++)
            {
                if (i != j && i + j != rows - 1)
                {
                    double temp = matrix[i, j];
                    matrix[i, j] = matrix[j, i];
                    matrix[j, i] = temp;
                }
            }
        }
        Console.WriteLine("After:");
        return matrix;
    }
    static double task939(double[,] matrix, int targetColumn)
    {
        targetColumn--;
        if (targetColumn < 0 || targetColumn >= matrix.GetLength(0))
        {
            Console.WriteLine("Некорректный номер столбца.");
            return double.MinValue;
        }

        return matrix[matrix.GetLength(0) - targetColumn - 1, targetColumn];
    }
    static int[,] task976() 
    {
        int[,] matrix = new int[10, 10];;
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                matrix[i, j] = (j >= i) ? j - i + 1 : 0;
            }
            
        } 
        return matrix;
    }
}