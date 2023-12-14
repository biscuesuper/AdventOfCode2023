using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security;

class Program
{
    public static void Main()
    {
        Read();
        var sum = 0;
        for(int i = 1; i<= lines.Count(); i++)
        {
            Console.WriteLine(lines[i-1]);
            sum += PowerOf(i);
        }
        Console.WriteLine(sum);
    }

    static int PowerOf(int i)
    {
        var colours = new Dictionary<string, int>()
        {
            { "red", 0},
            { "green", 0},
            { "blue", 0}
        };
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
                    var numStr = group.Substring(0, x);
                    var num = int.Parse(numStr);
                    colours["red"] = Math.Max(colours["red"], num);
                }

                if (group.Contains("green"))
                {
                    var x = group.IndexOf('g');
                    var numStr = group.Substring(0, x);
                    var num = int.Parse(numStr);
                    colours["green"] = Math.Max(colours["green"], num);
                }

                if (group.Contains("blue"))
                {
                    var x = group.IndexOf('b');
                    var numStr = group.Substring(0, x);
                    var num = int.Parse(numStr);
                    colours["blue"] = Math.Max(colours["blue"], num);
                }
            }
        }
        Console.WriteLine($"Red: {colours["red"]}, Green: {colours["green"]}, Blue: {colours["blue"]}");
        return colours["red"] * colours["green"] * colours["blue"];
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