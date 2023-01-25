using ComITProject.Dal.Model;

namespace ComITProject.Web.Services.Interfaces
{
    public interface ITimeslotService
    {
        public Task<Timeslot> CreateTimeslot(Timeslot timeslot);
        public Task<List<Timeslot>> GetTimeslotsList();
        public Task<Timeslot> GetTimeslotById(int id);
        public Task UpdateTimeslot(Timeslot timeslot);
        public Task DeleteTimeslot(Timeslot timeslot);

        public Task<List<Timeslot>> GetTimeslotByStaffId(int staffid);

    }
}
