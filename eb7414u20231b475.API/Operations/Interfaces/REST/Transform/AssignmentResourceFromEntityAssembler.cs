using eb7414u20231b475.API.Operations.Domain.Model.Aggregate;
using eb7414u20231b475.API.Operations.Interfaces.REST.Resources;

namespace eb7414u20231b475.API.Operations.Interfaces.REST.Transform
{
    /// <summary>
    /// Assembler class to convert an assignment entity to an assignment resource
    /// </summary>
    public static class AssignmentResourceFromEntityAssembler
    {
        /// <summary>
        /// Converts an assignment entity to an assignment resource
        /// </summary>
        /// <param name="entity">The <see cref="Assignment"/> entity</param>
        /// <returns>An <see cref="AssignmentResource"/></returns>
        public static AssignmentResource ToResourceFromEntity(Assignment entity)
        {
            return new AssignmentResource(entity.Id, entity.StudentId, entity.BusId, entity.AssignedAt);
        }
    }
}