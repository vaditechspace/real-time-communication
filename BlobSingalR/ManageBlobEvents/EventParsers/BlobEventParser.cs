using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace ManageBlobEvents.EventParsers
{
    internal class BlobEventParser
    {
        public BlobEvent ParseBlobEventJson(JObject eventGridEvent)
        {
            BlobEvent blobEvent = new BlobEvent();
            blobEvent.Subject = eventGridEvent["subject"]?.ToString();
            blobEvent.EventType = eventGridEvent["eventType"]?.ToString();
            blobEvent.EventTime = eventGridEvent["eventTime"]?.ToString();

            // Extract 'data' section (it's JObject inside the main JObject)
            var data = eventGridEvent["data"] as JObject;

            if (data != null)
            {
                blobEvent.eTag = data["eTag"]?.ToString();
                blobEvent.ContentType = data["contentType"]?.ToString();
                blobEvent.ContentLength = data["contentLength"]?.ToObject<long>() ?? 0; //Bytes
                blobEvent.BlobType = data["blobType"]?.ToString();
                blobEvent.AccessTier = data["accessTier"]?.ToString();
                blobEvent.BlobUrl = data["url"]?.ToString();
            }
            return blobEvent;
        }

}
}
