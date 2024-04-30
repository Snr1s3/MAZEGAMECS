using System;
using System.IO;
class MazeGame
{
    public static int x = 0;
    public static string y="";
    static void Main(string[] args)
    {
        string filename = argsCheck(args);
        if(filename.Equals("BREAK")){
            return;
        }
    
        UI.header();  
        Maze maze =new Maze(5, filename);
        maze.DisplayMaze(maze);

        while(true)
        {
            Console.Write("Enter your move: ");
            string move = Console.ReadLine();
            if(move == "F" || move == "f"){
                x++;
                Console.WriteLine(x);
            }
            else if(move == "L" || move == "l"){
                y = "L";
                Console.WriteLine(y);
            }
            else if(move == "R" || move == "r"){
                y = "R";
                Console.WriteLine(y);
            }
            else if(move == "H" || move == "h"){
                UI.help();
            }
            else if(move == "Q" || move == "q"){
                break;
            }
            else{
                Console.WriteLine("Invalid move");
            }
            Console.WriteLine();
            maze.DisplayMaze(maze);
        }
    }

    public static string argsCheck(string[] args)
    {
        if (args.Length < 1)
        {
            Console.WriteLine("Please provide the size of the maze as a command line argument.");
            return "BREAK";
        }
        if(args[0].Contains(".") && !args[0].EndsWith(".dat")){
            Console.WriteLine("Please provide an argument with a valid extension");
            return "BREAK";
        }
        if(!args[0].EndsWith(".dat")){
            args[0]+=".dat";
        }
        string filename = "mazes/"+args[0];
        if (!File.Exists(filename))
        {
            Console.WriteLine($"File {filename} does not exist.");
            return "BREAK";
        }
        return filename;
    }
}