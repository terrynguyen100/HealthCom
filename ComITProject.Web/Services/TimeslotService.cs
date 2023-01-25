using ComITProject.Dal.Model;
using ComITProject.Dal.Context;
using ComITProject.Web.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ComITProject.Web.Services
{
    public class TimeslotService : ITimeslotService
    {
        
        private readonly ApplicationDbContext _dbContext;
        
        //idependency injection
        public TimeslotService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<Timeslot> CreateTimeslot(Timeslot timeslot)
        {
            
            _dbContext.Timeslots.Add(timeslot);
            await _dbContext.SaveChangesAsync();
            return timeslot;
        }

        public async Task DeleteTimeslot(Timeslot timeslot)
        {
            _dbContext.Timeslots.Remove(timeslot);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Timeslot> GetTimeslotById(int id)
        {
            Timeslot? timeslot = null;
            timeslot = await _dbContext.Timeslots
                .Include(p => p.Staff)
                .FirstOrDefaultAsync(p=> p.Id == id);
            return timeslot;
        }

        public async Task<List<Timeslot>> GetTimeslotsList()
        {
            //create a timeslot-list-type variable to return
            List<Timeslot> returnList = new();

            //set the returnlist using ToListAsync, also include any other entities that has a foreign key in the Timeslot entity
            returnList = await _dbContext.Timeslots
                .Include(p => p.Staff)
                .ToListAsync();
            return returnList;
        }

        public async Task<List<Timeslot>> GetTimeslotByStaffId (int staffid)
        {
            List<Timeslot> returnList = new();

            returnList = await _dbContext.Timeslots
                .Include(p => p.Staff)
                .Where(s => s.StaffId == staffid)
                .ToListAsync();

            return returnList;
        }
        public async Task UpdateTimeslot(Timeslot timeslot)
        {
            _dbContext.Timeslots.Update(timeslot);
            await _dbContext.SaveChangesAsync() ;
        }
    }
}
