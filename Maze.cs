// Maze.cs
using System;
public class Maze
{
    // Define the properties of the Maze here
    private char[][] mazeChars;
    private string filename="";
    private string  mazeName="";


    // Constructor
    public Maze(int maze, string name)
    {   
        filename=name;
        mazeName = name.Replace("mazes/","");
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
    public void getMaze()
    { 
        printMaze(maze);
    }

    public void setMaze()
    { 
        maze = readMaze(mazeFileName);
    }

    public char[][] getMazeMap()
    { 
        return maze;
    }

    public string getMazeName()
    { 
        return mazeName;
    }
    public int[] startPosition(char[][] maze)
    {
        for (int i = 0; i < maze.length; i++)
        {
            for (int p = 0; p< maze[0].length; p++)
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
        int[][] directions = {{0, 1}, {1, 0}, {0, -1}, {-1, 0}}; // right, down, left, up
        for (int i = 0; i < directions.length; i++)
        {
            int newX = x + directions[i][0], newY = y + directions[i][1];
            if (newX >= 0 && newX < maze.length && newY >= 0 && newY < maze[0].length && maze[newX][newY] != 'X' && canFinish(maze, newX, newY))
            {
                return true;
            }
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
        if(args.length != 1){
            if( args.length==0){
                UI.printErrors(6);
            }
            else{
                UI.printErrors(7);
            }
            return false;
        }
        return true;
    }

    public static bool argExtensionCheck(String filename){
        if(filename.endsWith(".dat") || !filename.contains(".")) {
            return true;
        }
        UI.printErrors(5);
        return false;
    }

    public static bool MazeCheck(File file, boolean emptyMaze, String filename){
        if(file.exists()) { // Checking if the file exists
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