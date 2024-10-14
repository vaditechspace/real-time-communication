using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.EventGrid;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Azure.Messaging.EventGrid;
using ManageBlobEvents.Utilities;
using System.Threading.Tasks;
using ManageBlobEvents.EventParsers;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
namespace ManageBlobEvents
{
    /// <summary>
    /// The BlobEventsFn class is an Azure Function that handles events from the 
    /// Azure Event Grid related to blob storage. It processes blob events and 
    /// broadcasts them to connected SignalR clients.
    /// </summary>
    /// <remarks>
    /// The Azure Function is responsible for receiving blob events from the Event Grid 
    /// and relaying them to SignalR clients for real-time updates.
    /// </remarks>
    /// <author>Vadi Raju Parande</author>
    public static class BlobEventsFn
    {
        /// <summary>
        /// The entry point for the Azure Function that handles blob storage events.
        /// This method is triggered by events from the Azure Event Grid, processes
        /// the incoming event, and broadcasts the relevant information to SignalR clients.
        /// </summary>
        /// <param name="eventGridEvent">The JSON object representing the blob event received from the Event Grid.</param>
        /// <param name="signalRMessages">An async collector for sending SignalR messages to connected clients.</param>
        /// <param name="log">The logger instance for logging.</param>
        /// <returns>A Task representing the async operation.</returns>
        [FunctionName("SABlobEvents")]
        public static async Task Run([EventGridTrigger] JObject eventGridEvent,
           [SignalR(HubName = "<<YOUR_SIGNALR_NAME>>")] IAsyncCollector<SignalRMessage> signalRMessages,
            ILogger log)
        {
            BlobEventParser blobEventParser = new BlobEventParser();
            BlobEvent blobEvent = blobEventParser.ParseBlobEventJson(eventGridEvent);
            await BroadcastMessage.BroadcastToClients(signalRMessages, blobEvent, log);

        }   
    }
}
    