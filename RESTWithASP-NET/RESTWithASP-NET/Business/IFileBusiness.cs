using RESTWithASP_NET.Data.VO;

namespace RESTWithASP_NET.Business
{
    public interface IFileBusiness
    {
        public byte[] GetFile(string filename);
        public Task<FileDetailVO> SaveFileToDisk(IFormFile file);

        public Task<List<FileDetailVO>> SaveFilesToDisk(List<IFormFile> file);
    }
}
