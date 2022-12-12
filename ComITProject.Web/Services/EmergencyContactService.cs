using ComITProject.Dal.Model;
using ComITProject.Dal.Context;
using ComITProject.Web.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ComITProject.Web.Services
{
    public class EmergencyContactService : IEmergencyContactService
    {
        
        private readonly ApplicationDbContext _dbContext;
        
        //idependency injection
        public EmergencyContactService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<EmergencyContact> CreateEmergencyContact(EmergencyContact emergencycontact)
        {
            
            _dbContext.EmergencyContacts.Add(emergencycontact);
            await _dbContext.SaveChangesAsync();
            return emergencycontact;
        }

        public async Task DeleteEmergencyContact(EmergencyContact emergencycontact)
        {
            _dbContext.EmergencyContacts.Remove(emergencycontact);
            await _dbContext.SaveChangesAsync();
            //no need to return emergencycontact because it is deleted
        }

        

        public async Task<EmergencyContact> GetEmergencyContactById(int id)
        {
            EmergencyContact? emergencycontact = null;
            emergencycontact = await _dbContext.EmergencyContacts
                .Include(e => e.Patient)
                .FirstOrDefaultAsync(e=> e.Id == id);
            return emergencycontact;

        }

        public async Task<List<EmergencyContact>> GetEmergencyContactsList()
        {
            //create a emergencycontact-list-type variable to return
            List<EmergencyContact> returnList = new();

            //set the returnlist using ToListAsync, also include any other entities that has a foreign key in the EmergencyContact entity
            returnList = await _dbContext.EmergencyContacts
                .Include(e => e.Patient)
                .ToListAsync();

            return returnList;
        }

        public async Task UpdateEmergencyContact(EmergencyContact emergencycontact)
        {
            _dbContext.EmergencyContacts.Update(emergencycontact);
            await _dbContext.SaveChangesAsync() ;
        }
    }
}
