using ComITProject.Dal.Model;

namespace ComITProject.Web.Services.Interfaces
{
    public interface ISpecialtyService
    {
        //follow the CRUD: Create, read, update, delete. In the case of read, we either read the whole list of Specialtys or 1 specific person
        public Task<Specialty> CreateSpecialty(Specialty specialty);
        public Task<List<Specialty>> GetSpecialtiesList();
        public Task<Specialty> GetSpecialtyById(int Id);
        public Task UpdateSpecialty(Specialty specialty);
        public Task DeleteSpecialty(Specialty specialty);
     
        
        


    }
}
