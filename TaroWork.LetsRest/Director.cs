using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace TaroWork.LetsRest
{
    internal class Director : IDirector
    {
        internal Producer Producer { get; private set; }

        internal HttpRequestMessage Request { get; private set; }

        public Director(Producer producer)
        {
            Producer = producer;
        }

        public IActor Get()
        {
            return CreateActorWithoutPayload(HttpMethod.Get);
        }

        public IActor Post()
        {
            return CreateActorWithoutPayload(HttpMethod.Post);
        }

        public IActor Put()
        {
            return CreateActorWithoutPayload(HttpMethod.Put);
        }

        public IActor Delete()
        {
            return CreateActorWithoutPayload(HttpMethod.Delete);
        }

        private IActor CreateActorWithoutPayload(HttpMethod method)
        {
            Request = CreateRequest(method, null);
            return new Actor(this);
        }

        public IActor GetAstring(string payload)
        {
            return CreateActorAsString(HttpMethod.Get, payload);
        }

        public IActor PostAstring(string payload)
        {
            return CreateActorAsString(HttpMethod.Post, payload);
        }

        public IActor PutAstring(string payload)
        {
            return CreateActorAsString(HttpMethod.Put, payload);
        }


        public IActor DeleteAstring(string payload)
        {
            return CreateActorAsString(HttpMethod.Delete, payload);
        }

        private IActor CreateActorAsString(HttpMethod method, string payload)
        {
            Request = CreateRequest(method, new StringContent(payload));
            return new Actor(this);
        }

        public IActor GetAsJson<T>(T payload)
        {
            return CreateActorAsJson(HttpMethod.Get, payload);
        }

        public IActor PostAsJson<T>(T payload)
        {
            return CreateActorAsJson(HttpMethod.Post, payload);
        }

        public IActor PutAsJson<T>(T payload)
        {
            return CreateActorAsJson(HttpMethod.Put, payload);
        }

        public IActor DeleteAsJson<T>(T payload)
        {
            return CreateActorAsJson(HttpMethod.Delete, payload);
        }

        public IActor CreateActorAsJson<T>(HttpMethod method, T payload)
        {
            var content = new StringContent(JsonConvert.SerializeObject(payload));
            Request = CreateRequest(method, content);
            Request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return new Actor(this);
        }

        private HttpRequestMessage CreateRequest(HttpMethod method, HttpContent content)
        {
            var request = new HttpRequestMessage(method, Producer.Endpoint);
            request.Content = content;
            return request;
        }
    }
}
