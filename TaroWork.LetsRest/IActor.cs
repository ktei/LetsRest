using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace TaroWork.LetsRest
{
    public interface IActor
    {
        Task<T> ReceiveJson<T>();

        Task<string> ReceiveString();

        Task<Stream> ReceiveStream();

        Task<byte[]> ReceiveBytes();

        Task<HttpResponseMessage> ReceiveResponse();
    }
}
