using eb7414u20231b475.API.Operations.Domain.Model.Command;
using eb7414u20231b475.API.Operations.Interfaces.REST.Resources;

namespace eb7414u20231b475.API.Operations.Interfaces.REST.Transform
{
    /// <summary>
    /// Assembler class to convert an assignment command from a resource
    /// </summary>
    public static class CreateAssignmentCommandFromResourceAssembler
    {
        /// <summary>
        /// Converts a create assignment resource into a create assignment command
        /// </summary>
        /// <param name="busId">The bus id</param>
        /// <param name="resource">The <see cref="CreateAssignmentResource"/></param>
        /// <returns>A <see cref="CreateAssignmentCommand"/></returns>
        public static CreateAssignmentCommand ToCommandFromResource(int busId, CreateAssignmentResource resource)
        {
            return new CreateAssignmentCommand(resource.StudentId, busId);
        }
    }
}