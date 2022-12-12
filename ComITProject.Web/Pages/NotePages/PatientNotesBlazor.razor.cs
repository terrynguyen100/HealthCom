using ComITProject.Dal.Model;
using ComITProject.Dal.Model.Identity;
using ComITProject.Web.Services;
using ComITProject.Web.Services.Interfaces;
using ComITProject.Web.Shared.Enum;
using ComITProject.Web.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts;
using System.Drawing.Text;
using ComITProject.Web.Pages.NotePages;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace ComITProject.Web.Pages.NotePages
{
    public partial class PatientNotesBlazor
    {
        //this part is to extract the current user to feed into Author of the new note
        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationStateTask { get; set; }
        private AuthenticationState authenticationState;

        [Inject]
        protected INoteService NoteService { get; set; }
        [Inject]
        protected IPatientService PatientService { get; set; }
        [Inject]
        protected IStaffService StaffService { get; set; }


        [Parameter]
        public int patientId { get; set; }

        List<Note> Notes { get; set; }
        Patient Patient { get; set; }
        Staff Staff { get; set; }
        Note? Note { get; set; }
        private ConfirmationModal? myConfirmationModal;
        public ModalForm? patientNoteModalForm { get; set; }

        private ModalFormType formType;

        private string formTitle = "";

        private bool IsSysAdmin = false;
        protected override async Task OnInitializedAsync()
        {
            Patient = new Patient();
            Patient.AppUser = new AppUser();
            Note = new Note();

            //to retrieve the user data and id of the current user, then feed the aspnetuserId to find the Staff that is currently viewing/editing/adding the notes
            authenticationState = await AuthenticationStateTask;
            var user = authenticationState.User;
            int aspnetuserid = int.Parse(user.FindFirstValue(ClaimTypes.NameIdentifier));
            IsSysAdmin = user.IsInRole("SysAdmin");

            Staff = await StaffService.GetStaffByAppUserId(aspnetuserid);
            Patient = await PatientService.GetPatientById(patientId);
            Notes = await NoteService.GetNotesListByPatientId(patientId);
        }

        private async Task CreateNoteClick()
        {
            Note = new Note();
            formTitle = "Create new Note";
            formType = ModalFormType.Add;
            await patientNoteModalForm.Show();
        }

        private async Task AddNoteConfirmedClick()
        {
            Note.PatientId = Patient.Id;
            Note.StaffId = Staff.Id;
            Note.DateTimeCreated= DateTime.Now;

            await NoteService.CreateNote(Note);
            Notes = await NoteService.GetNotesListByPatientId(patientId);
            StateHasChanged();
            await patientNoteModalForm.Hide();
        }

        //private async Task EditNoteClick(int noteid)
        //{
        //    await JSRuntime.InvokeVoidAsync("Alert", "Currently under development!");
        //}
        //private async Task DeleteNoteClick(int noteid)
        //{
        //    await JSRuntime.InvokeVoidAsync("Alert", "Currently under development!");
        //}

        //DELETE NOTES
        public async Task DeleteNoteClick(int noteid)
        {
            Note = await NoteService.GetNoteById(noteid);
            if (Note != null)
            {
                //to check whether the user is the author of the note OR a sysadmin before the note can be delete
                if (Note.StaffId == Staff.Id || IsSysAdmin)
                {
                    await myConfirmationModal.Show();
                }
                else
                {
                    await JSRuntime.InvokeVoidAsync("Alert", "Not authorized to DELETE another staff's note");
                }
            }

        }

        private async Task DeleteConfirmedClick()
        {
            await NoteService.DeleteNote(Note);
            Notes.RemoveAll(p => p.Id == Note.Id);
        }


        //EDIT NOTE
        private async Task EditNoteClick(int noteid)
        {
            formTitle = "Edit Patient";
            formType = ModalFormType.Edit;
            Note = await NoteService.GetNoteById(noteid);
            if (Note != null)
            {
                //to check whether the user is the author of the note OR a sysadmin before the note can be delete
                if (Note.StaffId == Staff.Id || IsSysAdmin)
                {
                    await patientNoteModalForm.Show();
                }
                else
                {
                    await JSRuntime.InvokeVoidAsync("Alert", "Not authorized to EDIT another staff's note");
                }
            }
        }
        private async Task ConfirmSaveNote()
        {
            Note.DateTimeCreated = DateTime.Now;
            Note.PatientId = Patient.Id;
            Note.StaffId = Staff.Id;

            //put some validation here
            await NoteService.UpdateNote(Note);
            Notes = await NoteService.GetNotesListByPatientId(patientId);
            await patientNoteModalForm.Hide();
            StateHasChanged();
        }
    }
}
