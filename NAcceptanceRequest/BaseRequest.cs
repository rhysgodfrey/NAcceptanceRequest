using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using NAcceptanceRequest.Exceptions;
using System.IO;
using System.Net.Cache;

namespace NAcceptanceRequest
{
    public abstract class BaseRequest
    {
        protected HttpWebRequest Request;
        protected HttpWebResponse Response;

        private string _body;
        private bool _called = false;
        private int _statusCode;
        private string _statusDescription;

        public BaseRequest(string url)
        {
            try
            {
                Request = (HttpWebRequest)WebRequest.Create(url);
            }
            catch (Exception ex)
            {
                throw new RequestFailedException(ex);
            }

            Request.AllowAutoRedirect = false;
            Request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
        }

        public int StatusCode
        {
            get
            {
                if (!_called)
                {
                    throw new RequestNotMadeException();
                }

                return _statusCode;
            }
        }

        public string StatusDescription
        {
            get
            {
                if (!_called)
                {
                    throw new RequestNotMadeException();
                }

                return _statusDescription;
            }
        }

        public string Body
        {
            get
            {
                if (!_called)
                {
                    throw new RequestNotMadeException();
                }

                return _body;
            }
        }

        public void MakeRequest()
        {
            try
            {
                Response = (HttpWebResponse)Request.GetResponse();
            }
            catch (WebException ex)
            {
                Response = (HttpWebResponse)ex.Response;
            }
            catch (Exception ex)
            {
                throw new RequestFailedException(ex);
            }
                        
            _statusCode = (int)Response.StatusCode;
            _statusDescription = Response.StatusDescription;

            using (StreamReader reader = new StreamReader(Response.GetResponseStream()))
            {
                _body = reader.ReadToEnd();
            }

            _called = true;
        }
    }
}
