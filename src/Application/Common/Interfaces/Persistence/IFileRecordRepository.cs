using Domain.FileRecords;

namespace Application.Common.Interfaces.Persistence;

public interface IFileRecordRepository
{
    Task AddAsync(FileRecord fileRecord);
    Task<FileRecord?> GetByFileNameAsync(string fileName);
}
