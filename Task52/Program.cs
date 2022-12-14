int[,] RandomMatrix(int rows, int cols, int minValue, int maxValue) {
    int[,] matrix = new int[rows, cols];
    Random rnd = new Random();
    for(int i = 0; i < rows; ++i) {
        for (int j = 0; j < cols; ++j) {
            matrix[i, j] = rnd.Next(minValue, maxValue + 1);
        }
    }
    return matrix;
}

void PrintMatrix(int[,] matrix) {
    for(int i = 0; i < matrix.GetLength(0); ++i) {
        for (int j = 0; j < matrix.GetLength(1) - 1; ++j) {
            Console.Write($"{matrix[i, j]}, ");
        }
        Console.WriteLine(matrix[i, matrix.GetLength(1) - 1]);
    }
}

void PrintArray(double[] array) {
    for (int i = 0; i < array.Length - 1; ++i) {
        Console.Write($"{array[i]}; ");
    }
    Console.WriteLine(array[array.Length - 1]);
}

double[] FindColumnAvgs(int[,] matrix) {
    double[] result = new double[matrix.GetLength(1)];
    double sum;
    for(int i = 0; i < matrix.GetLength(1); ++i) {
        sum = 0;
        for (int j = 0; j < matrix.GetLength(0); ++j) {
            sum += matrix[j, i];
        }
        result[i] = sum / matrix.GetLength(0);
    }
    return result;   
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
            int[,] matrix = RandomMatrix(rows, cols, -10, 10);
            PrintMatrix(matrix);
            Console.Write("Среднее арифметическое каждого столбца: ");
            PrintArray(FindColumnAvgs(matrix));
        }
    }
} catch {
    Console.WriteLine("Вы ввели не целое число.");
}