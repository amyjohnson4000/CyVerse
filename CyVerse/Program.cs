// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NATS.Client;

public class Program
{
    //Code source:
    //https://nats.io/blog/nats-in-dotnet/

    static void Main()
    {
        Console.WriteLine("CyVerse Programming Challenge");
        int count = 0;

        try
        {
            //Publishes the message
            using (IEncodedConnection c = new ConnectionFactory().CreateEncodedConnection())
            {
                c.Publish("foo", new Company());
            }

            // simply tallies the message, and adds a delegate to print the message
            // starting after the 3rd message received, and stopping after the 5th.
            // In practice this could be used to enable/disable debugging or layer 
            // processing based on application state.
            void processMessage(object sender, MsgHandlerEventArgs e)
            {
                count++;

                IAsyncSubscription sub = (IAsyncSubscription)e.Message.ArrivalSubcription;
                if (count == 3)
                {
                    sub.MessageHandler += printMessage;
                }
                else if (count == 5)
                {
                    sub.MessageHandler -= printMessage;
                }
            }

            void demonstrateRuntimeDelegates()
            {
                using (IConnection c = new ConnectionFactory().CreateConnection())
                {
                    using (IAsyncSubscription s = c.SubscribeAsync("foo", processMessage))
                    {
                        // Process for 5 seconds.
                        Thread.Sleep(5000);
                    }
                }
            }

            // prints the message to the console.
            void printMessage(object sender, MsgHandlerEventArgs e)
            {
                System.Console.WriteLine(e.Message);
            }

            //Subscribe to the message
            //Looks like another way to do this
            //using (IEncodedConnection c = new ConnectionFactory().CreateEncodedConnection())
            //{
            //    // Create an event handler to process a Company object.
            //    EventHandler<EncodedMessageEventArgs> eh = (sender, args) =>
            //    {
            //        Company company = (Company)args.ReceivedObject;
            //        System.Console.WriteLine("Name: {0}, Address: {1}",
            //            company.Name, company.Address);
            //    };

            //    // Subscribe, registering the handler, and then process incoming 
            //    // messages for 5 seconds.
            //    using (IAsyncSubscription s = c.SubscribeAsync("foo", eh))
            //    {
            //        System.Console.WriteLine("Waiting for a message..");
            //        Thread.Sleep(5000);
            //    }
            //}
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }



    [Serializable]
    public class Company
    {
        public string Name = "Widgets";
        public string Address = "123 Some St., City, State 12345";
    }
}

