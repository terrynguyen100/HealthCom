using ComITProject.Web.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComITProject.Dal.Model;
using ComITProject.Dal.Model.Identity;
using ComITProject.Web.Services;
using ComITProject.Web.Shared;
using ComITProject.Web.Shared.Enum;

namespace ComITProject.Web.Pages.SpecialtyPages
{
    public partial class ListSpecialtyBlazor
    {
        [Inject]
        protected ISpecialtyService SpecialtyService { get; set; }
        private List<Specialty> Specialties { get; set; }
        private Specialty? Specialty { get; set; }

        private ConfirmationModal? myConfirmationModal;

        private ModalForm? modalForm;

        private ModalFormType formType;

        private string formTitle = "";

        protected override async Task OnInitializedAsync()
        {
            Specialty = new Specialty();
            Specialties = await SpecialtyService.GetSpecialtiesList();
        }

        public async Task DeleteSpecialtyClick(int specialtyId)
        {
            Specialty = await SpecialtyService.GetSpecialtyById(specialtyId);

            if (Specialty != null)
            {
                await myConfirmationModal.Show();

            }

        }

        private async Task DeleteConfirmedClick()
        {
            await SpecialtyService.DeleteSpecialty(Specialty);
            Specialties.RemoveAll(p => p.Id == Specialty.Id);
        }

        private async Task AddConfirmedClick()
        {
            await SpecialtyService.CreateSpecialty(Specialty);
            Specialties = await SpecialtyService.GetSpecialtiesList();
            StateHasChanged();
            await modalForm.Hide();
        }

        private async Task UpdateConfirmedClick()
        {
            //put some validation here
            await SpecialtyService.UpdateSpecialty(Specialty);
            Specialties = await SpecialtyService.GetSpecialtiesList();
            await modalForm.Hide();
            StateHasChanged();
        }

        private async Task CreateSpecialtyClick()
        {
            formTitle = "Create new Specialty";
            formType = ModalFormType.Add;
            Specialty = new Specialty();
            await modalForm.Show();
        }

        private async Task EditSpecialtyClick(int specialtyid)
        {
            formTitle = "Edit Specialty";
            Specialty = await SpecialtyService.GetSpecialtyById(specialtyid);
            formType = ModalFormType.Edit;
            await modalForm.Show();
        }
    }
}
