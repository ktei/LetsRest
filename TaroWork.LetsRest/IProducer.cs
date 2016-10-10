using System;

namespace TaroWork.LetsRest
{
    public interface IProducer
    {
        IProducer WithOAuthBearerToken(string token);

        IProducer WithTimeout(TimeSpan timeout);

        IProducer WithTimeoutInSeconds(int seconds);

        IProducer WithTimeoutInMinutes(int minutes);

        IDirector Then();
    }
}
