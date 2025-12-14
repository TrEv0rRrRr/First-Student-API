namespace eb7414u20231b475.API.Operations.Domain.Model.Queries
{
    /// <summary>
    /// Query to determine whether a parent is on a different vehicle or not
    /// </summary>
    /// <param name="ParentId">The parent id</param>
    /// <param name="BusId">The bus id</param>
    /// <returns>True, if the condition is satisfied, otherwise false</returns>
    public record IsParentAssignedToDifferentVehicleQuery(int ParentId, int BusId)
    {
    }
}