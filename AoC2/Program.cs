using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

class Program
{
    public static void Main()
    {
        Read();
        var sum = 0;
        for(int i = 1; i<= lines.Count(); i++)
        {
            if(IsItPossible(i))
            {
                sum += i;
                Console.WriteLine("ok " + lines[i - 1]);
            }
            else
            {
                Console.WriteLine("NOPE " + lines[i - 1]);
            }
        }
        Console.WriteLine(sum);
    }

    static bool IsItPossible(int i)
    {
        var j = lines[i - 1].IndexOf(':');
        var game = lines[i - 1].Substring(j + 1, lines[i - 1].Length - j - 1);
        //Console.WriteLine(game);
        var sets = game.Split(';');
        foreach (var set in sets)
        {
            //Console.WriteLine(set);
            var groups = set.Split(",");
            foreach (string group in groups)
            {
                //Console.WriteLine(group);

                if (group.Contains("red"))
                {
                    var x = group.IndexOf('r');
                    var num = group.Substring(0, x);
                    var intt = int.Parse(num);
                    if (intt > 12) return false;
                }

                if (group.Contains("green"))
                {
                    var x = group.IndexOf('g');
                    var num = group.Substring(0, x);
                    var intt = int.Parse(num);
                    if (intt > 13) return false;
                }

                if (group.Contains("blue"))
                {
                    var x = group.IndexOf('b');
                    var num = group.Substring(0, x);
                    var intt = int.Parse(num);
                    if (intt > 14) return false;
                }
            }
        }
        return true;
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