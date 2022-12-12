using ComITProject.Dal.Model;
using ComITProject.Dal.Context;
using ComITProject.Web.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ComITProject.Web.Services
{
    public class AddressService : IAddressService
    {
        
        private readonly ApplicationDbContext _dbContext;
        
        //idependency injection
        public AddressService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<Address> CreateAddress(Address address)
        {
            _dbContext.Addresses.Add(address);
            await _dbContext.SaveChangesAsync();
            return address;
        }

        public async Task DeleteAddress(Address address)
        {
            _dbContext.Addresses.Remove(address);
            await _dbContext.SaveChangesAsync();
            //no need to return Address because it is deleted
        }

        public async Task<Address> GetAddressById(int id)
        {
            Address? address = null;
            address = await _dbContext.Addresses
                .Include(a => a.Patient)
                .FirstOrDefaultAsync(p=> p.Id == id);
            return address;
        }

       
        public async Task<List<Address>> GetAddressesList()
        {
            //create a Address-list-type variable to return
            List<Address> returnList = new();

            //set the returnlist using ToListAsync, also include any other entities that has a foreign key in the Address entity
            returnList = await _dbContext.Addresses
                .Include(p => p.Patient)
                .ToListAsync();

            return returnList;
        }

        public async Task UpdateAddress(Address address)
        {
            _dbContext.Addresses.Update(address);
            await _dbContext.SaveChangesAsync() ;
        }
    }
}
