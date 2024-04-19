using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aegis.Core.Domain.Entities
{
    public class SmallAlert
    {
        public string Headline { get; set; }
        public string Description { get; set; }
        public string Instruction { get; set; }
        public string Response { get; set; }

        public DateTime? Sent { get; set; }
        public DateTime? Effective { get; set; }
        public DateTime? Onset { get; set; }
        public DateTime? Expires { get; set; }
        public DateTime? Ends { get; set; }

        public string AreaDesc { get; set; }
        public string Status { get; set; }
        public string MessageType { get; set; }
        public string Category { get; set; }
        public string Severity { get; set; }
        public string Certainty { get; set; }
        public string Urgency { get; set; }
        public string Event { get; set; }
        public string SenderName { get; set; }

        public SmallAlert(Properties properties)
        {
            Headline = properties.headline;
            Description = properties.description;
            Instruction = properties.instruction;
            Response = properties.response;

            Sent = properties.sent;
            Effective = properties.effective;
            Onset = properties.onset;
            Expires = properties.expires;
            Ends = properties.ends;

            AreaDesc = properties.areaDesc;
            Status = properties.status;
            MessageType = properties.messageType;
            Category = properties.category;
            Severity = properties.severity;
            Certainty = properties.certainty;
            Urgency = properties.urgency;
            Event = properties._event;
            SenderName = properties.senderName;
        }

    }
}
