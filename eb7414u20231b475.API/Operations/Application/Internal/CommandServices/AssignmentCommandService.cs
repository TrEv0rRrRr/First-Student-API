using eb7414u20231b475.API.Operations.Domain.Model.Aggregate;
using eb7414u20231b475.API.Operations.Domain.Model.Command;
using eb7414u20231b475.API.Operations.Domain.Repositories;
using eb7414u20231b475.API.Operations.Domain.Services;
using eb7414u20231b475.API.Shared.Domain.Model.Exceptions;
using eb7414u20231b475.API.Shared.Domain.Repositories;

namespace eb7414u20231b475.API.Operations.Application.Internal.CommandServices
{
    /// <summary>
    /// Represents the Assignment command service
    /// </summary>
    public class AssignmentCommandService(IAssignmentRepository repo, IUnitOfWork unitOfWork) : IAssignmentCommandService
    {
        /// <inheritdoc/>
        public async Task<Assignment?> Handle(CreateAssignmentCommand command)
        {
            int parentId = await repo.FindParentIdByStudentIdAsync(command.StudentId) ?? throw new BusinessRuleException("The student doesn't exists");

            if (await repo.IsParentAssignedToDifferentVehicleAsync(parentId, command.StudentId))
            {
                throw new BusinessRuleException("Students with the same parent must be assigned to the same vehicle");
            }

            if (await repo.ExistsByStudentIdAsync(command.StudentId))
            {
                throw new BusinessRuleException("An assignment for this student already exists");
            }
            var assignment = new Assignment(command);

            await repo.AddAsync(assignment);
            await unitOfWork.CompleteAsync();
            return assignment;
        }
    }
}