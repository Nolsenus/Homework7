double[,] RandomMatrix(int rows, int cols, double minValue, double maxValue) {
    double[,] matrix = new double[rows, cols];
    Random rnd = new Random();
    for(int i = 0; i < rows; ++i) {
        for (int j = 0; j < cols; ++j) {
            matrix[i, j] = rnd.NextDouble() * (maxValue - minValue) + minValue;
        }
    }
    return matrix;
}

void PrintMatrix(double[,] matrix) {
    for(int i = 0; i < matrix.GetLength(0); ++i) {
        for (int j = 0; j < matrix.GetLength(1) - 1; ++j) {
            Console.Write($"{matrix[i, j].ToString("0.00")}, ");
        }
        Console.WriteLine(matrix[i, matrix.GetLength(1) - 1].ToString("0.00"));
    }
}

Console.Write("Введите количество строк: ");
try {
    int rows = Convert.ToInt32(Console.ReadLine());
    if (rows <= 0) {
        Console.WriteLine("Количество строк должно быть больше 0.");
    } else {
        Console.Write("Введите количество столбцов: ");
        int cols = Convert.ToInt32(Console.ReadLine());
        if (cols <= 0) {
            Console.WriteLine("количество столбцов должно быть больше 0.");
        } else {
            double[,] matrix = RandomMatrix(rows, cols, -10, 10);
            PrintMatrix(matrix);
        }
    }
} catch {
    Console.WriteLine("Вы ввели не целое число.");
}