using System;
using System.Net;

namespace InterfacePlay
{
    public class RestEvent : EventArgs
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public string RestClientName { get; set; }
    }
}
