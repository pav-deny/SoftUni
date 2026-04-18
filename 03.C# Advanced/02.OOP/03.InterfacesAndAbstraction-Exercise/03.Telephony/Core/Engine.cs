using System;
using Telephony.Core.Interfaces;
using Telephony.IO.Interfaces;
using Telephony.Models;
using Telephony.Models.Interfaces;

namespace Telephony.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string[] phoneNumbers = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] urls = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            ICallable callable = null;

            foreach (string phoneNumber in phoneNumbers)
            {
                try
                {
                    callable = phoneNumber.Length == 10
                        ? new Smartphone()
                        : new StationaryPhone();

                    writer.WriteLine(callable.Call(phoneNumber));
                }
                catch (ArgumentException e)
                {
                    writer.WriteLine(e.Message);
                }
            }

            foreach (string url in urls)
            {
                try
                {
                    IBrowsable smartphone = new Smartphone();
                    writer.WriteLine(smartphone.Browse(url));
                }
                catch (ArgumentException e)
                {
                    writer.WriteLine(e.Message);
                }
            }
        }
    }
}
