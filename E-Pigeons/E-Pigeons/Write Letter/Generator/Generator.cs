using System;

namespace E_Pigeons
{
    public class Generator
    {
        
        public byte[] GenerateMessage(IGenerate message)
        {
            return message.Generate();
        }
        public ushort GenerateSrcId()
        {
            Random rand = new Random();
            return (ushort)rand.Next(1000, 9999);
        }
    }
}