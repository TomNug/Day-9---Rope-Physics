using System.Text; // For stringbuilder

class Program
{
    public static (int, int) Follow(int headRow, int headCol, int tailRow, int tailCol)
    {
        // Assume no movement
        int newRow = tailRow;
        int newCol = tailCol;

        // Calculate distances between head and tail
        int rowDiff = headRow - tailRow; 
        int colDiff = headCol - tailCol;

        // Head is far enough away to move the tail
        if (rowDiff > 1 || colDiff > 1)
        {
            // If in same row or column
            if (rowDiff == 0 || colDiff == 0)
            {
                // Moves one closer to head
                newCol = (headCol + tailCol) / 2;
                newRow = (headRow + tailRow) / 2;
            }
            // Difference in row and column
            else
            {
                if (Math.Abs(rowDiff) == 1)
                {
                    newRow += rowDiff;
                    newCol += colDiff / 2;
                }
                else
                {
                    newRow += rowDiff / 2;
                    newCol += colDiff;
                }
            }
        }
        return (newRow, newCol);
    }



    public static void DisplayGrid(char[,] grid)
    {
        for(int row=0; row<grid.GetLength(0); row++)
        {
            StringBuilder sb = new StringBuilder();
            
            for (int col=0; col<grid.GetLength(1); col++)
            {
                sb.Append(grid[row,col]);
            }
            Console.WriteLine(sb.ToString());
        }
    }

    public static void Tests()
    {
        // Tests

        // Down 
        (int, int) result = Follow(4, 2, 2, 2);
        Console.WriteLine(String.Format("D: H(4,2), T(2,2) -> ({0},{1}) <(3,2)>", result.Item1, result.Item2));

        // Up
        result = Follow(0, 2, 2, 2);
        Console.WriteLine(String.Format("U: H(0,2), T(2,2) -> ({0},{1}) <(1,2)>", result.Item1, result.Item2));

        // Left
        result = Follow(2, 0, 2, 2);
        Console.WriteLine(String.Format("L: H(2,0), T(2,2) -> ({0},{1}) <(2,1)>", result.Item1, result.Item2));

        // Right
        result = Follow(2, 4, 2, 2);
        Console.WriteLine(String.Format("R: H(2,4), T(2,2) -> ({0},{1}) <(2,3)>", result.Item1, result.Item2));

        // NNE
        result = Follow(0, 3, 2, 2);
        Console.WriteLine(String.Format("NNE: H(0,3), T(2,2) -> ({0},{1}) <(1,3)>", result.Item1, result.Item2));

        // ENE
        result = Follow(1, 4, 2, 2);
        Console.WriteLine(String.Format("ENE: H(1,4), T(2,2) -> ({0},{1}) <(1,3)>", result.Item1, result.Item2));

        // ESE
        result = Follow(3, 4, 2, 2);
        Console.WriteLine(String.Format("ESE: H(3,4), T(2,2) -> ({0},{1}) <(3,3)>", result.Item1, result.Item2));

        // SSE
        result = Follow(4, 3, 2, 2);
        Console.WriteLine(String.Format("SSE: H(4,3), T(2,2) -> ({0},{1}) <(3,3)>", result.Item1, result.Item2));

        // SSW
        result = Follow(4, 1, 2, 2);
        Console.WriteLine(String.Format("SSW: H(4,1), T(2,2) -> ({0},{1}) <(3,1)>", result.Item1, result.Item2));

        // WSW
        result = Follow(3, 0, 2, 2);
        Console.WriteLine(String.Format("WSW: H(3,0), T(2,2) -> ({0},{1}) <(3,1)>", result.Item1, result.Item2));

        // WNW
        result = Follow(1, 0, 2, 2);
        Console.WriteLine(String.Format("WNW: H(1,0), T(2,2) -> ({0},{1}) <(1,1)>", result.Item1, result.Item2));

        // NNW
        result = Follow(0, 1, 2, 2);
        Console.WriteLine(String.Format("NNW: H(0,1), T(2,2) -> ({0},{1}) <(1,1)>", result.Item1, result.Item2));

    }

    public static void Main(string[] args)
    {
        char[,] grid =  {
                    {'.','.','.','.','.','.'},
                    {'.','.','.','.','.','.'},
                    {'.','.','.','.','.','.'},
                    {'.','.','.','.','.','.'},
                    {'.','.','.','.','.','.'}
        };
        DisplayGrid(grid);

        Tests();
        
    }

}