using ComITProject.Web.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComITProject.Dal.Model;
using ComITProject.Dal.Model.Identity;
using ComITProject.Web.Shared;
using ComITProject.Web.Shared.Enum;

namespace ComITProject.Web.Pages.PatientPages
{
    public partial class ListPatientBlazor
    {
        [Inject]
        protected IPatientService PatientService { get; set; }
        [Inject]
        protected IAppUserService AppUserService { get; set; }

        private List<Patient> Patients { get; set; }

        private List<AppUser> AppUsers { get; set; }

        private Patient? Patient { get; set; }

        private ConfirmationModal? myConfirmationModal;

        private ModalForm? modalForm;

        private ModalFormType formType;

        private string formTitle = "";

        protected override async Task OnInitializedAsync()
        {
            //instantiate so that the modal forms can load
            Patient = new Patient();
            Patient.AppUser = new AppUser();

            Patients = await PatientService.GetPatientsList();
        }

        public async Task DeletePatientClick(int patientId)
        {
            Patient = await PatientService.GetPatientById(patientId);
            if (Patient.AppUser != null)
            {
                await myConfirmationModal.Show();
            }
        }

        private async Task DeleteConfirmedClick()
        {
            await PatientService.DeletePatient(Patient);
            await AppUserService.DeleteAppUser(Patient.AppUser);
            Patients.RemoveAll(p => p.Id == Patient.Id);
        }

        private async Task ConfirmAddPatient()
        {
            await PatientService.CreatePatient(Patient);
            Patients = await PatientService.GetPatientsList();
            StateHasChanged();
            await modalForm.Hide();
        }

        private async Task ConfirmSavePatient()
        {
            //put some validation here
            await PatientService.UpdatePatient(Patient);
            Patients = await PatientService.GetPatientsList();
            await modalForm.Hide();
            StateHasChanged();
        }

        private async Task CreateNewPatientClick()
        {
            formTitle = "Create new Patient";
            formType = ModalFormType.Add;
            Patient = new Patient();
            await modalForm.Show();
        }

        private async Task EditPatientClick(int patientid)
        {
            formTitle = "Edit Patient";
            Patient = await PatientService.GetPatientById(patientid);
            formType = ModalFormType.Edit;
            await modalForm.Show();
        }
    }
}
