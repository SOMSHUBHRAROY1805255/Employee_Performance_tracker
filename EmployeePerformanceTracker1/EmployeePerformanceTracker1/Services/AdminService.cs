using EmployeePerformanceTracker1.Models;
using EmployeePerformanceTracker1.Repository;

namespace EmployeePerformanceTracker1.Services
{
    public class AdminService
    {
        IAdminRepository<Admin> _repository;
        public AdminService(IAdminRepository<Admin> repository)
        {
            _repository = repository;
        }


        #region update
        public async Task<Admin> UpdateAdminRecord(Admin entity)
        {
            try
            {
                return await _repository.UpdateAdminRecord(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        public async Task Save()
        {
            //throw new NotImplementedException();
            await _repository.Save();
        }
    }
}