namespace FirstWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SearchFilesController : ControllerBase
{
    [HttpGet(Name =nameof(GetDirectories))]
    [ProducesResponseType(200, Type=typeof(List<string>))]
    public async Task<IActionResult> GetDirectories(string path = "C:\\")
    {
        await Task.Delay(300);
        var result = Directory.GetDirectories(path);
        return Ok(result);
    }

    [ProducesResponseType(200, Type = typeof(List<FileDetails>))]
    [HttpGet("Files/{dirName}",Name =nameof(GetFilesByDirectory))]
    public async Task<IActionResult> GetFilesByDirectory(string dirName)
    {
        await Task.Delay(300);
        if(!Directory.Exists(dirName)) {
            return NotFound();
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
        return Ok(files);
    }

    [HttpDelete("{fullFileName}", Name = nameof(DeleteFile))]

    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteFile(string fullFileName)
    {
        await Task.Delay(300);
        if (!System.IO.File.Exists(fullFileName))
        {
            return NotFound();
        }

        System.IO.File.Delete(fullFileName);
        return NoContent();
    }
}








// youtube.com/watch?vid=123123klajsdl
// youtube.com/watch/123123klajsdl?

// http://www.zap.co.il/products/HP/printers/HPjc665122?include=price#admin

// Url parameters: - required
// CompanyName
// CategoryName
// UId

// Query params:  - optional
//include

// Hash
//admin

