using System;
class MazeGame
{
    public static int x = 0;
    public static string y="";
    static void Main()
    {
        UI.header();  
        Maze maze =new Maze(5);
        maze.DisplayMaze(maze);

        while(true){
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
            else if(move == "H"){
                UI.help();
            }
            else{
                Console.WriteLine("Invalid move");
            }
            Console.WriteLine();
            maze.DisplayMaze(maze);
        }
    }
}