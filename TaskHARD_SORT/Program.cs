int[,] RandomMatrix(int rows, int cols, int minValue, int maxValue) {
    int[,] result = new int[rows, cols];
    Random rnd = new Random();
    for (int i = 0; i < rows; ++i) {
        for (int j = 0; j < cols; ++j) {
            result[i, j] = rnd.Next(minValue, maxValue);
        }
    }
    return result;
}

void PrintMatrix(int[,] matrix) {
    for(int i = 0; i < matrix.GetLength(0); ++i) {
        for (int j = 0; j < matrix.GetLength(1) - 1; ++j) {
            Console.Write($"{matrix[i, j]}, ");
        }
        Console.WriteLine(matrix[i, matrix.GetLength(1) - 1]);
    }
}

void SortMatrix (int[,] matrix) {
    for (int i = 0; i < matrix.GetLength(0) * matrix.GetLength(1) - 1; ++i) {
        int minRow = i / matrix.GetLength(1);
        int minCol = i % matrix.GetLength(1);
        for (int j = i + 1; j < matrix.GetLength(0) * matrix.GetLength(1); ++j) {
            if (matrix[minRow, minCol] > matrix[j / matrix.GetLength(1), j % matrix.GetLength(1)]) {
                minRow = j / matrix.GetLength(1);
                minCol = j % matrix.GetLength(1);
            }
        }
        int temp = matrix[i / matrix.GetLength(1), i % matrix.GetLength(1)];
        matrix[i / matrix.GetLength(1), i % matrix.GetLength(1)] = matrix[minRow, minCol];
        matrix[minRow, minCol] = temp;
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
            int[,] matrix = RandomMatrix(rows, cols, 10, 100);
            PrintMatrix(matrix);
            SortMatrix(matrix);
            Console.WriteLine();
            PrintMatrix(matrix);
        }
    }
} catch {
    Console.WriteLine("Вы ввели не целое число.");
}