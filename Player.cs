using System;

class Player
{
    private static Player player=null;
    private static int[] playerPosi=new int[2];
    private int[] initialPlayerPosi=new int[2];
    private int attempts=1;
    private string direction;
    private string startDirection;

    private Player(){}

    public static Player getPlayer(int[] nPlayerPosi)
    {
        if(player==null)
        {
            player = new Player();
            playerPosi= nPlayerPosi;
        }
        return player;
    }

    public int getIntents()
    {
        if(player == null ) player = new Player();
        return attempts;
    }

    public int[] getPosicio()
    {
        return playerPosi;
    }

    public void increaseAttempts()
    {
        attempts++;
    }

    public void setInitialPosi(char[][] maze)
    {
        for(int i = 0; i< maze.Length; i++){            
            for(int p =0;p<maze[i].Length;p++){
                if(maze[i][p]=='E'){
                    playerPosi[0]=i;
                    playerPosi[1]=p;
                    initialPlayerPosi[0]=i;
                    initialPlayerPosi[1]=p;
                    if(p==0){
                        direction = "right";
                        startDirection = "right";
                        maze[i][p]='R';
                    }
                    else if(p==maze.Length){
                        direction = "left";
                        startDirection = "left";
                        maze[i][p]='L';
                    }
                    else if(i==0){
                        direction ="down";
                        startDirection="down";
                        maze[i][p]='D';
                    }
                    else if(i==maze.Length-1){
                        direction = "up";
                        startDirection="up";
                        maze[i][p]='U';
                    }

                }
            }
        }
    }
    public  void turnLeft(char input, char[][] maze){
        if(input == 'L'){
            if(direction.Equals("right")){
                direction = "up";
                maze[playerPosi[0]][playerPosi[1]] = 'U';
            }
            else if(direction.Equals("left")){
                direction = "down";
                maze[playerPosi[0]][playerPosi[1]] = 'D';
            }
            else if(direction.Equals("up")){
                direction ="left";
                maze[playerPosi[0]][playerPosi[1]] = 'L';
            }
            else if(direction.Equals("down")){
                direction = "right";
                maze[playerPosi[0]][playerPosi[1]] = 'R';
            }
        }
    }
    public  void turnRight(char input, char[][] maze){
        if(input == 'R'){
            if(direction.Equals("right")){
                direction = "down";
                maze[playerPosi[0]][playerPosi[1]] = 'D';
            }
            else if(direction.Equals("left")){
                direction = "up";
                maze[playerPosi[0]][playerPosi[1]] = 'U';
            }
            else if(direction.Equals("up")){
                direction ="right";
                maze[playerPosi[0]][playerPosi[1]] = 'R';
            }
            else if(direction.Equals("down")){
                direction = "left";
                maze[playerPosi[0]][playerPosi[1]] = 'L';
            }
        }
    }
    public  int moveForward(char input, char[][] maze){
        int[] playerPosiBKP= playerPosi;
        if(input == 'F'){
            if(direction.Equals("left") && playerPosiBKP[1] > 0){
                playerPosiBKP[1] = playerPosiBKP[1] - 1;
            }
            else if(direction.Equals("right") && playerPosiBKP[1] < maze[0].Length - 1){
                playerPosiBKP[1] = playerPosiBKP[1] + 1;
            }
            else if(direction.Equals("up") && playerPosiBKP[0] > 0){
                playerPosiBKP[0] = playerPosiBKP[0] - 1;
            }
            else if(direction.Equals("down") && playerPosiBKP[0] < maze.Length - 1){
                playerPosiBKP[0] = playerPosiBKP[0] + 1;
            }

            char nextChar = maze[playerPosiBKP[0]][playerPosiBKP[1]];
            if(playerPosiBKP[0]==initialPlayerPosi[0] && playerPosiBKP[1]==initialPlayerPosi[1] && isOtherDirection()){
               playerPosi[0]=initialPlayerPosi[0];
               playerPosi[1]=initialPlayerPosi[1];
               direction = startDirection;
               maze[initialPlayerPosi[0]][initialPlayerPosi[1]]=deadChar();
               Console.WriteLine("Shock!");
               return 1;
               
            }
            else if(nextChar == 'X' || nextChar == 'W'){
                maze[playerPosiBKP[0]][playerPosiBKP[1]]='W';
                if(direction.Equals("right")){
                    maze[playerPosi[0]][playerPosi[1]- 1] = 'C';
                }
                else if(direction.Equals("left")){
                    maze[playerPosi[0]][playerPosi[1] + 1] = 'C';
                }
                else if(direction.Equals("up")){
                    maze[playerPosi[0] + 1][playerPosi[1]] = 'C';
                }
                else if(direction.Equals("down")){
                    maze[playerPosi[0] - 1][playerPosi[1]] = 'C';
                }
                playerPosi[0]=initialPlayerPosi[0];
                playerPosi[1]=initialPlayerPosi[1];
                direction = startDirection;
                maze[initialPlayerPosi[0]][initialPlayerPosi[1]]=deadChar();
                Console.WriteLine("Shock!");
                return 1;
            }
            else if(nextChar == 'G'){
                playerPosi[0]=playerPosiBKP[0];
                playerPosi[1]=playerPosiBKP[1];
                if(direction.Equals("right")){
                    maze[playerPosi[0]][playerPosi[1]- 1] = 'C';
                    maze[playerPosi[0]][playerPosi[1]]= 'R';
                }
                else if(direction.Equals("left")){
                    maze[playerPosi[0]][playerPosi[1] + 1] = 'C';
                    maze[playerPosi[0]][playerPosi[1]]='L';
                }
                else if(direction.Equals("up")){
                    maze[playerPosi[0] + 1][playerPosi[1]] = 'C';
                    maze[playerPosi[0]][playerPosi[1]]= 'U';
                }
                else if(direction.Equals("down")){
                    maze[playerPosi[0] - 1][playerPosi[1]] = 'C';
                    maze[playerPosi[0]][playerPosi[1]]= 'D';
                }
                return 3;
            }
            else if(nextChar != 'W' && nextChar != 'X'){
                playerPosi[0]=playerPosiBKP[0];
                playerPosi[1]=playerPosiBKP[1];
                if(direction.Equals("right")){
                    maze[playerPosi[0]][playerPosi[1]- 1] = 'C';
                    maze[playerPosi[0]][playerPosi[1]]= 'R';
                }
                else if(direction.Equals("left")){
                    maze[playerPosi[0]][playerPosi[1] + 1] = 'C';
                    maze[playerPosi[0]][playerPosi[1]]='L';
                }
                else if(direction.Equals("up")){
                    maze[playerPosi[0] + 1][playerPosi[1]] = 'C';
                    maze[playerPosi[0]][playerPosi[1]]= 'U';
                }
                else if(direction.Equals("down")){
                    maze[playerPosi[0] - 1][playerPosi[1]] = 'C';
                    maze[playerPosi[0]][playerPosi[1]]= 'D';
                }
                return 2;
            }
        }
        return 4;
    }

    public  bool isOtherDirection(){
        if(direction.Equals("up") && startDirection.Equals("down")){
            return true;
        }
        else if(direction.Equals("down") && startDirection.Equals("up")){
            return true;
        }
        else if(direction.Equals("right") && startDirection.Equals("left")){
            return true;
        }
        else if(direction.Equals("left") && startDirection.Equals("right")){
            return true;
        }
        return false;
    }
    public  char deadChar(){
        if(direction.Equals("up")){
            return 'U';
        }
        else if(direction.Equals("down")){
            return 'D';
        }
        else if(direction.Equals("right")){
            return 'R';
        }
        else if(direction.Equals("left")){
            return 'L';
        }
        return 'L';
    }
}