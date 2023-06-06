namespace FirstWebApi.Model
{
    public record FileDetails
    {
        public long Size { get; init; }
        public string Name{ get; init; }
        public string Extension{ get; init; }
        public DateTime LastModified { get; init; }

    }
}
