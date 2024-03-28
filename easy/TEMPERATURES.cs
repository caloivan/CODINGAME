using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution{
    static void Main(string[] args)  {
        int n = int.Parse(Console.ReadLine()); // the number of temperatures to analyse
        string[] inputs = Console.ReadLine().Split(' ');
        int delta = 6000;
        string values = "";
        for (int i = 0; i < n; i++) {
            values += " " +int.Parse(inputs[i]);
        }
        Console.Error.WriteLine(values);
        if(n>0){
            for (int i = 0; i < n; i++)
            {
                int t = int.Parse(inputs[i]);// a temperature expressed as an integer ranging from -273 to 5526
                if (Math.Abs(t) == Math.Abs(delta)) delta = t>delta?t:delta;
                if (Math.Abs(t)< Math.Abs(delta) ) delta = t;
            }
        }
        else{
            delta =0;
        }
        Console.WriteLine(delta);
    }
}
