using System;

namespace TaroWork.LetsRest
{
    public interface IProducer
    {
        IProducer WithOAuthBearerToken(string token);

        IProducer WithTimeout(TimeSpan timeout);

        IDirector Then();
    }
}
