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
        Console.WriteLine();
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
            print("No record found");
        }
        print("");
        print("Actual attempt 1");
    }

    public static void printPrompt(string mazeName)
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

    public static void printMazeAndMove(int attempts, Maze maze){
        print(""); 
        // Print the current number of attempts
        Console.WriteLine("Intents actuals: "+  attempts);
            // Print the current state of the maze
        maze.DisplayMaze();
        print("");
    }

    public static void printAttemptsRecord(int attempts){
        if(attempts == 1){
            Console.WriteLine("Has resolt el laberint en "+  attempts+" intent");
        }
        else{
            Console.WriteLine("Has resolt el laberint en "+  attempts+" intents");
        }
    }

    public static void printNewRecord(bool record){
        if(record){
            print("Nou rècord! Indica el teu nom:");
        }
        else{
            print("No has superat el rècord. Potser la següent vegada.");
        }
    }

    public static void printAllHeader(Maze laberint ,Record record, bool hasRecord)
    {
        header(); // Printing the header
        if(hasRecord){
            printMazeInfo(laberint.getMazeName(), 1,hasRecord, record.getRecord()); // Showing maze info
        }
        else{
            printMazeInfo(laberint.getMazeName(), 1,hasRecord, record.getRecord()); // Showing maze info
        } 
    }
    public static void printErrors(int numError){
        switch(numError){
            case 1 :
                print("No hi ha cap laberint");
                break;
            case 2 :
                print("Moviment invàlid");
                break;
            case 3 :
                print("No es pot arribar al final del laberint");
                break;
            case 4 :
                print("Laberint no existent");
                break;
            case 5 :
                print("Extensió del fitxer invàlida");
                break;
            case 6 :
                print("Cap argument especificat");
                break;
            case 7 :
                print("Masses arguments especificats");
                break;
            case 8 :
                print("Cap moviment fet");
                break;
        }
    }
}