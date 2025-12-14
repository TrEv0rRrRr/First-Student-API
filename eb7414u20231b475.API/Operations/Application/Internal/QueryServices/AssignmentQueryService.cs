using eb7414u20231b475.API.Operations.Domain.Model.Aggregate;
using eb7414u20231b475.API.Operations.Domain.Model.Queries;
using eb7414u20231b475.API.Operations.Domain.Repositories;
using eb7414u20231b475.API.Operations.Domain.Services;

namespace eb7414u20231b475.API.Operations.Application.Internal.QueryServices
{
    /// <summary>
    /// Represents the assignment query service
    /// </summary>
    public class AssignmentQueryService(IAssignmentRepository repo) : IAssignmentQueryService
    {
        /// <inheritdoc />
        public async Task<Assignment?> Handle(GetAssignmentByStudentIdQuery query)
        {
            return await repo.FindByStudentIdAsync(query.StudentId);
        }

        /// <inheritdoc />
        public async Task<bool> Handle(IsParentAssignedToDifferentVehicleQuery query)
        {
            return await repo.IsParentAssignedToDifferentVehicleAsync(query.ParentId, query.BusId);
        }

        public async Task<int?> Handle(GetParentIdByStudentIdQuery query)
        {
            return await repo.FindParentIdByStudentIdAsync(query.StudentId);
        }
    }
}