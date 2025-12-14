using eb7414u20231b475.API.Operations.Domain.Model.Aggregate;
using eb7414u20231b475.API.Operations.Domain.Model.Queries;

namespace eb7414u20231b475.API.Operations.Domain.Services
{
    /// <summary>
    /// Represents the assignment query service
    /// </summary>
    public interface IAssignmentQueryService
    {
        /// <summary>
        /// Handles the get assignment by student id query
        /// </summary>
        /// <param name="query">The <see cref="GetAssignmentByStudentIdQuery"/></param>
        /// <returns>An <see cref="Assignment"/> entity, if found</returns>
        Task<Assignment?> Handle(GetAssignmentByStudentIdQuery query);

        /// <summary>
        /// Handles the IsParentAssignedToDifferentVehicleQuery
        /// </summary>
        /// <param name="query">The <see cref="IsParentAssignedToDifferentVehicleQuery"/></param>
        /// <returns>True, if the condition is satisfied, otherwise false</returns>
        Task<bool> Handle(IsParentAssignedToDifferentVehicleQuery query);

        Task<int?> Handle(GetParentIdByStudentIdQuery query);
    }
}