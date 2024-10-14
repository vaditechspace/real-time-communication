using Azure.Messaging.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageBlobEvents.Utilities
{
    internal class ManageMessages
    {
        public static async Task SendMessageToServiceBus(string message)
        {
            // Code for sending a message to the Azure Service Bus
            string connectionString = Environment.GetEnvironmentVariable("ServiceBusConStr");
            string queueName = "blob-queue";

            var client = new ServiceBusClient(connectionString);
            var sender = client.CreateSender(queueName);

            var serviceBusMessage = new ServiceBusMessage(message);
            await sender.SendMessageAsync(serviceBusMessage);
        }

    }
}
