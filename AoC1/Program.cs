using System;
using System.Collections.Generic;

class Program
{
    public static void Main()
    {
        Read();
        long sum = 0;
        foreach(string line in lines)
        {
            sum += Calibrate2(line);
        }
        Console.WriteLine(sum);
    }

    static Dictionary<int, string> numbers = new Dictionary<int, string>()
    {
        {1, "one" }, {2, "two" }, {3, "three"}, {4, "four" }, {5, "five"}, {6, "six"}, {7, "seven"}, {8, "eight"}, {9, "nine"}
    };

    static List<string> lines = new List<string>();

    public static int Calibrate(string line)
    {
        char empty = '\0';
        char[] arr = line.ToCharArray();
        char first = empty;
        char last = empty;
        foreach(char c in arr) 
        {
            if('0' <= c && c <= '9')
            {
                if (first == empty) first = c;
                last = c;
            }
        }
        if (first == empty && last == empty) throw new Exception("wtf");
        
        int.TryParse(first.ToString(), out int a);
        int.TryParse(last.ToString(), out int b);
        var res = a * 10 + b;
        return res;
    }

    public static int Calibrate2(string line)
    {
        int f = First(line);
        int l = Last(line);
        return f * 10 + l;
    }

    public static int First(string input_string)
    {
        int i = 0;
        for (int j = 0; j <= input_string.Length; j++)
        {
            var substring = input_string.Substring(i, j);
            foreach(var kv in numbers)
            {
                if(substring.Contains(kv.Key.ToString()) || substring.Contains(kv.Value))
                {
                    return kv.Key;
                }
            }
        }
        throw new Exception("wtf");
    }

    public static int Last(string input_string)
    {
        for (int i = input_string.Length; i >= 0; i--)
        {
            int j = input_string.Length - i;
            var substring = input_string.Substring(i, j);
            foreach (var kv in numbers)
            {
                if (substring.Contains(kv.Key.ToString()) || substring.Contains(kv.Value))
                {
                    return kv.Key;
                }
            }
        }
        throw new Exception("wtf");
    }

    public static void Read()
    {
        try
        {
            StreamReader reader = new StreamReader("../../../in.txt");
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                line= line.Trim();
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