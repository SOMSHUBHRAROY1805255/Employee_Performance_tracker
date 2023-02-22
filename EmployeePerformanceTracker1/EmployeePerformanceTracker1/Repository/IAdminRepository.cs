using EmployeePerformanceTracker1.Models;

namespace EmployeePerformanceTracker1.Repository
{
    public interface IAdminRepository<TEntity> where TEntity : class
    {
        #region abstract methods

        Task<TEntity> UpdateAdminRecord(TEntity entity);

        Task Save();
        #endregion

    }
}