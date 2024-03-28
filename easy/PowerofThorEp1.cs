using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 * ---
 * Hint: You can use the debug stream to print initialTX and initialTY, if Thor seems not follow your orders.
 **/
 
class Player
{
     struct Thor{
         public int x ;
        public int y;
        public Thor(int x1,int y1){  x=x1; y=y1;    }
    }   

    static void Main(string[] args)
    {
        string[] inputs = Console.ReadLine().Split(' ');
        int lightX = int.Parse(inputs[0]); // the X position of the light of power
        int lightY = int.Parse(inputs[1]); // the Y position of the light of power
        int initialTx = int.Parse(inputs[2]); // Thor's starting X position
        int initialTy = int.Parse(inputs[3]); // Thor's starting Y position
        Thor thor = new Thor(initialTx,initialTy);
        string vert = "";
        string hor = "";

        // game loop
        while (true)
        {
            int remainingTurns = int.Parse(Console.ReadLine()); // The remaining amount of turns Thor can move. Do not remove this line.
            
            Console.Error.WriteLine("ThorY"+  thor.y + " LightY " + lightY);
            hor = thor.x < lightX?"E": thor.x > lightX? "W": "";
            vert = thor.y < lightY?"S": thor.y > lightY? "N": "";

            thor.x = thor.x < lightX?thor.x+1: thor.x > lightX?thor.x-1: thor.x;
            thor.y = thor.y < lightY?thor.y+1: thor.y > lightY?thor.y-1: thor.y;
            // Write an action using Console.WriteLine()
            Console.WriteLine(vert + hor+"");
        }
    }
}
