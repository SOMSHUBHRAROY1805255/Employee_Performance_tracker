using EmployeePerformanceTracker1.Models;

namespace EmployeePerformanceTracker1.Repository
{
    public interface IMentorRepository<T1> where T1 : class
    {
        #region AbstractMethodsDeclaration
        Task<T1> GetMentorDetailsById(int id);
        Task<T1> UpdateMentorDetails(T1 entity);
        Task<IEnumerable<T1>> GetAll();
        Task<T1> DeleteEAsync(int MentorId);
        Task<T1> SaveMentor(T1 entity);

        Task Save();
        #endregion
    }
}
