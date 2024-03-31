using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

class Solution
{
    static void Main(string[] args)
    {
        int X = int.Parse(Console.ReadLine());
        int N = int.Parse(Console.ReadLine());
          int[] M = Console.ReadLine().Split().Select(int.Parse).OrderByDescending(s => s).ToArray();
        double W = 0;
       //Calculate minimum work.
        for (int i = 0; i < N; i++)
            W += i / X * .65 * M[i];
        Console.WriteLine(Math.Round(W, 3).ToString("0.000"));
    }
}
