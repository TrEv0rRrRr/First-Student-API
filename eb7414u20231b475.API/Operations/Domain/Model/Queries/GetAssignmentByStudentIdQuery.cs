namespace eb7414u20231b475.API.Operations.Domain.Model.Queries
{
    /// <summary>
    /// Query to retrieve an assignment by its student id
    /// </summary>
    /// <param name="StudentId">The student id</param>
    public record GetAssignmentByStudentIdQuery(int StudentId)
    {
    }
}