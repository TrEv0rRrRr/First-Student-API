namespace eb7414u20231b475.API.Shared.Domain.Repositories
{
    /// <summary>
    ///     Unit of work interface for all repositories
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        ///     Save changes to the repository
        /// </summary>
        /// <returns></returns>
        Task CompleteAsync();
    }
}