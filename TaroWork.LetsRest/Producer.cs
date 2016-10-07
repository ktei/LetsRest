using System;

namespace TaroWork.LetsRest
{
    internal class Producer : IProducer
    {
        internal string Endpoint { get; private set; }

        internal TimeSpan? Timeout { get; private set; }

        internal string AuthToken { get; private set; }

        public Producer(string endpoint)
        {
            Endpoint = endpoint;
        }

        public IProducer WithAuthToken(string token)
        {
            AuthToken = token;
            return this;
        }

        public IProducer WithTimeout(TimeSpan timeout)
        {
            Timeout = timeout;
            return this;
        }

        public IActor Get(object payload = null)
        {
            return new Director(this).Get(payload);
        }

        public IActor Post(object payload = null)
        {
            return new Director(this).Post(payload);
        }

        public IActor Put(object payload = null)
        {
            return new Director(this).Put(payload);
        }

        public IActor Delete(object payload = null)
        {
            return new Director(this).Delete(payload);
        }
    }
}
