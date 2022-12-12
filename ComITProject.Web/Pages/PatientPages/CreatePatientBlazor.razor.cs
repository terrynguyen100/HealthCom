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
    public partial class CreatePatientBlazor
    {
        [Inject]
        protected IPatientService PatientsService { get; set; }

        [Inject]
        protected IAppUserService AppUsersService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public Patient Patient { get; set; }
        

        protected override Task OnInitializedAsync()
        {
            Patient = new Patient();
            Patient.AppUser = new AppUser();
            return Task.CompletedTask;
        }

        private async Task SubmitPatient()
        {
            await AppUsersService.CreateAppUser(Patient.AppUser);
            await PatientsService.CreatePatient(Patient);

            NavigationManager.NavigateTo("/patients");
        }


    }
}
