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
     public static void Main()
    {
        int width = int.Parse(Console.ReadLine());// LENGHT OF ASCII
        int height = int.Parse(Console.ReadLine());//HEIGHT OF ASCII
        string message = Console.ReadLine().ToUpper();/// Text to represent 
        
        for (int i = 0; i < height; i++)   {//Get ASCII row and Col representation for message
            string asciiLine = Console.ReadLine();
            for (int j = 0; j < message.Length; j++)  {//Get ASCII row representation for message
                int charIndex = message[j] - 'A'; //Get ASCII index of current char.
                int letterIndex = char.IsLetter(message[j]) ? charIndex : 'Z' - 'A' + 1;
                string asciiPart = asciiLine.Substring(letterIndex * width, width); //Get ASCII row representation of leter
                Console.Write(asciiPart);
            }
            Console.WriteLine();
        }
    }
}
