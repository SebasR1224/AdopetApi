using Application.Common.Helpers;
using Application.Common.Interfaces.Persistence;
using Domain.Abandonments;
using Domain.Abandonments.Enums;
using Domain.Abandonments.ValueObjects;
using Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Application.Abandonments.Commands.UpdateReportStatus;

public class UpdateReportStatusCommandHandler(IReportAbandonmentRepository abandonmentRepository) : IRequestHandler<UpdateReportStatusCommand, ErrorOr<Unit>>
{
    public async Task<ErrorOr<Unit>> Handle(UpdateReportStatusCommand command, CancellationToken cancellationToken)
    {
        if (await abandonmentRepository.GetByIdAsync(ReportAbandonmentId.Create(command.ReportAbandonmentId)) is not ReportAbandonment report)
            return Errors.ReportAbandonment.ReportAbandonmentNotFound;

        if (EnumHelper.ConvertToEnum<ReportStatus>(command.Status) is not ReportStatus status)
            return Errors.ReportAbandonment.InvalidStatus;

        report.UpdateStatus(status);

        abandonmentRepository.Update(report);

        return Unit.Value;
    }
}
