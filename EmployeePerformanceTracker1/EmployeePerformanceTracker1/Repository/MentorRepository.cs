using EmployeePerformanceTracker1.Models;
using Microsoft.EntityFrameworkCore;


namespace EmployeePerformanceTracker1.Repository
{
    public class MentorRepository : IMentorRepository<Mentor>
    {
        private readonly EPTDBContext _dbcontext;
        public MentorRepository(EPTDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        #region GetAllMentors
        public async Task<IEnumerable<Mentor>> GetAll()
        {
            try
            {
                var records = await _dbcontext.Mentors.Select(e => new Mentor()
                {
                    //Id = e.Id,
                    MentorId = e.MentorId,
                    MentorName = e.MentorName,
                    //Date = e.Date,
                    
                    //ProgressDescription = e.ProgressDescription,
                    EmailId = e.EmailId,
                    PhoneNo = e.PhoneNo,
                    Password = e.Password,
                    //Rating = e.Rating,
                    //Feedback = e.Feedback,
                    JobRole = e.JobRole,
                    Location = e.Location,
                   
                    


                }).ToListAsync();
                return records;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region GetMentorDetailsById

        public async Task<Mentor> GetMentorDetailsById(int id)
        {
            try
            {
                var mentor = await _dbcontext.Mentors.Where(m => m.MentorId == id).Select(m => new Mentor()
                {
                   
                    MentorId = m.MentorId,
                    MentorName = m.MentorName,
                    EmailId = m.EmailId,
                    PhoneNo = m.PhoneNo,
                    Location = m.Location,
                    Password=m.Password,
                    JobRole=m.JobRole

                }
                ).FirstOrDefaultAsync();
                return mentor;
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region UpdateMentorDetails
        public async Task<Mentor> UpdateMentorDetails(Mentor mentor)
        {
            try
            {
                var mentor1 = await _dbcontext.Mentors.FirstOrDefaultAsync(m => m.MentorId == mentor.MentorId);
                if (mentor != null)
                {
                    
                    mentor1.MentorId = mentor.MentorId;
                    mentor1.MentorName = mentor.MentorName;
                    mentor1.EmailId = mentor.EmailId;
                    mentor1.PhoneNo = mentor.PhoneNo;
                    mentor1.Location = mentor.Location;
                    mentor1.Password = mentor.Password;
                    mentor1.JobRole = mentor.JobRole;
                    _dbcontext.SaveChanges();
                }
                return mentor1;
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region InsertMentor
        public async Task<Mentor> SaveMentor(Mentor entity)
        {
            try
            {
                var e = new Mentor()
                {
                    //Id =entity.Id  ,
                    MentorId = entity.MentorId,
                    MentorName = entity.MentorName,
                    //Date = entity.Date,
                   
                    //ProgressDescription=entity.ProgressDescription,
                    EmailId = entity.EmailId,
                    PhoneNo = entity.PhoneNo,
                    Password = entity.Password,
                    // Rating=entity.Rating,
                    //Feedback=entity.Feedback,
                    JobRole = entity.JobRole,
                    Location = entity.Location,
                   


                };
                _dbcontext.Mentors.Add(e);
                await _dbcontext.SaveChangesAsync();
                return e;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region deleteMentor
        public async Task<Mentor> DeleteEAsync(int MentorId)
        {
            var mentor = await _dbcontext.Mentors.FirstOrDefaultAsync(x => x.MentorId == MentorId);

            if (mentor == null)
            {
                throw new Exception("Record not Found, could not Delete Mentor ");
            }

            _dbcontext.Mentors.Remove(mentor);
            await _dbcontext.SaveChangesAsync();

            return mentor;
        }
        #endregion


        #region save
        public async Task Save()
        {
            await _dbcontext.SaveChangesAsync();
        }
        #endregion


    }
}
