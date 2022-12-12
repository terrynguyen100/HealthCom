using ComITProject.Dal.Model;
using ComITProject.Dal.Context;
using ComITProject.Web.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ComITProject.Web.Services
{
    public class NoteService : INoteService
    {
        
        private readonly ApplicationDbContext _dbContext;
        
        //idependency injection
        public NoteService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<Note> CreateNote(Note note)
        {
            
            _dbContext.Notes.Add(note);
            await _dbContext.SaveChangesAsync();
            return note;
        }

        public async Task DeleteNote(Note note)
        {
            _dbContext.Notes.Remove(note);
            await _dbContext.SaveChangesAsync();
            //no need to return note because it is deleted
        }

        public async Task<Note> GetNoteById(int noteid)
        {
            Note? note = null;
            note = await _dbContext.Notes
                .Include(s => s.Staff).ThenInclude(s=>s.AppUser)
                .Include(s => s.Patient).ThenInclude(s => s.AppUser)
                .FirstOrDefaultAsync(s=> s.Id == noteid);
            return note;
        }

        public async Task<List<Note>> GetNotesList()
        {
            //create a note-list-type variable to return
            List<Note> returnList = new();

            //set the returnlist using ToListAsync, also include any other entities that has a foreign key in the Note entity
            returnList = await _dbContext.Notes
                .Include(s => s.Staff).ThenInclude(s => s.AppUser)
                .Include(s => s.Patient).ThenInclude(s => s.AppUser)
                .ToListAsync();

            return returnList;
        }

        public async Task<List<Note>> GetNotesListByPatientId (int patientid)
        {
            List<Note> returnList = new();

            returnList = await _dbContext.Notes
                .Include(s => s.Staff).ThenInclude(s => s.AppUser)
                .Include(s => s.Patient).ThenInclude(s => s.AppUser)
                .Where(s => s.PatientId == patientid)
                .ToListAsync();

            return returnList;
        }
 
        public async Task UpdateNote(Note note)
        {
            _dbContext.Notes.Update(note);
            await _dbContext.SaveChangesAsync() ;
        }
    }
}
