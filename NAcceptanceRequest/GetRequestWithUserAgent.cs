using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NAcceptanceRequest
{
    public class GetRequestWithUserAgent : GetRequest
    {
        public GetRequestWithUserAgent(string url, string userAgent) :
            base(url)
        {
            Request.UserAgent = userAgent;
        }
    }
}
