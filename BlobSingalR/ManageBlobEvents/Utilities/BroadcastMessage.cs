using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Microsoft.Azure.WebJobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManageBlobEvents.EventParsers;
using Microsoft.Extensions.Logging;

namespace ManageBlobEvents.Utilities
{
    /// <summary>
    /// The BroadcastMessage class provides functionality to broadcast blob events
    /// to all connected SignalR clients.
    /// </summary>
    /// <remarks>
    /// This class is static.
    /// It uses Azure SignalR to push blob event data in real-time to connected clients.
    /// </remarks>
    internal static class BroadcastMessage
    {
        /// <summary>
        /// This method broadcasts a blob event to all connected SignalR clients.
        /// </summary>
        /// <param name="signalRMessages">An collector for sending SignalR messages to clients.</param>
        /// <param name="blobEvent">The event data related to the blob (e.g., blob creation or deletion).</param>
        /// <returns>A Task representing the async operation.</returns>
        public static async Task BroadcastToClients(IAsyncCollector<SignalRMessage> signalRMessages, BlobEvent blobEvent, ILogger log)
        {
            try
            {
                log.LogInformation("Attempting to broadcast blob event to SignalR clients...");

                // Broadcast message to all SignalR clients
                await signalRMessages.AddAsync(
                    new SignalRMessage
                    {
                        // SignalR client method to receive the blob event
                        Target = "blobEvent",
                        // Pass blob event as an argument
                        Arguments = new object[] { blobEvent } 
                    });

                log.LogInformation("Successfully broadcasted blob event to SignalR clients.");
            }
            catch (Exception ex)
            {
                log.LogError(ex, "An error occurred while broadcasting blob event to SignalR clients.");
                // Re-throw the exception 
                throw; 
            }
        }
    }
}
