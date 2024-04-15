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
class Player
{
    static void Main(string[] args)
    {
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        int nbFloors = int.Parse(inputs[0]); // number of floors
        int width = int.Parse(inputs[1]); // width of the area
        int nbRounds = int.Parse(inputs[2]); // maximum number of rounds
        int exitFloor = int.Parse(inputs[3]); // floor on which the exit is found
        int exitPos = int.Parse(inputs[4]); // position of the exit on its floor
        int nbTotalClones = int.Parse(inputs[5]); // number of generated clones
        int nbAdditionalElevators = int.Parse(inputs[6]); // ignore (always zero)
        int nbElevators = int.Parse(inputs[7]); // number of elevators
        //Console.Error.WriteLine(" Floors "+nbFloors + "\n"+ " width "+ width +  "\n"+ " exitFloor "+ exitFloor +  "\n"+" exitPos "+ exitPos +  "\n"+ " nbTotalClones "+ nbTotalClones +  "\n"+ " nbAdditionalElevators "+ nbAdditionalElevators +  "\n"+" nbElevators "+ nbElevators);
       
        int[] portal = new int[nbElevators+1];
        for (int i = 0; i < nbElevators; i++)  {
            inputs = Console.ReadLine().Split(' ');
            int elevatorFloor = int.Parse(inputs[0]); // floor on which this elevator is found
            int elevatorPos = int.Parse(inputs[1]); // position of the elevator on its floor
            portal[elevatorFloor] = elevatorPos;  //Console.Error.WriteLine(" Floor: " +elevatorFloor + " has portal in position " + elevatorPos);
        }
           portal[exitFloor] = exitPos;// Console.Error.WriteLine(" Floor: " +exitFloor + " has portal in position " + exitPos);
        // game loop
        while (true)
        {
            inputs = Console.ReadLine().Split(' ');
            
            int cloneFloor = int.Parse(inputs[0]); // floor of the leading clone
            int clonePos = int.Parse(inputs[1]); // position of the leading clone on its floor
            string direction = inputs[2]; // direction of the leading clone: LEFT or RIGHT
            Console.Error.WriteLine("cloneFloor"+ cloneFloor + "  clonePos " +clonePos + "  direction "+direction);
           
           string solution = "WAIT";
           if(clonePos>width-2||clonePos==0
             ||(cloneFloor!=-1)&&(portal[cloneFloor]>clonePos&& direction=="LEFT")
              ||(cloneFloor!=-1)&&(portal[cloneFloor]<clonePos&& direction=="RIGHT")
             ) solution = "BLOCK";
           
            Console.WriteLine( solution); // action: WAIT or BLOCK
        }
    }
}
