namespace FlashCard.Domain.Entities.Auditing
{
    /// <summary>
    /// This interface is implemented by entities which wanted to store deletion information (who and when deleted).
    /// </summary>
    public interface IDeletionAudited : IHasDeletionTime
    {
        /// <summary>
        /// Which user deleted this entity
        /// </summary>
        string DeleterUserId { get; set; }
    }
}