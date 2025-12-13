using Cortex.Mediator.Commands;

namespace eb7414u20231b475.API.Shared.Infrastructure.Mediator.Cortex.Configuration
{
    public class LoggingCommandBehavior<TCommand>
    : ICommandPipelineBehavior<TCommand> where TCommand : ICommand
    {
        public async Task Handle(
            TCommand command,
            CommandHandlerDelegate next,
            CancellationToken cancellationToken)
        {
            // Log before/after
            await next();
        }
    }
}