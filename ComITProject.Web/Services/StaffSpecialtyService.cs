using ComITProject.Dal.Model;
using ComITProject.Dal.Context;
using ComITProject.Web.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ComITProject.Web.Services
{
    public class StaffSpecialtyService : IStaffSpecialtyService
    {
        
        private readonly ApplicationDbContext _dbContext;
        
        //idependency injection
        public StaffSpecialtyService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<List<StaffSpecialty>> CreateStaffSpecialties(List<StaffSpecialty> staffspecialties)
        {
            foreach (var _staffspecialty in staffspecialties)
            {
                _dbContext.StaffSpecialties.Add(_staffspecialty);
            }
            await _dbContext.SaveChangesAsync();
            return staffspecialties;
        }


        public async Task<StaffSpecialty> CreateStaffSpecialty (StaffSpecialty staffspecialty)
        {
            _dbContext.StaffSpecialties.Add(staffspecialty);
            await _dbContext.SaveChangesAsync();
            return staffspecialty;
        }


        public async Task DeleteStaffSpecialty(StaffSpecialty staffspecialty)
        {
            _dbContext.StaffSpecialties.Remove(staffspecialty);
            await _dbContext.SaveChangesAsync();
            //no need to return StaffSpecialty because it is deleted
        }

        public async Task<StaffSpecialty> GetStaffSpecialtyById(int staffid, int specialtyid)
        {
            StaffSpecialty? staffspecialty = null;
            staffspecialty = await _dbContext.StaffSpecialties
                .Include(p => p.Staff)
                .Include(p => p.Specialty)
                .FirstOrDefaultAsync(p=> p.StaffId == staffid && p.SpecialtyId == specialtyid);
            return staffspecialty;
        }

       
        public async Task<List<StaffSpecialty>> GetStaffSpecialtysList()
        {
            //create a StaffSpecialty-list-type variable to return
            List<StaffSpecialty> returnList = new();

            //set the returnlist using ToListAsync, also include any other entities that has a foreign key in the StaffSpecialty entity
            returnList = await _dbContext.StaffSpecialties
                .Include(p => p.Staff)
                .Include(p => p.Specialty)
                .ToListAsync();

            return returnList;
        }

        public async Task UpdateStaffSpecialty(StaffSpecialty staffspecialty)
        {
            _dbContext.StaffSpecialties.Update(staffspecialty);
            await _dbContext.SaveChangesAsync() ;
        }

        public async Task<List<StaffSpecialty>> UpdateStaffSpecialityList (List<StaffSpecialty> oldstaffSpecialties, List<StaffSpecialty> newstaffspecialties)
        {
            _dbContext.StaffSpecialties.RemoveRange(oldstaffSpecialties);
            _dbContext.StaffSpecialties.AddRange(newstaffspecialties);
            await _dbContext.SaveChangesAsync();

            return newstaffspecialties;

        }
    }
}
