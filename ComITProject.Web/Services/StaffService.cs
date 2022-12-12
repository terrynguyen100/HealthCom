using ComITProject.Dal.Model;
using ComITProject.Dal.Context;
using ComITProject.Web.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ComITProject.Web.Services
{
    public class StaffService : IStaffService
    {
        
        private readonly ApplicationDbContext _dbContext;
        
        //idependency injection
        public StaffService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<Staff> CreateStaff(Staff staff)
        {
            
            _dbContext.Staffs.Add(staff);
            await _dbContext.SaveChangesAsync();
            return staff;
        }

        public async Task DeleteStaff(Staff staff)
        {
            _dbContext.Staffs.Remove(staff);
            await _dbContext.SaveChangesAsync();
            //no need to return staff because it is deleted
        }

        public async Task<Staff> GetStaffById(int id)
        {
            Staff? staff = null;
            staff = await _dbContext.Staffs
                .Include(s => s.AppUser)
                .Include(s => s.StaffSpecialties).ThenInclude(s => s.Specialty)
                .FirstOrDefaultAsync(s=> s.Id == id);
            return staff;
        }

        public async Task<List<Staff>> GetStaffsList()
        {
            //create a staff-list-type variable to return
            List<Staff> returnList = new();

            //set the returnlist using ToListAsync, also include any other entities that has a foreign key in the Staff entity
            returnList = await _dbContext.Staffs
                .Include(s => s.AppUser)
                .Include(s => s.StaffSpecialties).ThenInclude(s => s.Specialty)
                .ToListAsync();

            return returnList;
        }

        public async Task<Staff> GetStaffByAppUserId(int appuserid)
        {
            Staff? staff = null;
            staff = await _dbContext.Staffs
                .Include(p => p.AppUser)
                .Include(s => s.StaffSpecialties).ThenInclude(s => s.Specialty)
                .FirstOrDefaultAsync(p => p.AppUserId == appuserid);
            return staff;
        }
        public async Task UpdateStaff(Staff staff)
        {
            _dbContext.Staffs.Update(staff);
            await _dbContext.SaveChangesAsync() ;
        }
    }
}
