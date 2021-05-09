namespace ShortLink.Core.Interface
{
    public interface IUnitOFWork
    {
        bool Commit();
        bool SaveChange();
        IRepository<TEntity> Repository<TEntity>() where TEntity : class;
    }
}
