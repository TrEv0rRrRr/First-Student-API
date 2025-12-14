using eb7414u20231b475.API.Operations.Domain.Model.Aggregate;
using eb7414u20231b475.API.Operations.Domain.Model.Entities;
using eb7414u20231b475.API.Operations.Domain.Repositories;
using eb7414u20231b475.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using eb7414u20231b475.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace eb7414u20231b475.API.Operations.Infrastructure.Persistence.EFC.Repositories
{
    /// <summary>
    /// Represents the assignment repository
    /// </summary>
    /// <param name="context">
    ///     The <see cref="AppDbContext" /> to use.
    /// </param>
    public class AssignmentRepository(AppDbContext context) : BaseRepository<Assignment>(context), IAssignmentRepository
    {
        /// <inheritdoc/>
        public async Task<Assignment?> FindByStudentIdAsync(int studentId)
        {
            return await Context.Set<Assignment>().FirstOrDefaultAsync(a => a.StudentId == studentId);
        }

        /// <inheritdoc/>
        public async Task<bool> ExistsByStudentIdAsync(int studentId)
        {
            return await Context.Set<Assignment>().AnyAsync(a => a.StudentId == studentId);
        }

        /// <inheritdoc/>
        public async Task<bool> IsParentAssignedToDifferentVehicleAsync(int parentId, int busId)
        {
            return await Context.Set<Assignment>()
                .Join(
                    Context.Set<Student>(),
                    assignment => assignment.StudentId,
                    student => student.Id,
                    (assignment, student) => new { assignment, student }
                )
                .AnyAsync(x => x.student.ParentId == parentId && x.assignment.BusId != busId);
        }

        /// <inheritdoc/>
        public async Task<int?> FindParentIdByStudentIdAsync(int studentId)
        {
            return await Context.Set<Student>().Where(s => s.Id == studentId)
                    .Select(s => (int?)s.ParentId)
                    .FirstOrDefaultAsync();
        }
    }
}