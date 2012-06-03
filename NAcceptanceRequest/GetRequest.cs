using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NAcceptanceRequest
{
    public class GetRequest : BaseRequest
    {
        public GetRequest(string url)
            : base(url)
        {
            Request.Method = "GET";
        }
    }
}
