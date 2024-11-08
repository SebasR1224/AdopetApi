using ErrorOr;
using MediatR;
using Application.Common.Interfaces.Upload;
using Application.Common.Interfaces.Persistence;
using Domain.FileRecords;

namespace Application.FileRecords.Commands.UploadFile;

public class UploadFileCommandHandler(IFileStorageService fileStorageService, IFileRecordRepository fileRecordRepository) : IRequestHandler<UploadFileCommand, ErrorOr<string>>
{
    public async Task<ErrorOr<string>> Handle(UploadFileCommand command, CancellationToken cancellationToken)
    {
        //find the file in the db
        if (await fileRecordRepository.GetByFileNameAsync(command.FileName) is FileRecord file)
            return file.Url;

        var uploadFile = await fileStorageService.UploadFileAsync(command.FileName, command.Stream);

        var fileRecord = FileRecord.Create(command.FileName, uploadFile);

        await fileRecordRepository.AddAsync(fileRecord);

        return uploadFile;
    }
}