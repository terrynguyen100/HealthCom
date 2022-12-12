using ComITProject.Dal.Model;

namespace ComITProject.Web.Services.Interfaces
{
    public interface IEmergencyContactService
    {
        //follow the CRUD: Create, read, update, delete. In the case of read, we either read the whole list of emergencycontacts or 1 specific person
        public Task<EmergencyContact> CreateEmergencyContact(EmergencyContact emergencycontact);
        public Task<List<EmergencyContact>> GetEmergencyContactsList();
        public Task<EmergencyContact> GetEmergencyContactById(int Id);
        public Task UpdateEmergencyContact(EmergencyContact emergencycontact);
        public Task DeleteEmergencyContact(EmergencyContact emergencycontact);
     
    }
}
