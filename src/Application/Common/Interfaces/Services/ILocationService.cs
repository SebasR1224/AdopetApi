using Domain.Abandonments;
using Domain.Foundations;

namespace Application.Common.Interfaces.Services;

public interface ILocationService
{
    Foundation? FindNearestFoundation(ReportAbandonment report, IEnumerable<Foundation> foundations);
}