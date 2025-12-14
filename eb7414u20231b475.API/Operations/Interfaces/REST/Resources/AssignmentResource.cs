namespace eb7414u20231b475.API.Operations.Interfaces.REST.Resources
{
    /// <summary>
    /// Represents the assignment resource
    /// </summary>
    public record AssignmentResource(int Id, int StudentId, int BusId, DateTime AssignedAt)
    {
    }
}