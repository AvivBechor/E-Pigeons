namespace E_Pigeons
{
    public class MessageCreator
    {
        public BasicMessage CreateMessage(string type, ushort srcId)
        {
            BasicMessage msg = null;
            if (type.Equals("text"))
            {
                
                ushort dstId = Inputer.UshortInputLoop("Who do you want to send the message to?");
                Outputer.Print("What is your message");
                string txt = Inputer.Input();

                msg = new TextMessage("", srcId, dstId, txt);
            }

            return msg;
        }
    }
}