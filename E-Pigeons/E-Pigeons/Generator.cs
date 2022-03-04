namespace E_Pigeons
{
    public class Generator
    {
        public byte[] Generate(IGenerate message)
        {
            return message.Generate();
        }
    }
}