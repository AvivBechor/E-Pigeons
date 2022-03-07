using System;

namespace E_Pigeons
{
    public class Inputer
    {
        public static string Input()
        {
            string input;
            input = Console.ReadLine();
            return input;

        }
        
        public static bool CheckIfNumber(string s)
        {
            return int.TryParse(s, out int num);
        }

        public static int IntInputLoop(string s)
        {
            int num;
            string input ="";
            
            while (!int.TryParse(input, out num))
            {
                Outputer.Print(s);
                input = Inputer.Input();
            }

            return num;
        }
        public static ushort UshortInputLoop(string s)
        {
            ushort num;
            string input ="";
            
            while (!ushort.TryParse(input, out num))
            {
                Outputer.Print(s);
                input = Inputer.Input();
            }

            return num;
        }

        


    }
}