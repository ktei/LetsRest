using System;

namespace TaroWork.LetsRest
{
    public interface IProducer
    {
        IProducer WithAuthToken(string token);

        IProducer WithTimeout(TimeSpan timeout);

        IActor Get(object payload = null);

        IActor Post(object payload = null);

        IActor Put(object payload = null);

        IActor Delete(object payload = null);
    }
}
