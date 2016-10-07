namespace TaroWork.LetsRest
{
    public static class Rest
    {
        public static IProducer For(string endpoint)
        {
            return new Producer(endpoint);
        }
    }
}
