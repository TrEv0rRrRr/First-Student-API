namespace eb7414u20231b475.API.Operations.Domain.Model.Queries
{
    /// <summary>
    /// Query to retrieve the parent id of an student by it's id
    /// </summary>
    /// <param name="StudentId">The student id</param>
    /// <returns>The parent id if the student exists</returns>
    public record GetParentIdByStudentIdQuery(int StudentId)
    {
    }
}