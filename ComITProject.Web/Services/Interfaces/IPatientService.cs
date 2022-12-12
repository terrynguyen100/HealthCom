using ComITProject.Dal.Model;

namespace ComITProject.Web.Services.Interfaces
{
    public interface IPatientService
    {
        //follow the CRUD: Create, read, update, delete. In the case of read, we either read the whole list of patients or 1 specific person
        public Task<Patient> CreatePatient(Patient patient);
        public Task<List<Patient>> GetPatientsList();
        public Task<Patient> GetPatientById(int id);
        public Task UpdatePatient(Patient patient);
        public Task DeletePatient(Patient patient);

        public Task<Patient> GetPatientByAppUserId(int id);
    }
}
