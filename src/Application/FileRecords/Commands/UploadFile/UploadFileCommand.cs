using ErrorOr;
using MediatR;

namespace Application.FileRecords.Commands.UploadFile;

public record UploadFileCommand(Stream Stream, string FileName) : IRequest<ErrorOr<string>>;