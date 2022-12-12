using ComITProject.Dal.Model;

namespace ComITProject.Web.Services.Interfaces
{
    public interface IStaffSpecialtyService
    {
        //follow the CRUD: Create, read, update, delete. 
        public Task<List<StaffSpecialty>> GetStaffSpecialtysList();
        public Task<StaffSpecialty> GetStaffSpecialtyById(int staffid, int specialtyid);

        //a method to add a list of specialty instead of just one like the other services
        public Task<List<StaffSpecialty>> CreateStaffSpecialties(List<StaffSpecialty> staffspecialties);

        public Task<StaffSpecialty> CreateStaffSpecialty(StaffSpecialty staffspecialty);
        public Task UpdateStaffSpecialty(StaffSpecialty staffspecialty);
        public Task DeleteStaffSpecialty(StaffSpecialty staffspecialty);
     
    }
}
