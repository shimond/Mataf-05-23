namespace FirstWebApi.Model.Config
{
    public record  MtfServerConfig
    {
        public string Protocol { get; init; }
        public string Host { get; init; }
        public int Port { get; init; }
        public string[] AllowVerb { get; init; }
    }

}
