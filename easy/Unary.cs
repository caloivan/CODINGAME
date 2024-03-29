using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

 //Encode string of chars into a string of Booleans,  1.- Convert string into a trail of Binaries  2.- Encode Binaries repeating 4 steps until end of string a) return Symbol:if 1 -> "0":    if 0 -> "00" b) insert  " " c) return a trail of 0's representing  the number of same Symbols, before changing. d) insert  " "
class Solution
{
    enum machine{  detectSymbol,  countFrecuency  }
    static void Main(string[] args){
        string MESSAGE = Console.ReadLine();  //Message to convert
        string body = ""; // Message converted in Binary trail
        string output = ""; // Final codification of the body
        foreach (char c in MESSAGE.ToCharArray()){  /*************Convert  Message into Binary trail*/
            body += Convert.ToString(c, 2).PadLeft(7, '0');
        } // Console.Error.WriteLine("MESSAGE: "+MESSAGE+",binary: "+ body );
        string actualSymbol =  body[0]== '1'? "0" : "1"; //  for the first element,  actualSymbol negates first  char
        machine machineState = machine.detectSymbol; // to Know what is proccessing, Symbol or frecuency
        for (int i = 0;i<body.Length;i++) {      // Console.Error.WriteLine("\nStep: " + i + " "   );
    //--------------------------COUNT FRECUENCY---------------------------
                if(machineState == machine.countFrecuency){  
                    if(actualSymbol == body[i]+"") {   //add frecuency symbol
                         output +=  "0"; //add frecuency element
                    }else {          //Changed Symbol, report frecuency
                        actualSymbol = body[i]+"";
                        output += " ";//+ "-";//  Stores Symbol and frecuency  // Console.Error.WriteLine("S: "+  (body[i] == '0'?'1':'0') + "-0"+ frecuency );
                        machineState = machine.detectSymbol;  // Detect New Symbol
                    }
                }
    //--------------------------DETECT SYMBOL--------------------------- //Detect Symbol even on the last element
                if(machineState == machine.detectSymbol){/// Detect New Symbol
                    actualSymbol = body[i]+"";  // Saves Symbol Value
                    output +=  body[i]  == '1'  ? "0 0" : "00 0"; // Symbol Representation 
                    machineState = machine.countFrecuency;// symbol dectected, now go to frecuency
                    if(i==body.Length-1){ Console.Error.WriteLine("Last one symbol !!!!!!");}
                }
        }
        Console.WriteLine(output);
    }
}
    
//REF
//https://www.fluxbytes.com/csharp/convert-string-to-binary-and-binary-to-string-in-c/
//https://www.geeksforgeeks.org/program-print-ascii-value-character/


