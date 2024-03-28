using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * The while loop represents the game.
 * Each iteration represents a turn of the game
 * where you are given inputs (the heights of the mountains)
 * and where you have to print an output (the index of the mountain to fire on)
 * The inputs you are given are automatically updated according to your last actions.
 **/
class Player
{
    static void Main(string[] args)
    {
        int[,] mountains = {{0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0}};
        // game loop
        while (true)
        {
            int highest = 0;
            int offset =0;
            for (int i = 0; i < 8; i++)//Save values of the mountain heights and offsets
            {
                int mountainH = int.Parse(Console.ReadLine()); // represents the height of one mountain.
                if(mountainH > highest) 
                { 
                    highest = mountainH;
                    offset =i;
                }
            }
            // To debug: Console.Error.WriteLine("Debug messages...");
            Console.WriteLine(offset); // The index of the mountain to fire on.
        }
    }
}
