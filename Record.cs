using System;
using System.IO;
class Record
{
    private  string[] recordInfo = new string[3];

    public bool checkRecord(string mazeName)
    {
        string[] lines = File.ReadAllLines("mazes/mazeDB.csv");
        for(int i =0;i<lines.Length;i++)
        {
            string[] line = lines[i+1].Split(",");
            if(line[0].Equals(mazeName)){
                recordInfo[0] = line[0];
                recordInfo[1] = line[1];
                recordInfo[2] = line[2];
                return true;
            }
        }
        return false;
    }

    public  string[] getRecord(){
        return recordInfo;
    }
}