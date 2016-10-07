using System.Threading.Tasks;

namespace TaroWork.LetsRest
{
    public interface IDirector
    {
        IActor Get(object payload = null);

        IActor Post(object payload = null);

        IActor Put(object payload = null);

        IActor Delete(object payload = null);
    }
}
