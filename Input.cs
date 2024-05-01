using System;

class Input
{
    public static string playerInput(string input)
    { //Transforms the player input to a string with the inputs that we can use
        string movementPlayer="";
        string movementPlayerFiltered ="";
        int letterPosition =0;
        while (letterPosition < input.Length)
        {
            char currentChar = input[letterPosition];
            if (char.IsDigit(currentChar)) 
            {
                int repeat = currentChar - '0';
                letterPosition++; // Move to the next character
                if (letterPosition < input.Length) 
                {
                    char nextChar = input[letterPosition];
                    for (int j = 0; j < repeat; j++) 
                    {
                        movementPlayer +=nextChar;
                    }
                }
            } else 
            {
                movementPlayer+=currentChar;
            }
            letterPosition++;
        }
        for(int i= 0; i< movementPlayer.Length; i++)
        {
            char currentChar = movementPlayer[i];
            switch (currentChar) 
            {
                case 'H':
                case 'L':
                case 'R':
                case 'F':
                case 'Q':
                    movementPlayerFiltered += currentChar;
                    break;
                default:
                    break;
            }
        }
        return movementPlayerFiltered;
    }
    public static bool containsQOrH(string input)
    {
        bool contains = false;
        for(int i = 0; i < input.Length; i++)
        {            
            char currentChar = input[i];
            switch (currentChar)
            {
                case 'Q':
                    UI.printQ();
                    return true;
                case 'H':
                    UI.help();
                    return true;
                default:
                    break;
            }            
        }
        return contains;
    }
    public static bool digitsCheck(string input){
        bool contains = false;
        if(char.IsDigit(input[input.Length-1])){
            return true;
        }
        for(int i = 0; i<input.Length-1;i++){
            if(char.IsDigit(input[i]) && char.IsDigit(input[i+1])){
                contains = true;
            }
        } 
        return contains;
    }

    public static bool invalidChar(string input){
        for(int i= 0; i< input.Length; i++){            
            char currentChar = input[i];
            if(!char.IsDigit(currentChar)){
                switch (currentChar) {
                    case 'H':
                    case 'Q':
                    case 'R':
                    case 'L':
                    case 'F':
                        break;              
                    default:
                        return true;
                }    
            }  
        }
        return false;
    }

    public static bool invalidMoves(string input)
    {
        if(string.IsNullOrWhiteSpace(input) || digitsCheck(input.ToUpper()) || invalidChar(input.ToUpper()))
        {
            if(digitsCheck(input.ToUpper()) || invalidChar(input.ToUpper()))
            {
                UI.printErrors(2);
            }
            else
            {
                UI.printErrors(8);
            }
            return true;
        }
        return false;
    }
}