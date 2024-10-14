/// <summary>
/// The NegotiateFn Azure Function that handles SignalR connection negotiation requests from clients. 
/// This function allows clients to establish a connection to the SignalR hub for real-time communication.
/// </summary>
/// <remarks>
/// This class contains a single function, Run (negotiate), which is triggered via an HTTP Post. 
/// It returns the connection information needed for clients to connect to the specified SignalR hub
/// </remarks>
/// <author>Vadi Raju Parande</author>

using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Microsoft.Extensions.Logging;

namespace SignalRCon
{
    public class NegotiateFn
    {
        /// <summary>
        /// The entry point for the Azure Function that negotiates SignalR connections for clients.
        /// </summary>
        /// <param name="req">The HTTP request containing the negotiation request from the client.</param>
        /// <param name="connectionInfo">The connection information for the SignalR hub.</param>
        /// <param name="log">The logger instance for logging negotiation requests and events.</param>
        /// <returns>The connection information needed for clients to connect to the SignalR hub.</returns>
        [FunctionName("negotiate")]
        public SignalRConnectionInfo Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequest req,
            [SignalRConnectionInfo(HubName = "<<YOUR_SIGNALR_NAME>>")] SignalRConnectionInfo connectionInfo,
            ILogger log)
        {
            log.LogInformation("Negotiation requested.");
            return connectionInfo;
        }
    }
}
