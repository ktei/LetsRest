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

        public IProducer WithOAuthBearerToken(string token)
        {
            AuthToken = token;
            return this;
        }

        public IProducer WithTimeout(TimeSpan timeout)
        {
            Timeout = timeout;
            return this;
        }

        public IDirector Then()
        {
            return new Director(this);
        }
    }
}
