using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageBlobEvents.EventParsers
{
    internal class BlobEvent
    {
        public string EventType { get; set; } = string.Empty;
        public string EventTime { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string BlobUrl { get; set; } = string.Empty;
        public string eTag { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public long ContentLength { get; set; }
        public string BlobType { get; set; } = string.Empty;
        public string AccessTier { get; set; } = string.Empty;
    }
}
