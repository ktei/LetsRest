namespace TaroWork.LetsRest
{
    public interface IDirector
    {
        IActor Get();

        IActor Post();

        IActor Put();

        IActor Delete();

        IActor GetAstring(string payload);

        IActor PostAstring(string payload);

        IActor PutAstring(string payload);

        IActor DeleteAstring(string payload);

        IActor GetAsJson<T>(T payload);

        IActor PostAsJson<T>(T payload);

        IActor PutAsJson<T>(T payload);

        IActor DeleteAsJson<T>(T payload);
    }
}
