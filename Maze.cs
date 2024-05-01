// Maze.cs
using System;
using System.IO;
public class Maze
{
    // Define the properties of the Maze here
    private char[][] mazeChars;
    private string filename="";
    private string  mazeName="";


    // Constructor
    public Maze(string name)
    {   
        filename=name;
        mazeName = name.Replace("mazes/","");
    }
    public void getMaze()
    { 
        printMaze(mazeChars);
    }

    public void setMaze()
    { 
        mazeChars = readMaze(filename);
    }

    public char[][] getMazeMap()
    { 
        return mazeChars;
    }

    public string getMazeName()
    { 
        return mazeName;
    }
    public int[] startPosition(char[][] maze)
    {
        for (int i = 0; i < maze.Length; i++)
        {
            for (int p = 0; p< maze[0].Length; p++)
            {
                if (maze[i][p] == 'E' || maze[i][p] == 'L' || maze[i][p] == 'R' || maze[i][p] == 'D' ||maze[i][p] == 'U')
                {
                    return new int[]{i, p};
                }
            }
        }
        return null;
    }

    public bool canFinish(char[][] maze, int x, int y)
    {
        if (maze[x][y] == 'G')
        {
            return true;
        }
        maze[x][y] = 'X'; // Mark the current position as visited
        int[][] directions = { new int[] {0, 1}, new int[] {1, 0}, new int[] {0, -1}, new int[] {-1, 0} };// right, down, left, up
        for (int i = 0; i < directions.Length; i++)
        {
            int newX = x + directions[i][0], newY = y + directions[i][1];
            if (newX >= 0 && newX < maze.Length && newY >= 0 && newY < maze[0].Length && maze[newX][newY] != 'X' && canFinish(maze, newX, newY))
            {
                return true;
            }
        }
        return false;
    }
    public static char[][] readMaze(string path)
    {
        string[] lines = File.ReadAllLines(path);
        string[] size = lines[0].Split('x');
        int rows = int.Parse(size[0]);
        int cols = int.Parse(size[1]);
        char[][] maze = new char[rows][];
        for (int i = 0; i < maze.Length; i++)
        {
            maze[i] = new char[cols];
            for (int j = 0; j < maze[i].Length; j++)
            {
                maze[i][j] = lines[i + 1][j];
            }
        }
        return maze;
    }
    public static bool checkMaze(string filePath){
        FileInfo file = new FileInfo(filePath);
        if (file.Length == 0)
        {
            return true;
        }
        return false;     
    }
    public static void printMaze(char[][] maze)
    { //Print the maze translated to a graphic representation
        
        for(int i = 0; i< maze.Length; i++)
        {            
            for(int p =0;p<maze[i].Length;p++)
            {
                // Print the maze with different characters for different directions
                // and different types of cells
                if( maze[i][p]=='R' || maze[i][p]=='E')
                {
                    Console.Write('→');
                    Console.Write(' ');
                }
                else if( maze[i][p]=='L')
                {
                    Console.Write('←');
                    Console.Write(' ');
                }
                else if( maze[i][p]=='U')
                {
                    Console.Write('↑');
                    Console.Write(' ');
                }
                else if( maze[i][p]=='D')
                {
                    Console.Write('↓');
                    Console.Write(' ');
                }
                else if( maze[i][p]=='G')
                {
                    Console.Write(' ');
                    Console.Write(' ');
                }
                else if(maze[i][p]=='W')
                {
                    Console.Write('■');
                    Console.Write(' ');
                }
                else if(maze[i][p]=='C')
                {
                    Console.Write(' ');
                    Console.Write(' ');
                }
                else if(i==0 && p ==0)
                {
                    Console.Write('┌');
                    Console.Write('─');
                }
                else if(i==0 && p==maze[i].Length-1)
                {
                    Console.Write('┐');
                }
                else if(i==maze.Length-1 && p ==0)
                {
                    Console.Write('└');
                    Console.Write('─');
                }
                else if(i==maze.Length-1  && p==maze[i].Length-1)
                {
                    Console.Write('┘');
                }
                else if(i==0 || i==maze.Length-1)
                {
                    Console.Write('─');
                    Console.Write('─');
                }
                else if(p==0 || p==maze[i].Length-1)
                {
                    Console.Write('│');
                    Console.Write(' ');
                }
                else
                {
                    Console.Write('·');
                    Console.Write(' ');
                }
            }
            Console.WriteLine("");
        }
    }
    public static bool argsNumCheck(String[] args){
        if(args.Length != 1){
            if( args.Length==0){
                UI.printErrors(6);
            }
            else{
                UI.printErrors(7);
            }
            return false;
        }
        return true;
    }

    public static bool argExtensionCheck(string filename){
        if(filename.EndsWith(".dat") || !filename.Contains(".")) {
            return true;
        }
        UI.printErrors(5);
        return false;
    }

    public static bool MazeCheck(bool emptyMaze, string filename){
        if(File.Exists(filename)) { // Checking if the file exists
            emptyMaze =!checkMaze(filename);
            if(!emptyMaze){
                UI.printErrors(1);
                return false;
            }
            return true;
        }
        else {
            UI.printErrors(4);
            return false;
        }
        
    }

    
    public void DisplayMaze(){
        for (int i = 0; i < mazeChars.Length; i++)
        {
            Console.Write("");
            for (int j = 0; j < mazeChars[i].Length; j++)
            {
                Console.Write(" ");
                Console.Write(mazeChars[i][j]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
    // Other methods for the Maze class
}