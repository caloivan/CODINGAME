using System;

public class Solution
{
    public static void Main(){
        int r1 = int.Parse(Console.ReadLine());
        bool riversMeetR1 = false;
        for (int i = r1 - 1; i > 0 && !riversMeetR1; i--)     //Find rivers that meet r1.
            riversMeetR1 = (GetNextRiverNumber(i) == r1);
        Console.WriteLine(riversMeetR1 ? "YES" : "NO"); //Output if other rivers meet r1.
    }
  
    private static long GetNextRiverNumber(long riverNumber)  {  //Calculates the a following river number (e.g 7 -> 14, 14 -> 19, etc).
        long nextRiverNumber = riverNumber;
        while (riverNumber > 0)  {
            nextRiverNumber += riverNumber % 10;
            riverNumber -= riverNumber % 10;
            riverNumber /= 10;
        }
        return nextRiverNumber;
    }
}
