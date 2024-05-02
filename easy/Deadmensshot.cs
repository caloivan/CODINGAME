using System;
using System.Drawing;//Point
using System.Linq;//.Select

public class Solution{
    public static void Main()  {
        int N = int.Parse(Console.ReadLine());// Polygon corners Number
        Point[] corners = new Point[N]; 

        for (int i = 0; i < N; i++) {  //Generate an array of points describing the Polygon
            int[] cornerXY = Console.ReadLine().Split(' ').Select(n => Convert.ToInt32(n)).ToArray();
            corners[i] = new Point(cornerXY[0], cornerXY[1]);
        }
        int M = int.Parse(Console.ReadLine());//Shots
        for (int i = 0; i < M; i++) {// Ask for each shot if it hit or missed
            int[] shotXY = Console.ReadLine().Split(' ').Select(n => Convert.ToInt32(n)).ToArray();
            Console.WriteLine(PointInPolygon(corners, shotXY[0], shotXY[1])?"hit":"miss");
        }
    }
  
    private static bool PointInPolygon(Point[] polygon, double px, double py) {  //Checks if a point lays inside a polygon or not.  
        bool collision = false;
        for (int current = 0; current < polygon.Length; current++)   {
            Point vc = polygon[current];
            Point vn = polygon[(current + 1) % polygon.Length];// % in case goes to the last. resets
            bool inYRange = (vc.Y > py) != (vn.Y > py); //Check if point.Y is in Y range 
            bool jct = px < vc.X + ((vn.X - vc.X) *(  py - vc.Y)  / //Jordan Curve Theorem. 
                                                   (vn.Y - vc.Y)) ; 
            collision =  inYRange && jct?  !collision:collision;    //Swap collision state.//so we have odd = non colission, pair = collision                              
        }
        return collision;
    }
}
//https://en.wikipedia.org/wiki/Jordan_curve_theorem
//https://learn.microsoft.com/en-us/dotnet/api/system.drawing.point?view=net-8.0
//https://www.youtube.com/watch?v=RSXM9bgqxJM
//https://www.geeksforgeeks.org/how-to-check-if-a-given-point-lies-inside-a-polygon/  number of intersections  on horizontal line
