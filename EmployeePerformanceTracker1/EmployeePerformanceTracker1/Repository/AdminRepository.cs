using EmployeePerformanceTracker1.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeePerformanceTracker1.Repository
{
    /* public class AdminRepository : IAdminRepository
     {
         private readonly EPTDBContext ePTDBContext;

         public AdminRepository(EPTDBContext ePTDBContext)
         {
             this.ePTDBContext = ePTDBContext;
         }
    */
    public class AdminRepository : IAdminRepository<Admin>
    {
        private readonly EPTDBContext context;
        public AdminRepository(EPTDBContext context) => this.context = context;


        #region CRUD Operations




        public async Task<Admin> UpdateAdminRecord(Admin entity)
        {
            try
            {
                var admin = await context.Admins.FirstOrDefaultAsync(e => e.AdminId == entity.AdminId);
                if (admin != null)
                {
                    admin.AdminId = entity.AdminId;
                    admin.AdminName = entity.AdminName;
                    admin.EmailId = entity.EmailId;
                    admin.Password = entity.Password;
                    admin.JobRole = entity.JobRole;
                    context.SaveChanges();
                }
                return admin;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /*
        public async Task<Admin> UpdateAsync(int AdminId, Admin admin)
        {
            var existingadmin = await ePTDBContext.Admins.FirstOrDefaultAsync(x => x.AdminId == AdminId);

            if (existingadmin == null)
            {
                throw new Exception("Record not Found, could not update Admin details");
            }
            existingadmin.AdminId = admin.AdminId;
            existingadmin.AdminName = admin.AdminName;
            existingadmin.EmailId = admin.EmailId;
            existingadmin.Password = admin.Password;
            existingadmin.JobRole = admin.JobRole;


            await ePTDBContext.SaveChangesAsync();

            return existingadmin;
        }

       
        */

        #endregion
        public async Task Save()
        {
            await context.SaveChangesAsync();
        }
    }
}
