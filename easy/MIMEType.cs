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
        Dictionary<string,string> dictionary = new Dictionary <string,string>();
        int N = int.Parse(Console.ReadLine()); // Number of elements which make up the association table.
        int Q = int.Parse(Console.ReadLine()); // Number Q of file names to be analyzed. //Console.Error.WriteLine("Extension");
        for (int i = 0; i < N; i++) {//List of recognogizable files
            string[] inputs = Console.ReadLine().Split(' ');  //eXT  // Description   //Console.Error.WriteLine("File: "+  inputs[0].ToLowerInvariant() + "  ext; :" +inputs[1]);
            dictionary.Add(inputs[0].ToLowerInvariant(), inputs[1]);// file extension,// MIME type.
        }// Console.Error.WriteLine("\n"); // Console.Error.WriteLine("Files");
        for (int i = 0; i < Q; i++){  //Files to recognogize
            string FNAME = Console.ReadLine(); // One file name per line.  // Console.Error.WriteLine("File: " + FNAME);
            if(FNAME.ToLower().Contains('.')){// Possible extension
                string fileExtension = FNAME.Split('.').Last().ToLower();//Console.Error.WriteLine("ext: " + fileExtension);
                    if (dictionary.TryGetValue(fileExtension, out string mimeType))
                            Console.WriteLine(mimeType);
                    else
                            Console.WriteLine("UNKNOWN"); 
            }
            else
                 Console.WriteLine("UNKNOWN"); 
        }
    }
}
