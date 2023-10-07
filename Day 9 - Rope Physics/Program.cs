using System.Text; // For stringbuilder

class Program
{
    public static (int, int) Follow((int,int) headRowCol, (int, int) tailRowCol)
    {
        // Assume no movement
        (int,int) newRowCol = tailRowCol;

        // Calculate distances between head and tail
        int rowDiff = headRowCol.Item1 - tailRowCol.Item1; 
        int colDiff = headRowCol.Item2 - tailRowCol.Item2;

        // Head is far enough away to move the tail
        if (Math.Abs(rowDiff) > 1 || Math.Abs(colDiff) > 1)
        {
            // If in same row or column
            if (rowDiff == 0 || colDiff == 0)
            {
                // Moves one closer to head
                newRowCol.Item2 = (headRowCol.Item2 + tailRowCol.Item2) / 2;
                newRowCol.Item1 = (headRowCol.Item1 + tailRowCol.Item1) / 2;
            }
            // Difference in row and column
            else
            {
                if (Math.Abs(rowDiff) == 1)
                {
                    newRowCol.Item1 += rowDiff;
                    newRowCol.Item2 += colDiff / 2;
                }
                else
                {
                    newRowCol.Item1 += rowDiff / 2;
                    newRowCol.Item2 += colDiff;
                }
            }
        }
        return newRowCol;
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
        (int, int) result = Follow((4, 2), (2, 2));
        Console.WriteLine(String.Format("D: H(4,2), T(2,2) -> ({0},{1}) <(3,2)>", result.Item1, result.Item2));

        // Up
        result = Follow((0, 2), (2, 2));
        Console.WriteLine(String.Format("U: H(0,2), T(2,2) -> ({0},{1}) <(1,2)>", result.Item1, result.Item2));

        // Left
        result = Follow((2, 0), (2, 2));
        Console.WriteLine(String.Format("L: H(2,0), T(2,2) -> ({0},{1}) <(2,1)>", result.Item1, result.Item2));

        // Right
        result = Follow((2, 4), (2, 2));
        Console.WriteLine(String.Format("R: H(2,4), T(2,2) -> ({0},{1}) <(2,3)>", result.Item1, result.Item2));

        // NNE
        result = Follow((0, 3), (2, 2));
        Console.WriteLine(String.Format("NNE: H(0,3), T(2,2) -> ({0},{1}) <(1,3)>", result.Item1, result.Item2));

        // ENE
        result = Follow((1, 4), (2, 2));
        Console.WriteLine(String.Format("ENE: H(1,4), T(2,2) -> ({0},{1}) <(1,3)>", result.Item1, result.Item2));

        // ESE
        result = Follow((3, 4), (2, 2));
        Console.WriteLine(String.Format("ESE: H(3,4), T(2,2) -> ({0},{1}) <(3,3)>", result.Item1, result.Item2));

        // SSE
        result = Follow((4, 3), (2, 2));
        Console.WriteLine(String.Format("SSE: H(4,3), T(2,2) -> ({0},{1}) <(3,3)>", result.Item1, result.Item2));

        // SSW
        result = Follow((4, 1), (2, 2));
        Console.WriteLine(String.Format("SSW: H(4,1), T(2,2) -> ({0},{1}) <(3,1)>", result.Item1, result.Item2));

        // WSW
        result = Follow((3, 0), (2, 2));
        Console.WriteLine(String.Format("WSW: H(3,0), T(2,2) -> ({0},{1}) <(3,1)>", result.Item1, result.Item2));

        // WNW
        result = Follow((1, 0), (2, 2));
        Console.WriteLine(String.Format("WNW: H(1,0), T(2,2) -> ({0},{1}) <(1,1)>", result.Item1, result.Item2));

        // NNW
        result = Follow((0, 1), (2, 2));
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

        string[] movs = System.IO.File.ReadAllLines(@"C:\Users\Tom\Documents\Advent\Day 9 - Rope Physics\Day 9 - Rope Physics\data_test.txt");
        //string[] rows = System.IO.File.ReadAllLines(@"C:\Users\Tom\Documents\Advent\Day 8 - Tree Heights\Day 8 - Tree Heights\data_full.txt");


        (int, int) headRowCol = (grid.GetLength(0), 0);
        (int, int) tailRowCol = (grid.GetLength(0), 0);

        foreach(string mov in movs)
        {
            string[] splitMov = mov.Split(" ");
            string dir = splitMov[0];
            int dist = int.Parse(splitMov[1]);
        }

    }

}