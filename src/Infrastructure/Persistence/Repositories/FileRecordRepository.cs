using Application.Common.Interfaces.Persistence;
using Domain.FileRecords;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class FileRecordRepository(ApplicationDbContext context) : IFileRecordRepository
{
    public async Task AddAsync(FileRecord fileRecord)
    {
        context.FileRecords.Add(fileRecord);
        await context.SaveChangesAsync();
    }

    public async Task<FileRecord?> GetByFileNameAsync(string fileName)
    {
        return await context.FileRecords.FirstOrDefaultAsync(fileRecord => fileRecord.FileName == fileName);
    }
}
