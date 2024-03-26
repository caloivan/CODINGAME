using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
/* Function: from a list of cards fuses them from low to high to minimize the Service fee*/
class Solution
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        List<int> inputs = Console.ReadLine().Split().Select(inputs => int.Parse(inputs)).ToList();
        int  stepSum;  // The result of lowerest elements in list
        int cost = 0;  //cummulative Service fee 
        
        while (inputs.Count() > 1)
        {
            inputs.Sort(); //Find the smallest pair // after generating a potential biggest.
            stepSum = inputs.ElementAt(0) + inputs.ElementAt(1); //Smallest possible sum.
            // Console.Error.WriteLine("\n A + B: "+ inputs.ElementAt(0) +  " + " + inputs.ElementAt(1));
            inputs.RemoveAt(0); // Remove Elements
            inputs.RemoveAt(0);
            inputs.Add(stepSum); // Insert Result
            cost += stepSum; //Register cost
            // Console.Error.WriteLine("CCost: "+ cost);
        }
        Console.WriteLine(cost);
    }
}
