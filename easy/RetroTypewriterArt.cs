using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

class Solution
{
    static void Main(string[] args)
    {
        string T = Console.ReadLine();
        //Console.Error.WriteLine("Line : " + T);
        string[] tokens = T.Split(' ');//separate  the string in tokens
        string answer ="";
    foreach( string token in  tokens){
        // Console.Error.WriteLine("*****************************************\n"+ answer +"\n");
          //Console.Error.WriteLine("Token : " + token );
/*****************************  new line   ***********************************************/           
            if(token == "nl") 
                    answer += "\n";//Console.Error.WriteLine("Found a New line : ");
/****************************    all numbers  **********************************************/      
            else if(IsStringNumbers(token)){
                string sCount = token.Substring(0,token.Length-1);
                int iCount = Int32.Parse(sCount);
                    //Console.Error.WriteLine("Number Repeated " + token[token.Length-1] +  " " + iCount + " times");
                for (int i = 0; i<iCount;i++)
                    answer += token[token.Length-1];
            } else {
                //Console.Error.WriteLine("Token Lenght " +token.Length);
                if(token.Length>=3){ 
                    string avr =   token.Substring(token.Length-2);
 
 /*****************************  Abreviation   ************************************************/  
                    if(IsStringAbbreviation(avr)){ //detect abreviation
                        string sCount = token.Substring(0,token.Length-2);
                        int iCount = Int16.Parse(sCount); //find frecuency of the abreviation
                       //  Console.Error.WriteLine("count : " +iCount);
                       //  Console.Error.WriteLine("Found Abbreviation " +avr);
                        char myChar = UnwrapAbbrevieation(avr); //unwrap abreviation
                        for(int i= 0;i<iCount;i++){
                            answer += myChar;// print abreviation
                             //Console.Error.WriteLine("Repeated : " +myChar);
                        }
  /*****************************  char repeated ************************************************/                           
                    } else {//   more than 10 times
                            string sCount = token.Substring(0,token.Length-1);
                            int iCount = Int32.Parse(sCount);
                                //Console.Error.WriteLine("String Repeated " + token[token.Length-1] +  " " + iCount + " times");
                            for (int i = 0; i<iCount;i++){
                                answer += token[token.Length-1];
                            }
                    }
                    
                }else { // less than 10 times
                        char  ch = token[token.Length-1];
                        string sCount = token.Substring(0,token.Length-1);
                        int iCount = Int16.Parse(sCount); //find frecuency of the abreviation
                          for(int i= 0;i<iCount;i++){
                            if(ch =='~') Console.Error.WriteLine(" ~ ");
                            answer += ch;// print abreviation
                            // Console.Error.WriteLine("character : " +ch);
                          }
                        }  
            }
        }//foreach( string token in  tokens)
        Console.WriteLine(answer);

        bool IsStringNumbers(string T)  {
                foreach(char c in T)
                if(!Char.IsNumber(c))  
                    return false;
                return true;
            }
        bool IsStringAbbreviation(string T){
            return   T == "sp"? true:T == "bS"? true:T == "sQ"? true:false;
            }
        char UnwrapAbbrevieation(string T){
            return   T == "sp"? ' ':     T == "bS"? '\\':  T == "sQ" ? '\'':' ';
            }   
    }
}

//reference split tokens space https://stackoverflow.com/questions/2599711/how-do-i-extract-a-substring-from-a-string-until-the-second-space-is-encountered
//closest reference in c++ https://github.com/MericLuc/CodinGame/blob/main/Easy/retro-typewriter-art.cpp
