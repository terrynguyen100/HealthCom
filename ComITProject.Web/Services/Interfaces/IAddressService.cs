using ComITProject.Dal.Model;

namespace ComITProject.Web.Services.Interfaces
{
    public interface IAddressService
    {
        //follow the CRUD: Create, read, update, delete. 
        public Task<List<Address>> GetAddressesList();
        public Task<Address> GetAddressById(int id);
        public Task<Address> CreateAddress(Address address);
        public Task UpdateAddress(Address address);
        public Task DeleteAddress(Address address);
     
    }
}
