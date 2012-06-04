using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace NAcceptanceRequest
{
    public class GetRequestWithCookies : GetRequest
    {
        public GetRequestWithCookies(string url, IEnumerable<CookieData> cookies)
            : base(url)
        {
            Request.CookieContainer = new CookieContainer();

            foreach (CookieData cookie in cookies)
            {
                Request.CookieContainer.Add(new Cookie(cookie.Key, cookie.Value));
            }
        }
    }
}
