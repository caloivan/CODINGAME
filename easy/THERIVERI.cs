using System;

public class Solution
{
    public static void Main()
    {
        long r1 = long.Parse(Console.ReadLine());//River 1
        long r2 = long.Parse(Console.ReadLine());//river 2
        while (r1 != r2)  {  //Find meeting point. // until created number is the same
            if   (r1 < r2)  r1 = GetNextRiverNumber(r1);
            else            r2 = GetNextRiverNumber(r2);
        }
        Console.WriteLine(r1); //Output meeting point.
    }
    //Calculates the a following river number (e.g 7 -> 14, 14 -> 19, etc).
    private static long GetNextRiverNumber(long riverNumber)  {
        long nextRiverNumber = riverNumber;
        while (riverNumber > 0)  {
            nextRiverNumber += riverNumber % 10; // Module obtains riverNumber extreme right digit 
            riverNumber -= riverNumber % 10; // remove  last digit from river number
            riverNumber /= 10; //now divide it  to have next extreme right digit 
        }
        return nextRiverNumber;
    }
}
