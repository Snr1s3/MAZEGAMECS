using System;
class MazeGame
{
    public static int x = 0;
    public static string y="";
    static void Main()
    {
        Console.WriteLine("THE MAZE GAME");
        Console.WriteLine("=============");
        
        Maze maze =new Maze(5);
        maze.DisplayMaze(maze);

    }
}