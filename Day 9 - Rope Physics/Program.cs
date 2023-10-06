using System.Text; // For stringbuilder

class Program
{
    



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
    }
}