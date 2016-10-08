namespace TaroWork.LetsRest
{
    public static class Lets
    {
        public static IProducer Call(string endpoint)
        {
            return new Producer(endpoint);
        }
    }
}
