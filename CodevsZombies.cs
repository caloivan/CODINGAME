using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;


/**
 * Save humans, destroy zombies!
 **/
class Player
{
    public struct Vector2{
            public Vector2(){}
            public Vector2(int _x, int _y){x=_x;y=_y;}
            public int x=0, y=0;
    }

    public enum strategy{
        closestZombieposition,
        closestZombiePrediction,
        closestZombiePredictionP2,
        humanInMostDangerByZombie
    }

    public struct Zombie{
        public Zombie(){
             position = new Vector2(0,0);
        }
        public Zombie(int _x, int _xNext, int _y , int _yNext){  
            x=_x; xNext= _xNext; y=_y; yNext = _yNext;  
            position = new Vector2(_x, _y);
            }
        public int x=0, xNext=0, y=0, yNext=0;
        public Vector2 position;
        public int humanTargetId =0;  // ID of the human to purusue
    }
    

     public struct Human{
        public Human(){}
        public Human(int _x,  int _y  ){
                x=_x;   y=_y;  
         }
        public int x=0, xNext=0, y=0, yNext=0;
        public int ZombieAttackerId =0; 
        bool isSabable = true;
    }


    static void Main(string[] args)  {
        string[] inputs;
        strategy myStrategy = strategy.closestZombiePrediction;
        while (true)
        {
            inputs = Console.ReadLine().Split(' ');
            int x = int.Parse(inputs[0]);
            int y = int.Parse(inputs[1]);
             Console.Error.WriteLine("Ash:x "+ x + " y " + y);
            int humanCount = int.Parse(Console.ReadLine());

            //******************************************Get List of Humans
            List<Human> humans = new List<Human>();
            for (int i = 0; i < humanCount; i++)  {
                inputs = Console.ReadLine().Split(' ');  int humanId = int.Parse(inputs[0]);  int humanX = int.Parse(inputs[1]);  int humanY = int.Parse(inputs[2]);
                humans.Add(new Human(humanX,humanY));
            }

            int closestZombieDistance = 20000, targetX=0, targetY=0;
            int zombieCount = int.Parse(Console.ReadLine());
            int zombieTargetOffset =0;
             Console.Error.WriteLine("Zombies "+ zombieCount  );
           
            //*********************************************Get list of Zombies
            List<Zombie> zombies = new List<Zombie>();
            for (int i = 0; i < zombieCount; i++)  {
                inputs = Console.ReadLine().Split(' ');
                int zombieId = int.Parse(inputs[0]);
                int zombieX = int.Parse(inputs[1]);  int zombieY = int.Parse(inputs[2]);
                int zombieXNext = int.Parse(inputs[3]);  int zombieYNext = int.Parse(inputs[4]);
                zombies.Add(new Zombie(zombieX,zombieXNext,zombieY,zombieYNext));
            }

            //discover what zombie is following what human
            
            
            //evaluate viability on each human,, to save at least one

                //select closest zombie
               for (int i = 0; i < zombieCount; i++)  {
                int distanceToZombie = Distance(x,zombies[i].x,y,zombies[i].y) ;
                Console.Error.WriteLine("Distance: "+ distanceToZombie + " to zombie " + i + "withX " + zombies[i].x + " Y " + zombies[i].y);
                if(distanceToZombie<closestZombieDistance){
                    closestZombieDistance = distanceToZombie;
                    zombieTargetOffset= i;
                    Console.Error.WriteLine("Closest zombie ID: "+ i + " By " + closestZombieDistance );
                }
               }

            
            Console.Error.WriteLine("ZombieTarget "+ zombieTargetOffset  );
            switch(myStrategy)
            {
                    case strategy.closestZombieposition: 
                     Console.WriteLine(zombies[zombieTargetOffset].x + " " + zombies[zombieTargetOffset].y );  
                    break;
                    
                    case strategy.closestZombiePrediction: 
                     Console.WriteLine(zombies[zombieTargetOffset].xNext + " " + zombies[zombieTargetOffset].yNext );  
                    break;
                    case strategy.closestZombiePredictionP2: {

                        int xDelta =zombies[zombieTargetOffset].xNext - zombies[zombieTargetOffset].x;
                        int yDelta =zombies[zombieTargetOffset].yNext - zombies[zombieTargetOffset].y;

                         //Console.WriteLine(zombies[zombieTargetOffset].x + 2*xDelta + " " + zombies[zombieTargetOffset].y +2*xDelta);  
                    } break;
                    
                   
                     default: break;
            }
            //Console.WriteLine("8000 4500"); // Your destination coordinates

        }//while(true)
            int Distance(int x, int y, int zX, int zY){  return (int)Math.Sqrt( (Math.Pow((x-zX),2)  +  Math.Pow((y-zY),2) ));  }
    }//main

   
}
