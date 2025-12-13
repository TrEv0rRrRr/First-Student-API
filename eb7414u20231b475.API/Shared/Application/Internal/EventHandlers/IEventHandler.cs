using Cortex.Mediator.Notifications;
using eb7414u20231b475.API.Shared.Domain.Model.Events;

namespace eb7414u20231b475.API.Shared.Application.Internal.EventHandlers
{
  public interface IEventHandler<in TEvent> : INotificationHandler<TEvent> where TEvent : IEvent
  {

  }
}