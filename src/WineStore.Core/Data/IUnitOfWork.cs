namespace WineStore.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
