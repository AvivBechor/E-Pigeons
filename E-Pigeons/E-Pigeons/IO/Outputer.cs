using System;
using System.IO;
using System.Text;

namespace E_Pigeons
{
    public class Outputer
    {
        public static void Print(string s)
        {
            Console.WriteLine(s);
        }
        
        public static void WriteToFile(string path, byte[] bytes)
        {
            bool fileExist = File.Exists(path);
            if (!fileExist)
            {

                using (File.Create(path));
            }
            
            File.WriteAllBytes(path, bytes);
        }
    }
}