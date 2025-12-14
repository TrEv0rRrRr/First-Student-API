using eb7414u20231b475.API.Operations.Domain.Model.Aggregate;
using eb7414u20231b475.API.Operations.Domain.Model.Command;

namespace eb7414u20231b475.API.Operations.Domain.Services
{
    /// <summary>
    /// Represents the Assignment command service
    /// </summary>
    public interface IAssignmentCommandService
    {
        /// <summary>
        /// Handles the create assignment command
        /// </summary>
        /// <param name="command">The <see cref="CreateAssignmentCommand"/></param>
        /// <returns>The created <see cref="Assignment"/> entity</returns>
        Task<Assignment?> Handle(CreateAssignmentCommand command);
    }
}