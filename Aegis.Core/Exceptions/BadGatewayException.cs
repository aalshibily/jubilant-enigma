using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aegis.Core.Exceptions
{
    public class BadGatewayException : HttpRequestException
    {
        public BadGatewayException()
            : base("Received a 502 Bad Gateway response from the server.")
        {
        }

        public BadGatewayException(string message)
            : base(message)
        {
        }

        public BadGatewayException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
