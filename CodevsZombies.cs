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
    static strategy myStrategy = strategy.closestHumanRescuable; 

    public enum strategy{ closestZombieposition,  closestZombiePrediction,  closestZombiePredictionP2,  closestHumanRescuable  }
    const int  MaxDistance = 20000;
    static int minDistance = MaxDistance;
    const int ashSpeed = 1000;
    const int zombieSpeed = 400;

    public struct Zombie{
        public Zombie(){
        }
        public Zombie(int _x, int _xNext, int _y , int _yNext){  
            x=_x; xNext= _xNext; y=_y; yNext = _yNext;  
            }
        public int x=0, xNext=0, y=0, yNext=0;
        public int humanID =0;  // ID of the human to purusue
        public int distance =0;  // ID of the human to purusue
        public void sethumanID(int _t){ humanID =_t;}
    }//Zombie

     public struct Human{
        public Human(){}
        public Human(int _x,  int _y  ){   x=_x;   y=_y;     }
        public int x=0,   y=0;
        public int zombieID =0;    public void setzombieID(int _t){ zombieID =_t;}
        public int distance =0;    public void setdistance(int _t){ distance =_t;}
        public bool isRescuable = false;    public void setRescuable(bool _t){ isRescuable  =_t;}
        bool isSabable = true;
    }//human

    static void Main(string[] args)  {
        string[] inputs;
      
        minDistance = MaxDistance;
        while (true)  {
            inputs = Console.ReadLine().Split(' ');
            int x = int.Parse(inputs[0]);
            int y = int.Parse(inputs[1]);
             Console.Error.WriteLine("Ash:x "+ x + " y " + y);
            int humanCount = int.Parse(Console.ReadLine());

            //******************************************Get List of Humans
            List<Human> humans = new List<Human>();
            for (int h = 0; h < humanCount; h++)  {
                inputs = Console.ReadLine().Split(' ');  int humanId = int.Parse(inputs[0]);  int humanX = int.Parse(inputs[1]);  int humanY = int.Parse(inputs[2]);
                humans.Add(new Human(humanX,humanY));
            }//for

            //*********************************************Get list of Zombies
            int zombieCount = int.Parse(Console.ReadLine());
              // Console.Error.WriteLine("Zombies "+ zombieCount  );
            int zombieTargetOffset =0;
            List<Zombie> zombies = new List<Zombie>();
            for (int z = 0; z < zombieCount; z++)  {
                inputs = Console.ReadLine().Split(' ');
                int zombieId = int.Parse(inputs[0]);
                int zombieX = int.Parse(inputs[1]);  int zombieY = int.Parse(inputs[2]);
                int zombieXNext = int.Parse(inputs[3]);  int zombieYNext = int.Parse(inputs[4]);
                zombies.Add(new Zombie(zombieX,zombieXNext,zombieY,zombieYNext));
            }//for

            //**************************************************select closest zombie -> mindistance to ash
            minDistance = MaxDistance;
            for (int i = 0; i < zombieCount; i++)  {
                int distanceToZombie = Distance(x,y,zombies[i].x,zombies[i].y) ;
                //Console.Error.WriteLine("Distance: "+ distanceToZombie + " to zombie " + i + "withX " + zombies[i].x + " Y " + zombies[i].y);
                if(distanceToZombie<minDistance){
                        minDistance = distanceToZombie;
                        zombieTargetOffset= i;
                        //Console.Error.WriteLine("Closest zombie ID: "+ i + " By " + minDistance );
                }
            }//for

           // Console.Error.WriteLine("ZombieTarget "+ zombieTargetOffset  );
            switch(myStrategy)  {
                    case strategy.closestZombieposition: {
                     Console.WriteLine(zombies[zombieTargetOffset].x + " " + zombies[zombieTargetOffset].y ); 
                     }break;
                    
                    case strategy.closestZombiePrediction: {
                     Console.WriteLine(zombies[zombieTargetOffset].xNext + " " + zombies[zombieTargetOffset].yNext );  
                    }break;
                    case strategy.closestZombiePredictionP2: {
                        int xDelta =zombies[zombieTargetOffset].xNext - zombies[zombieTargetOffset].x;
                        int yDelta =zombies[zombieTargetOffset].yNext - zombies[zombieTargetOffset].y;
                         //Console.WriteLine(zombies[zombieTargetOffset].x + 2*xDelta + " " + zombies[zombieTargetOffset].y +2*xDelta);  
                    } break;

                    case strategy.closestHumanRescuable:  { //discover, for each human, what zombie is closest, at what distance, and if human is rescuable, based on distances ash-human vs ash-zombie
                        for (int z = 0; z < zombieCount; z++)  {  //for each zombie
                            minDistance = MaxDistance;
                            for (int h = 0; h < humanCount; h++)  {   // what human is closest
                               // Console.Error.WriteLine("human" + h);
                                // Console.Error.WriteLine("hX: " + humans[h].x+ " hY: " + humans[h].y+ "   "+ " zX: " + zombies[z].x+ " zY: " + zombies[z].y);
                                int distHumanZombie = Distance(  humans[h].x,humans[h].y, zombies[z].x, zombies[z].y );
                                //Console.Error.WriteLine("Distance to human: "+distHumanZombie + " ,minDist " + minDist);
                                if(distHumanZombie < Player.minDistance){
                                    //Console.Error.WriteLine("Human: "+ h);
                                    minDistance = distHumanZombie;
                                        humans[h].setzombieID(z);
                                        humans[h].setdistance(minDistance);
                                        int distAshHuman = Distance (x,y,humans[h].x, humans[h].y );
                                       /*  Console.Error.WriteLine("is : "+  "distAshHuman: "+ distAshHuman +  " / "+"ashSpeed: "+ ashSpeed +  " < " +   " distHumanZombie: " + distHumanZombie + " / "+ "zombieSpeed: " + zombieSpeed+ "=" +distAshHuman/ashSpeed + " < " + distHumanZombie/zombieSpeed );*/
                                        bool resucable = distAshHuman   / ashSpeed < distHumanZombie / zombieSpeed;
                                        humans[h].setRescuable(resucable);// if ash can get to human before closest zombie
                                } // new min distance
                            } //for human   
                        }//for zombie

                        // ASH  finds hat closest human is rescueable  
                         minDistance = MaxDistance;
                        int humanTargetID = 0;
                        for (int h = 0; h < humanCount; h++)  {
                            if(humans[h].isRescuable){
                                int distAshHuman  = Distance(x,y,  humans[h].x, humans[h].y);
                                    //Console.Error.WriteLine("Distance: "+ distAshHuman + " to human " + h + "withX " + humans[h].x + " Y " + humans[h].y);
                                if(distAshHuman < minDistance){
                                    minDistance = distAshHuman ;
                                    humanTargetID = h;
                                }//new min
                            }//if  rescuable
                        }//for human
                        Console.WriteLine(humans[humanTargetID].x + " " + humans[humanTargetID].y );  
                         //Console.WriteLine(  "4000 4500 "  );  
                    } break;
                     default: break;
            }//switch
            //Console.WriteLine("8000 4500"); // Your destination coordinates

        }//while(true)
            int Distance(int x, int y, int zX, int zY){  return (int)Math.Sqrt( (Math.Pow((x-zX),2)  +  Math.Pow((y-zY),2) ));  }
    }//main
}
