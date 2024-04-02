using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

class Solution
{
    static void Main(string[] args)  {
        int X = int.Parse(Console.ReadLine());// maximum Bricks per row
        int N = int.Parse(Console.ReadLine());//Nimber of bricks
        float bricksHeight = 0.65f;  // in mts, using x/100, simplify formula
        int[] M = Console.ReadLine().Split().Select(int.Parse).OrderByDescending(s => s).ToArray();// bricks weight
        double W = 0;//amount of work
       //Calculate minimum work.
        for (int i = 0; i < N; i++)// traverse for all the bricks, cosidere their specific weight for 
            W += (i / X) *( M[i] * 0.65) ; // for each level of the wall 
        Console.WriteLine(Math.Round(W, 3).ToString("0.000"));
    }
}

// For later ,, how does the compiler   takes a variable 0.65  against 0.65f, what kind of variable is  assigned to this.
