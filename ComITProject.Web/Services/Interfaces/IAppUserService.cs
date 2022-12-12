using ComITProject.Dal.Model;
using ComITProject.Dal.Model.Identity;

namespace ComITProject.Web.Services.Interfaces
{
    public interface IAppUserService
    {
        //follow the CRUD: Create, read, update, delete.
        public Task<AppUser> CreateAppUser(AppUser appuser);
        public Task<List<AppUser>> GetAppUsersList();
        public Task<AppUser> GetAppUserById(int Id);
        public Task UpdateAppUser(AppUser appuser);
        public Task DeleteAppUser(AppUser appuser);
     
    }
}
