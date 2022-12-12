using ComITProject.Dal.Model.Identity;
using ComITProject.Dal.Model;
using ComITProject.Dal.Context;
using ComITProject.Web.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ComITProject.Web.Services
{
    public class AppUserService : IAppUserService
    {

        private readonly ApplicationDbContext _dbContext;

        //idependency injection
        public AppUserService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            
        }

        
        public async Task<AppUser> CreateAppUser(AppUser appuser)
        {

            _dbContext.AppUsers.Add(appuser);
            await _dbContext.SaveChangesAsync();
            return appuser;
        }

        public async Task DeleteAppUser(AppUser appuser)
        {
            _dbContext.AppUsers.Remove(appuser);
            await _dbContext.SaveChangesAsync();
            //no need to return appuser because it is deleted
        }

        public async Task<AppUser> GetAppUserById(int id)
        {
            AppUser? appuser;
            appuser = await _dbContext.AppUsers
                .FirstOrDefaultAsync(p => p.Id == id);
            return appuser;
        }

        public async Task<List<AppUser>> GetAppUsersList()
        {
            //create a appuser-list-type variable to return
            List<AppUser> returnList = new();

            //set the returnlist using ToListAsync, also include any other entities that has a foreign key in the AppUser entity
            returnList = await _dbContext.AppUsers
                .ToListAsync();

            return returnList;
        }

        public async Task UpdateAppUser(AppUser appuser)
        {
            _dbContext.AppUsers.Update(appuser);
            await _dbContext.SaveChangesAsync();
        }
    }
}
