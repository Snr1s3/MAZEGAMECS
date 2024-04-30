// Maze.cs
using System;
public class Maze
{
    // Define the properties of the Maze here
    public char[][] mazeChars;

    // Constructor
    public Maze(int maze)
    {
        mazeChars = new char[maze][];
        for (int i = 0; i < maze; i++)
        {
            mazeChars[i] = new char[maze];
            for (int j = 0; j < maze; j++)
            {
                mazeChars[i][j] = '0';
            }
        }
    }

    public void DisplayMaze(Maze maze){
        for (int i = 0; i < maze.mazeChars.Length; i++)
        {
            Console.Write(" ");
            for (int j = 0; j < maze.mazeChars[i].Length; j++)
            {
                Console.Write(" ");
                Console.Write(maze.mazeChars[i][j]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
    // Other methods for the Maze class
}