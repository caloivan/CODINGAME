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
class Solution
{
    static void Main(string[] args)
    {
        int amountOfRobers = int.Parse(Console.ReadLine());// amount of robers
        int amountOfVaults = int.Parse(Console.ReadLine());// amount of Vaults
        int[] roberTime = new int[amountOfRobers];  //List of times for each robber.

        for (int i = 0; i < amountOfVaults; i++) //Solving each vault
        {
            string[] inputs = Console.ReadLine().Split(' ');
            int vaultsConvination = int.Parse(inputs[0]);// Combination of the Vault
            int CombinationfirstProtionContainDigits = int.Parse(inputs[1]); // first portion of the combination, containing digits //[0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
            int CombinationSecondProtionContainCharacters = vaultsConvination - CombinationfirstProtionContainDigits; //['A', 'E', 'I', 'O', 'U']
           
            //Add vault time to the robber that has "nothing to do".
            roberTime[0] += (int)(
                Math.Pow(10, CombinationfirstProtionContainDigits) *    //first  portion of the combination, containing digits
                Math.Pow(5, CombinationSecondProtionContainCharacters));    //second portion of  remaining characters
            
            Array.Sort(roberTime);
        }

        Console.WriteLine(roberTime[amountOfRobers - 1]);/// Slowest  Robber will Finish at the end
    }
}
