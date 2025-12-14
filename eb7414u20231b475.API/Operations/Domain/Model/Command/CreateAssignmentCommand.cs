namespace eb7414u20231b475.API.Operations.Domain.Model.Command
{
    /// <summary>
    /// Command to create an assignment
    /// </summary>
    /// <remarks>Author: Valentino Solis</remarks>
    public record CreateAssignmentCommand(int StudentId, int BusId)
    {
    }
}