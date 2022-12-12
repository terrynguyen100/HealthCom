using ComITProject.Dal.Model;

namespace ComITProject.Web.Services.Interfaces
{
    public interface INoteService
    {
        //follow the CRUD: Create, read, update, delete. 
        public Task<List<Note>> GetNotesList();
        public Task<Note> GetNoteById(int id);
        public Task<Note> CreateNote(Note note);
        public Task UpdateNote(Note note);
        public Task DeleteNote(Note note);

        public Task<List<Note>> GetNotesListByPatientId(int patientid);
    }
}
