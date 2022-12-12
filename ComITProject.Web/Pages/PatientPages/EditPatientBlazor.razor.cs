using ComITProject.Dal.Model;
using ComITProject.Dal.Model.Identity;
using ComITProject.Web.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComITProject.Web.Pages.PatientPages
{
    public partial class EditPatientBlazor
    {
        [Inject]
        protected IPatientService PatientsService { get; set; }
        [Inject]
        protected IAppUserService AppUsersService{ get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public int Id { get; set; }

        public Patient Patient { get; set; }
        
        public AppUser AppUser { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Patient = await PatientsService.GetPatientById(Id);
            //AppUser = await AppUsersService.GetAppUserById(Patient.AppUserId);
            
        }

        private async void SubmitPatient()
        {
            await PatientsService.UpdatePatient(Patient);
            AppUser = await AppUsersService.GetAppUserById(Patient.AppUserId);
            await AppUsersService.UpdateAppUser(AppUser);
            NavigationManager.NavigateTo("/patients");
        }
    }
}
