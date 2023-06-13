using FirstWebApi.Contracts;
using FirstWebApi.Exceptions;

namespace FirstWebApi.Services
{
    public class SearchService : ISearchService
    {
        private readonly UserAuth _auth;

        public SearchService(UserAuth auth)
        {
            _auth = auth;
        }
        public async Task<List<FileDetails>> GetFilesByDirectory(string dirName)
        {
            await Task.Delay(300);
            if (!Directory.Exists(dirName))
            {
                throw new CrudException("Cannot Find item", CrudExceptionType.NotFound);
            }

            DirectoryInfo dirInfo = new DirectoryInfo(dirName);
            var result = dirInfo.GetFiles();
            var files = result.Select(x => new FileDetails()
            {
                Name = x.Name,
                Size = x.Length,
                Extension = x.Extension,
                LastModified = x.LastWriteTime
            }).ToList();

            return files;
        }
    }
}
