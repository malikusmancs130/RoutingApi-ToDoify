namespace RoutingApi.Domain.Common
{
    /// <summary>
    /// This interface is implemented by entities which wanted to store deletion information (who and when deleted).
    /// </summary>
    public interface IDeletionAudited : IHasDeletionTime, ISoftDelete
    {
        /// <summary>
        /// Which user deleted this entity?
        /// </summary>
        int? DeleterUserId { get; set; }
    }

    /// <summary>
    /// Adds navigation properties to <see cref="IDeletionAudited"/> interface for user.
    /// </summary>
    /// <typeparam name="TUser">Type of the user</typeparam>
    public interface IDeletionAudited<TUser> : IDeletionAudited
        where TUser : IEntity<int>
    {
        /// <summary>
        /// Reference to the deleter user of this entity.
        /// </summary>
        TUser DeleterUser { get; set; }
    }
}