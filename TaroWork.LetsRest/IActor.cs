using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace TaroWork.LetsRest
{
    public interface IActor
    {
        Task<T> Object<T>();

        Task<string> String();

        Task<Stream> Stream();

        Task<byte[]> Bytes();

        Task<HttpResponseMessage> Response();
    }
}
