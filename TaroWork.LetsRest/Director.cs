using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace TaroWork.LetsRest
{
    internal class Director : IDirector
    {
        private readonly Producer _producer;

        internal HttpMethod Method { get; private set; }

        internal object Payload { get; set; }

        public Director(Producer producer)
        {
            _producer = producer;
        }

        public IActor Delete(object payload = null)
        {
            return Direct(HttpMethod.Delete, payload);
        }

        public IActor Get(object payload = null)
        {
            return Direct(HttpMethod.Get, payload);
        }

        public IActor Post(object payload = null)
        {
            return Direct(HttpMethod.Post, payload);
        }

        public IActor Put(object payload = null)
        {
            return Direct(HttpMethod.Put, payload);
        }

        private IActor Direct(HttpMethod method, object payload = null)
        {
            var request = new HttpRequestMessage(method, _producer.Endpoint);
            if (payload != null)
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(payload));
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            }
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return new Actor(_producer, request);
        }
    }
}
