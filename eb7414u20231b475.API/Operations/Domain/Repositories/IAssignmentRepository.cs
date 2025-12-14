using eb7414u20231b475.API.Operations.Domain.Model.Aggregate;
using eb7414u20231b475.API.Shared.Domain.Repositories;

namespace eb7414u20231b475.API.Operations.Domain.Repositories
{
    /// <summary>
    /// Represents the Assignment repository
    /// </summary>
    public interface IAssignmentRepository : IBaseRepository<Assignment>
    {
        /// <summary>
        /// Finds an assignment by its student id
        /// </summary>
        /// <param name="studentId">The student id</param>
        /// <returns>A <see cref="Assignment"/> entity if found, otherwise null</returns>
        Task<Assignment?> FindByStudentIdAsync(int studentId);
        Task<bool> ExistsByStudentIdAsync(int studentId);
        Task<bool> IsParentAssignedToDifferentVehicleAsync(int ParentId, int BusId);
        Task<int?> FindParentIdByStudentIdAsync(int StudentId);
    }
}