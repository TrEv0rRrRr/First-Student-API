using eb7414u20231b475.API.Operations.Domain.Model.Command;

namespace eb7414u20231b475.API.Operations.Domain.Model.Aggregate
{
    /// <summary>
    /// The assignment aggregate root
    /// </summary>
    /// <remarks>Author: Valentino Solis</remarks>
    public partial class Assignment
    {
        public int Id { get; }
        public int StudentId { get; private set; }
        public int BusId { get; private set; }
        public DateTime AssignedAt { get; private set; }

        protected Assignment() { } // Empty for EF Core

        public Assignment(CreateAssignmentCommand command)
        {
            StudentId = command.StudentId;
            BusId = command.BusId;
            AssignedAt = DateTime.Now;
        }
    }
}