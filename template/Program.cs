using System;
using System.Collections.Generic;

class Program
{
    public static void Main()
    {
        Read();
    }

    static List<string> lines = new List<string>();

    public static void Read()
    {
        try
        {
            StreamReader reader = new StreamReader("../../../in.txt");
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                line = line.Trim();
                lines.Add(line);
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

}