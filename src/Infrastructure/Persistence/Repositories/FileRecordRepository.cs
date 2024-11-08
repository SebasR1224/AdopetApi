using Application.Common.Interfaces.Persistence;
using Domain.FileRecords;

namespace Infrastructure.Persistence.Repositories;

public class FileRecordRepository : IFileRecordRepository
{
    private readonly List<FileRecord> _fileRecords = [];

    public async Task AddAsync(FileRecord fileRecord)
    {
        await Task.CompletedTask;
        _fileRecords.Add(fileRecord);
    }

    public async Task<FileRecord?> GetByFileNameAsync(string fileName)
    {
        await Task.CompletedTask;
        return _fileRecords.FirstOrDefault(fileRecord => fileRecord.FileName == fileName);
    }
}
