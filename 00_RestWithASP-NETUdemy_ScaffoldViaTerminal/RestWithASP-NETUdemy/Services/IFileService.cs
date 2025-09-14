using RestWithASP_NETUdemy.Data.VO;

namespace RestWithASP_NETUdemy.Services;

public interface IFileService
{
    public byte[] GetFile(string fileName);
    public Task<FileDetailVO> SaveFileToDisk(IFormFile file);
    public Task<List<FileDetailVO>> SaveFilesToDisk(IList<IFormFile> files);
}