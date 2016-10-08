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
        private readonly Director _director;

        public Actor(Director director)
        {
            _director = director;
        }

        public Task<byte[]> ReceiveBytes()
        {
            return Act(r => r.Content.ReadAsByteArrayAsync());
        }

        public async Task<T> ReceiveJson<T>()
        {
            return await Act(async r =>
            {
                var str = await r.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(str);
            });
        }

        public Task<Stream> ReceiveStream()
        {
            return Act(r => r.Content.ReadAsStreamAsync());
        }

        public Task<string> ReceiveString()
        {
            return Act(r => r.Content.ReadAsStringAsync());
        }

        public Task<HttpResponseMessage> ReceiveResponse()
        {
            return Act(r => Task.FromResult(r));
        }

        private async Task<T> Act<T>(Func<HttpResponseMessage, Task<T>> parse)
        {
            using (var httpClient = CreateClient())
            {
                var response = await httpClient.SendAsync(_director.Request);
                return await parse(response);
            }
        }

        private HttpClient CreateClient()
        {
            var producer = _director.Producer;
            var httpClient = new HttpClient { Timeout = producer.Timeout ?? TimeSpan.FromSeconds(30) };
            if (!string.IsNullOrEmpty(producer.AuthToken))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", producer.AuthToken);
            }
            return httpClient;
        }
    }
}
