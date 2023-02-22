using EmployeePerformanceTracker1.Models;
using EmployeePerformanceTracker1.Repository;


namespace EmployeePerformanceTracker1.Services
{
    public class MentorService
    {
        IMentorRepository<Mentor> _repository;
        public MentorService(IMentorRepository<Mentor> repository)
        {
            _repository = repository;
        }

        #region mentordetailsbyid
        public async Task<Mentor> GetMentorDetailsById(int id)
        {
            return await _repository.GetMentorDetailsById(id);
        }
        #endregion

        #region updatementordetails
        public async Task UpdateMentorDetails(Mentor entity)
        {
            await _repository.UpdateMentorDetails(entity);
        }
        #endregion

        #region GetAllMentors
        public async Task<IEnumerable<Mentor>> GetAll()
        {
            return await _repository.GetAll();
        }

        #endregion

        #region insert
        public async Task<Mentor> SaveMentor(Mentor entity)
        {
            try
            {
                return await _repository.SaveMentor(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region DeleteMentor
        public async Task<Mentor> DeleteEAsync(int MentorId)
        {
            try
            {
                return await _repository.DeleteEAsync(MentorId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region save
        public async Task Save()
        {
            await _repository.Save();
        }
        #endregion
    }
}
