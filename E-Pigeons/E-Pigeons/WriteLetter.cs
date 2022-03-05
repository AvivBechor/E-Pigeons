using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace E_Pigeons
{
    public class WriteLetter
    {
        private readonly Generator generator;
        private readonly MessageCreator msgCreator;
        private string path;

        public WriteLetter()
        {
            generator = new Generator();
            msgCreator = new MessageCreator();
            path = @"D:\projects\E-Pigeons\MailBox.bin";
        }
        
        public WriteLetter(string _path)
        {
            generator = new Generator();
            msgCreator = new MessageCreator();
            this.path = _path;
        }

        public string GetPath() => path;

        public void SetPath(string _path)
        {
            if (!IsPathValid(_path))
            {
                path = @"D:\projects\E-Pigeons\MailBox.bin";
            }

            this.path = _path;
        }

        private bool IsPathValid(string path)
        {
            bool isPathValid = false;
            try
            { 
                Path.GetFullPath(path);
                isPathValid = true;
            }
            catch
            {
                isPathValid = false;
            }

            return isPathValid;
        }

        private BasicMessage[] InputMessages()
        {
            string txt;
            ushort dstId;
            ushort srcId = generator.GenerateSrcId();
            string input = "";
            int messageAmount;
            int i;
            
            messageAmount = Inputer.IntInputLoop("How many messages do you want to write?");
            BasicMessage[] messages = new BasicMessage[messageAmount];
                
            for (i = 0; i < messageAmount; i++)
            {
                Outputer.Print("What kind of message do you want to send");
                input = Inputer.Input();
                messages[i] = msgCreator.CreateMessage(input, srcId);
                
            }
            
            return messages;
        }

        private void AddArrayToList<T>(List<T> list, T[] arr)
        {
            int i;
            for (i = 0; i < arr.Length; i++)
            {
                list.Add(arr[i]);
            }
        }

        private byte[] GenerateMessages(BasicMessage[] messages)
        {
            byte[] msgBytes;
            
            List<byte> bytes = new List<byte>();

            foreach (BasicMessage msg in messages)
            {
                msgBytes = generator.GenerateMessage(msg);
                AddArrayToList(bytes, msgBytes);
                
            }


            return bytes.ToArray();
        }

        public void WriteLetters()
        {
            string path = GetPath();
            BasicMessage[] msg = InputMessages();
            byte[] msgBytes = GenerateMessages(msg);
            Outputer.WriteToFile(path,msgBytes);
        }

    }
}