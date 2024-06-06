using System;

class UI
{
    private static void print(string message)
    {
        Console.WriteLine(message);
    }
    public static void header()
    {
        print("THE MAZE GAME");
        print("=============");
        print("Press H for help");
    }

    public static void help()
    {
        print("Help");
        print("====");
        print("F -> Forward");
        print("L -> Left");
        print("R -> Right");
        print("nF -> N Times Forward");
        print("nL -> N Times Left");
        print("nR -> N Times Right");
        print("H -> Help");
        print("Q -> Quit");
    }

    public static void printMazeInfo(string mazeName, int attemps, bool record, string[] recordString)
    {
        print("");
        Console.WriteLine("Maze: "+mazeName);
        if(record)
        {
            Console.WriteLine("Actual record: "+recordString[2]+" in "+ recordString[1]+" attempts");
        }
        else
        {
            print("Record not found");
        }
        print("");
        print("Actual attempt 1");
    }

    public static void userPrompt(string mazeName)
    {
        Console.WriteLine("┌─("+mazeName+")");
        print("│");
        Console.Write("└─> ");
    }
    public static void printQ()
    {
        print("ARE YOU SCARED?"); 
    }

    public static void printWin(){
        print("You win!!");
    }

    public static void printMazeAndMove(int attempts, Maze maze)
    {
        print(""); 
        // Print the current number of attempts
        Console.WriteLine("Actual attempts: "+  attempts);
            // Print the current state of the maze
        Maze.printMaze(maze.getMazeMap());
        //maze.DisplayMaze();
        print("");
    }

    public static void printAttemptsRecord(int attempts)
    {
        if(attempts == 1){
            Console.WriteLine("Maze finished in "+  attempts+" attempt");
        }
        else{
            Console.WriteLine("Maze finished in "+  attempts+" attempts");
        }
    }

    public static void printNewRecord(bool record)
    {
        if(record){
            print("New record! Enter your name:");
        }
        else{
            print("You haven't broken the record. Maybe next time.");
        }
    }

    public static void printAllHeader(Maze maze ,Record record, bool hasRecord)
    {
        header(); // Printing the header
        if(hasRecord){
            printMazeInfo(maze.getMazeName(), 1,hasRecord, record.getRecord()); // Showing maze info
        }
        else{
            printMazeInfo(maze.getMazeName(), 1,hasRecord, record.getRecord()); // Showing maze info
        } 
    }
    public static void printErrors(int numError)
    {
        switch(numError)
        {
            case 1 :
                print("No maze found");
                break;
            case 2 :
                print("Invalid move");
                break;
            case 3 :
                print("Can't finish the maze");
                break;
            case 4 :
                print("Maze not found");
                break;
            case 5 :
                print("Invalid file");
                break;
            case 6 :
                print("No argument found");
                break;
            case 7 :
                print("To much arguments");
                break;
            case 8 :
                print("No movement done");
                break;
        }
    }
}