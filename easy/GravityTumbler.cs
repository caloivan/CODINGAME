using System;

public class Solution
{
    public static void Main()
    {
        string[] inputs = Console.ReadLine().Split(' ');//Read inputs.
        int width = int.Parse(inputs[0]);
        int height = int.Parse(inputs[1]);
        int count = int.Parse(Console.ReadLine());
        int[][] grid = new int[width][];//Create empty grid.
        
        for (int x = 0; x < width; x++)
            grid[x] = new int[height];
        
        for (int y = 0; y < height; y++) {  //Fill the grid. Replace blocks with 0 and 1.
            string raster = Console.ReadLine();
            for (int x = 0; x < width; x++)
                grid[x][y] = (raster[x] == '.') ? 0 : 1;
        }
        
        for (int i = 0; i < count; i++)  {//Rotate grid <count> times and move blocks down after each rotation.
            grid = RotateGrid(grid);
            grid = ApplyPhysics(grid);
        }
        
        for (int y = 0; y < grid[0].Length; y++) { //Print grid.
            for (int x = 0; x < grid.Length; x++)
                Console.Write(grid[x][y] == 0 ? '.' : '#');
            Console.WriteLine();
        }
    }
    
    //Rotates the grid counterclockwise by 90°.
    private static int[][] RotateGrid(int[][] grid)  {
        int[][] gridRotated = new int[grid[0].Length][];
        for (int x = 0; x < gridRotated.Length; x++)  {
            gridRotated[x] = new int[grid.Length];
            for (int y = 0; y < gridRotated[0].Length; y++)
                gridRotated[x][y] = grid[y][x];
        }
        return gridRotated;
    }
    
    //Applies physics to let the blocks fall to the ground.
    private static int[][] ApplyPhysics(int[][] grid)  {
        for (int x = 0; x < grid.Length; x++)
            Array.Sort(grid[x]);
        return grid;
    }
}
