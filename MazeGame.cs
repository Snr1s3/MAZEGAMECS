using System;
using System.IO;
class MazeGame
{
    public static int x = 0;
    public static string y="";
    static void Main(string[] args)
    {   
        int moveExitCode=0; // Variable to store the exit code of the move
        bool hasRecord= false;
        bool emptyMaze= false;
        if(!Maze.argsNumCheck(args)){
            return;
        }
        string filename = "mazes/"+args[0];
        if(!Maze.argExtensionCheck(filename)){
            return;
        }
        if(!filename.EndsWith(".dat")) {
            filename+=".dat";
        }
        if(!Maze.MazeCheck(emptyMaze, filename)){
            return;
        }
        Maze maze = new Maze(filename); // Creating a Maze object with the file
        Maze mazeCanReachEnd = new Maze(filename);
        mazeCanReachEnd.setMaze();

        int[] start = mazeCanReachEnd.startPosition(mazeCanReachEnd.getMazeMap());
        bool canReach = mazeCanReachEnd.canFinish(mazeCanReachEnd.getMazeMap(), start[0], start[1]);                        
        mazeCanReachEnd = null;
        if(!canReach){
            UI.printErrors(3);
            return;
        }
        Player player = Player.getPlayer(start); // Creating a new Player object
        Record record = new Record();
        if(record.checkRecord(maze.getMazeName())){
           hasRecord=true;
        }
        UI.printAllHeader(maze, record, hasRecord);
        maze.setMaze(); // Setting up the maze
        player.setInitialPosi(maze.getMazeMap());// Setting the initial position of the player
        maze.getMaze(); // Getting the maze
        Console.WriteLine();
       while(true){
            UI.userPrompt(maze.getMazeName());
            string input=Console.ReadLine();
            input = input.ToUpper();
            if(!Input.invalidMoves(input)){
                input=input.ToUpper();
                input =Input.playerInput(input); // Reading user input
                if(Input.containsQOrH(input)){
                    break; 
                }        
                // Otherwise, loop through each character in the user's input
                for(int i =0; i<input.Length;i++){
                    // Turn the player left based on the current character
                    player.turnLeft(input[i],maze.getMazeMap());

                    // Turn the player right based on the current character
                    player.turnRight(input[i],maze.getMazeMap());
                    // Move the player forward based on the current character
                    // and store the exit code of the move
                    moveExitCode = player.moveForward(input[i],maze.getMazeMap());
                    /*Exit Code Meaning for moveExitCode
                    1-Crash in to a wall
                    2-Continue
                    3-Exit Reached*/
                    // If the exit code of the move is 1, break the loop
                    if(moveExitCode== 1){
                        player.increaseAttempts(); // Incrementing the attempts of the player
                        break;
                    }
                    // If the exit code of the move is 3, print "Aconseguit!" and break the loop
                    else if( moveExitCode == 3){
                        UI.printWin();
                        break;
                    }
                }        
            }
            UI.printMazeAndMove(player.getAttempts(),maze);
            //System.out.println(input);// Un comment the line to see the player input
            // If the exit code of the move is 3, print a success message and break the outer loop
            if( moveExitCode == 3){
                record.newRecord(hasRecord, player.getAttempts(), maze.getMazeName());
                break;
            }
        }          
    }
}