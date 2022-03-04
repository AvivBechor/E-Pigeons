using System;

namespace E_Pigeons
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string testSync = "0101";
            TextMessage msg = new TextMessage(testSync, 1002, 1001, "Hi David, this is Ariel");
            byte[] byteArr = msg.Generate();
            Console.Write("[");
            for (int i = 0; i < byteArr.Length; i++)
            {
                Console.Write(byteArr[i].ToString());
                if (i != byteArr.Length - 1)
                {
                    Console.Write(", ");

                }
            }
            Console.Write("]");

        }
    }
}