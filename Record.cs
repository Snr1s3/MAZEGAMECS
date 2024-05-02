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
            Console.WriteLine(i);
            string[] line = lines[i].Split(",");
            if (lines.Length > 1 && line[0].Equals(mazeName)) // Check that there are at least two fields
            {
                recordInfo[0] = line[0];
                recordInfo[1] = line[1];
                recordInfo[2] = line[2];
                return true;
            }
            
        }
        return false;
    }

    public  void newRecord(bool record, int attempts, string mazeName){
        UI.printAttemptsRecord(attempts);
        Console.WriteLine();
        if(!record || attempts< int.Parse(recordInfo[1]))
        {
            using (StreamWriter writer = new StreamWriter("mazes/mazeDB.csv", true))
            {
                writer.WriteLine(); // Add a new line
                UI.printNewRecord(true);
                string name = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine();
                    UI.printNewRecord(true);
                    name = Console.ReadLine();
                }
                name = name.Trim();
                string newLine = $"{mazeName},{attempts},{name}";
                writer.WriteLine(newLine); // Write the new line
            }
        }
        else
        {
            UI.printNewRecord(false);
        }
    }

    public  string[] getRecord()
    {
        return recordInfo;
    }
}