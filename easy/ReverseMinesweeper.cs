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
    static void Main(string[] args) {
        int[,] grid = new int[30,30];
        int w = int.Parse(Console.ReadLine());  //x
        int h = int.Parse(Console.ReadLine());  //y
/************************** Populate grid  ******************************************/
        string line = "";
        //Console.Error.WriteLine("Input" + " W: " + w+ " H: " + h);
        for (int y = 0; y < h; y++)  {         // 
               line = Console.ReadLine(); 
               //Console.Error.WriteLine(line);
              for (int x = 0; x < w; x++)     //  x  === w
                    grid[x,y] = line[x]== '.'?0:-1;
        }
        /*
Console.Error.WriteLine("\n Translation into integers");
         for (int y = 0; y < h; y++)  {        
                line = "";
                for (int x = 0; x < w; x++)  
                    line+=grid[x,y];
                Console.Error.WriteLine(line);
        }
*/
/************************** Traverse grid Mark bomb surounds **********************************/
       Console.Error.WriteLine("\nBombs Detected ");
        for (int y = 0; y < h; y++)  {   /// y  
            for (int x = 0; x < w; x++){  // x
                if(grid[x,y] == -1){
                    int a,b; 
                  //  DetectBomb(i-1,j-1,w,h,ref grid);
                    a =x-1;b= y-1; if( a>=0 && a<w && b>=0 && b<h && grid[a,b]!=-1 ){grid[a,b]=grid[a,b]+1;}//up left
                    a =x  ;b= y-1; if( a>=0 && a<w && b>=0 && b<h && grid[a,b]!=-1 ){grid[a,b]=grid[a,b]+1;}// up
                    a =x+1;b= y-1; if( a>=0 && a<w && b>=0 && b<h && grid[a,b]!=-1 ){grid[a,b]=grid[a,b]+1;}// up right
                    a =x+1;b= y  ; if( a>=0 && a<w && b>=0 && b<h && grid[a,b]!=-1 ){grid[a,b]=grid[a,b]+1;} //right
                    a =x+1;b= y+1; if( a>=0 && a<w && b>=0 && b<h && grid[a,b]!=-1 ){grid[a,b]=grid[a,b]+1;}//down right
                    a =x  ;b= y+1; if( a>=0 && a<w && b>=0 && b<h && grid[a,b]!=-1 ){grid[a,b]=grid[a,b]+1;}//down
                    a =x-1;b= y+1; if( a>=0 && a<w && b>=0 && b<h && grid[a,b]!=-1 ){grid[a,b]=grid[a,b]+1;}//down left
                    a =x-1;b= y  ; if( a>=0 && a<w && b>=0 && b<h && grid[a,b]!=-1 ){grid[a,b]=grid[a,b]+1;}//left 
                }
            }
         }
         string line1= "";
 /************************** PRINT grid Mark bomb surounds **********************************/       
   /*      
        for (int y = 0; y < h; y++)  {     
            for (int x = 0; x < w; x++){
                   line1 += grid[x,y]+"";
            }
            Console.Error.WriteLine(line1);
            line1= "";
        }
*/
/************************* Erase bombs *********************************/
        for (int y = 0; y < h; y++)  {     
            for (int x = 0; x < w; x++){
               if(grid[x,y]==-1) grid[x,y] = 0;
            }
        }
/************************** Print output ******************************************/
        
        Console.Error.WriteLine("\nSolution ");
         
        for (int i = 0; i < h; i++)  {   
              line1= "";  
            for (int j = 0; j < w; j++){
                   line1 += 
                   grid[j,i]==-1?'.':
                   grid[j,i]== 0?'.':
                   grid[j,i]+""  ;
            }
            Console.WriteLine(line1);
            line1= "";
        }
    }
}
