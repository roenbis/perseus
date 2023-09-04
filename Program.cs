
public class SudokuSolver
{
    public bool IsValidNumber(int[,] grid, int row, int col, int number)
    {
        for (int x = 0; x < 9; x++)
        {
            if (grid[row, x] == number)
            {
                return false;
            }
        }
        
        for (int x = 0; x < 9; x++)
        {
            if (grid[x, col] == number)
            {
                return false;
            }
        }

        int cornerRow = row - row % 3;
        int cornerCol = col - col % 3;
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                if (grid[cornerRow + x, cornerCol + y] == number)
                    return false;
            }
        }

        return true;
    }

    public bool Solve(int[,] grid, int row, int col)
    {
        if (col == 9)
        {
            if (row == 8)
                return true;
            row++;
            col = 0;
        }

        if (grid[row, col] > 0)
            return Solve(grid, row, col + 1);

        for (int num = 1; num <= 9; num++)
        {
            if (IsValidNumber(grid, row, col, num))
            {
                grid[row, col] = num;
                if (Solve(grid, row, col + 1))
                    return true;
            }

            grid[row, col] = 0;
        }

        return false;
    }

    public void PrintGrid(int[,] grid)
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                Console.Write(grid[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    public void SolveSudoku()
    {
        int[,] grid = new int[,]
        {
            { 0, 0, 0, 0, 0, 0, 8, 4, 9 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 2 },
            { 0, 0, 0, 6, 4, 2, 0, 0, 1 },
            { 3, 0, 0, 0, 0, 5, 9, 0, 0 },
            { 0, 9, 0, 0, 6, 0, 0, 2, 0 },
            { 0, 0, 1, 8, 0, 0, 0, 0, 7 },
            { 2, 0, 0, 4, 5, 1, 0, 0, 0 },
            { 6, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 1, 7, 3, 0, 0, 0, 0, 0, 0 }
        };

        if (Solve(grid, 0, 0))
        {
            PrintGrid(grid);
        }
        else
        {
            Console.WriteLine("No Solution For This Sudoku");
        }
    }

    public static void Main()
    {
        SudokuSolver solver = new SudokuSolver();
        solver.SolveSudoku();
    }
}