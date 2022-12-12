using ComITProject.Dal.Model;
using ComITProject.Dal.Context;
using ComITProject.Web.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ComITProject.Web.Services
{
    public class SpecialtyService : ISpecialtyService
    {
        
        private readonly ApplicationDbContext _dbContext;
        
        //idependency injection
        public SpecialtyService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<Specialty> CreateSpecialty(Specialty specialty)
        {
            
            _dbContext.Specialties.Add(specialty);
            await _dbContext.SaveChangesAsync();
            return specialty;
        }

        public async Task DeleteSpecialty(Specialty specialty)
        {
            _dbContext.Specialties.Remove(specialty);
            await _dbContext.SaveChangesAsync();
            //no need to return specialty because it is deleted
        }

        public async Task<Specialty> GetSpecialtyById(int id)
        {
            Specialty? specialty = null;
            specialty = await _dbContext.Specialties
                .FirstOrDefaultAsync(p=> p.Id == id);
            return specialty;
        }

        public async Task<List<Specialty>> GetSpecialtiesList()
        {
            //create a specialty-list-type variable to return
            List<Specialty> returnList = new();

            //set the returnlist using ToListAsync, also include any other entities that has a foreign key in the Specialty entity
            returnList = await _dbContext.Specialties
                .ToListAsync();

            return returnList;
        }

        public async Task UpdateSpecialty(Specialty specialty)
        {
            _dbContext.Specialties.Update(specialty);
            await _dbContext.SaveChangesAsync() ;
        }
    }
}
