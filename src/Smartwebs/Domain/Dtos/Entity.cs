namespace Smartwebs.Domain.Dtos
{
    /// <summary>
    ///     A shortcut of <see cref="EntityDto{TPrimaryKey}" /> for most used primary key type (<see cref="int" />).
    /// </summary>
    public abstract class EntityDto : EntityDto<int>, IEntityDto
    {
    }

    /// <summary>
    ///     Basic implementation of IEntity dto interface.
    ///     An entity can inherit this class of directly implement to IEntity interface.
    /// </summary>
    /// <typeparam name="TPrimaryKey">Type of the primary key of the entity</typeparam>
    public abstract class EntityDto<TPrimaryKey> : IEntityDto<TPrimaryKey>
    {
        /// <summary>
        ///     Unique identifier for this entity.
        /// </summary>
        public virtual TPrimaryKey Id { get; set; }
    }
}