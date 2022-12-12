using ComITProject.Dal.Model;
using ComITProject.Dal.Context;
using ComITProject.Web.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ComITProject.Web.Services
{
    public class PatientService : IPatientService
    {
        
        private readonly ApplicationDbContext _dbContext;
        
        //idependency injection
        public PatientService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<Patient> CreatePatient(Patient patient)
        {
            
            _dbContext.Patients.Add(patient);
            await _dbContext.SaveChangesAsync();
            return patient;
        }

        public async Task DeletePatient(Patient patient)
        {
            _dbContext.Patients.Remove(patient);
            await _dbContext.SaveChangesAsync();
            //no need to return patient because it is deleted
        }

        public async Task<Patient> GetPatientById(int id)
        {
            Patient? patient = null;
            patient = await _dbContext.Patients
                .Include(p => p.AppUser)
                .Include(p => p.Address)
                .Include(p=> p.EmergencyContact)
                .FirstOrDefaultAsync(p=> p.Id == id);
            return patient;
        }

        public async Task<Patient> GetPatientByAppUserId(int id)
        {
            Patient? patient = null;
            patient = await _dbContext.Patients
                .Include(p => p.AppUser)
                .Include(p => p.Address)
                .Include(p => p.EmergencyContact)
                .FirstOrDefaultAsync(p => p.AppUserId == id);
            return patient;
        }

        public async Task<List<Patient>> GetPatientsList()
        {
            //create a patient-list-type variable to return
            List<Patient> returnList = new();

            //set the returnlist using ToListAsync, also include any other entities that has a foreign key in the Patient entity
            returnList = await _dbContext.Patients
                .Include(p => p.AppUser)
                .ToListAsync();

            return returnList;
        }

        public async Task UpdatePatient(Patient patient)
        {
            _dbContext.Patients.Update(patient);
            await _dbContext.SaveChangesAsync() ;
        }
    }
}
