using Application.Common.Interfaces.Services;
using Domain.Abandonments;
using Domain.Foundations;

namespace Infrastructure.Services.Location;

public class LocationService : ILocationService
{
    public Foundation? FindNearestFoundation(ReportAbandonment report, IEnumerable<Foundation> foundations)
    {
        Foundation? nearestFoundation = null;
        double shortestDistance = double.MaxValue;

        foreach (var foundation in foundations)
        {
            double distance = report.Location.CalculateDistance(foundation.Location);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                nearestFoundation = foundation;
            }
        }

        return nearestFoundation;
    }
}
