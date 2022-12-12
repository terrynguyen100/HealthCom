using ComITProject.Dal.Model;

namespace ComITProject.Web.Services.Interfaces
{
    public interface IStaffService
    {
        //follow the CRUD: Create, read, update, delete. In the case of read, we either read the whole list of Staffs or 1 specific person
        public Task<Staff> CreateStaff(Staff staff);
        public Task<List<Staff>> GetStaffsList();
        public Task<Staff> GetStaffById(int Id);
        public Task UpdateStaff(Staff staff);
        public Task DeleteStaff(Staff staff);

        public Task<Staff> GetStaffByAppUserId(int id);
    }
}
