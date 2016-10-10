namespace TaroWork.LetsRest
{
    internal static class EndpointBuilder
    {
        public static string Build(string host, string path)
        {
            return $"{host.TrimEnd('/')}/{path.TrimStart('/')}";
        }
    }
}
