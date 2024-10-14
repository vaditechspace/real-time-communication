## Introduction

BlobSignalR is a serverless sample that demonstrates how to leverage Azure services to provide real-time updates for blob storage events. This project showcases an advanced architecture using Azure Event Grid, Azure Functions, and SignalR, along with a client-side HTML interface for displaying events in real-time. It serves as an example of integrating these services for scenarios requiring real-time communication, and can be adapted to suit various use cases.

## Architecture

The BlobSignalR application is built on a serverless architecture, leveraging various Azure components to achieve efficient event processing and real-time communication:

1. **Azure Event Grid**: 
   - Serves as the central messaging backbone, capturing events related to blob storage, such as additions and deletions.
   - Sends these events to configured Azure Functions for processing.

2. **Azure Functions**: 
   - **ManageBlobEvents**: This function is triggered by events from the Event Grid. It processes the blob events, extracts relevant information, and broadcasts the data to connected SignalR clients.
   - **NegotiateFn**: This function handles connection negotiation requests from clients. It provides the necessary SignalR connection information required for clients to connect to the SignalR hub.

3. **SignalR**: 
   - Enables real-time communication between the server (Azure Functions) and clients (HTML page). Once connected, clients can receive and display updates as soon as they occur.

4. **Client-Side Interface**:
   - A simple HTML page that uses JavaScript to connect to the SignalR hub. It listens for incoming messages and updates the user interface with the latest blob events in real-time.

## Deployment Instructions

1. **Create a Storage Account**:
   - Create a new Azure Storage Account that will trigger events when blobs are added or deleted.
   - Note down the **Storage Account connection string**.

2. **Create a SignalR Service**:
   - Create a SignalR Service instance. Choose the **Serverless** tier for integration flexibility.
   - Note down the **SignalR Service connection string** and **Hub name** (e.g., `mysignals`).

3. **Publish Azure Functions**:
   - Publish **ManageBlobEvents** to an Azure Function:
     - Ensure it supports Event Grid Triggers to process blob events.
     - **Important**: Update the **Hub Name** (e.g., `mysignals`) in the `BlobEventsFn` function to match the one from your SignalR Service.
   - Publish **SignalRCon** to another Azure Function:
     - Ensure it supports HTTP Triggers for SignalR connection negotiation.
     - **Important**: Update the **Hub Name** (e.g., `mysignals`) in the `NegotiateFn` function to match the one from your SignalR Service.

4. **Create an Event Grid System Topic**:
   - Create an Event Grid System Topic with the type set to `Microsoft.Storage.StorageAccounts`.
   - Set the destination to your **ManageBlobEvents** Azure Function App.
   - Configure the topic to trigger on blob creation and deletion events.

5. **Set Environment Variables**:
   - Add the following environment variables in the Azure Function App settings for **ManageBlobEvents**:
     - **AzureWebJobsStorage**: Connection string for the Azure Storage Account.
     - **AzureSignalRConnectionString**: Connection string for the Azure SignalR Service.

   > **Note**: It's not recommended to store sensitive information such as connection strings and keys directly in the code or appsettings or environment variables. Instead, consider using a secure service such as **Azure Key Vault** to manage and retrieve secrets securely. 

6. **Host the Client HTML Page**:
   - The client HTML page must be hosted on a web server (local or cloud) to connect to the SignalR hub and display blob events in real time.
     - You can host the page locally on your machine using a web server (e.g., IIS or any lightweight server).
     - Alternatively, host the client HTML page on a cloud-based service such as **Storage Account WebSite**, **Azure App Service**, **GitHub Pages**, or **AWS S3**.
     - Ensure the client HTML page is updated to use the correct SignalR hub URL and connection details.


- **Technologies Used**:
  - Azure Functions
  - Azure Event Grid
  - Azure SignalR Service
  - JavaScript (for client-side interaction)
  - HTML/CSS (for the user interface)

- **Real-Time Updates**: 
  - The architecture allows for efficient processing and immediate broadcasting of events, ensuring that clients always have the latest information.

## References

- [Azure Functions Documentation](https://docs.microsoft.com/en-us/azure/azure-functions/)
- [Azure Event Grid Documentation](https://docs.microsoft.com/en-us/azure/event-grid/)
- [Azure SignalR Service Documentation](https://docs.microsoft.com/en-us/azure/azure-signalr/)
- [JavaScript SignalR Client](https://docs.microsoft.com/en-us/azure/azure-signalr/signalr-overview)

## Note

This project is intended to showcase the integration of various Azure serverless services to create a real-time application. It is not meant to be a definitive guide but rather a demonstration of potential use cases and capabilities. Readers are encouraged to explore the underlying technologies, understand their applications, and consider how they can leverage Azure services to address their specific needs. The goal is to inspire innovative thinking and facilitate a deeper understanding of serverless architectures.

## Author

Vadi Raju Parande | [LinkedIn Profile](https://www.linkedin.com/in/yourprofile)


