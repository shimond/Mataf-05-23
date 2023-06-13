namespace FirstWebApi.Contracts
{
    public interface ISearchService
    {
        Task<List<FileDetails>> GetFilesByDirectory(string dirName);
    }
}
