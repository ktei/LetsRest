using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace TaroWork.LetsRest
{
    internal class Actor : IActor
    {
        private readonly Producer _producer;
        private readonly HttpRequestMessage _message;

        public Actor(Producer producer, HttpRequestMessage message)
        {
            _producer = producer;
            _message = message;
        }

        public Task<byte[]> Bytes()
        {
            return Act(r => r.Content.ReadAsByteArrayAsync());
        }

        public async Task<T> Object<T>()
        {
            return await Act(async r =>
            {
                var str = await r.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(str);
            });
        }

        public Task<HttpResponseMessage> Response()
        {
            return Act(r => Task.FromResult(r));
        }

        public Task<Stream> Stream()
        {
            return Act(r => r.Content.ReadAsStreamAsync());
        }

        public Task<string> String()
        {
            return Act(r => r.Content.ReadAsStringAsync());
        }

        private async Task<T> Act<T>(Func<HttpResponseMessage, Task<T>> parse)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.Timeout = _producer.Timeout ?? TimeSpan.FromSeconds(30);
                if (!string.IsNullOrEmpty(_producer.AuthToken))
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _producer.AuthToken);
                }

                var response = await httpClient.SendAsync(_message);
                return await parse(response);
            }
        }
    }
}
