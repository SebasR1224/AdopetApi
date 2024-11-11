using MediatR;

namespace Domain.Primitives;

public interface IHasDomainEvents : INotification
{
    public IReadOnlyList<IDomainEvent> GetDomainEvents();
    public void ClearDomainEvents();
}
