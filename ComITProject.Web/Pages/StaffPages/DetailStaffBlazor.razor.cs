using ComITProject.Dal.Model;
using ComITProject.Dal.Model.Identity;
using ComITProject.Web.Services;
using ComITProject.Web.Services.Interfaces;
using ComITProject.Web.Shared;
using ComITProject.Web.Shared.Enum;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ComITProject.Web.Pages.StaffPages
{
    public partial class DetailStaffBlazor
    {
        [Inject]
        protected IStaffService StaffsService { get; set; }
        [Inject]
        protected IStaffSpecialtyService StaffSpecialtiesService { get; set; }
        [Inject]
        protected ISpecialtyService SpecialtiesService { get; set; }
        [Parameter]
        public int Id { get; set; }

        public Staff Staff { get; set; }

        public StaffSpecialty? StaffSpecialty { get; set; }
        private List<Specialty> Specialties { get; set; }

        private ConfirmationModal? myConfirmationModalStaffSpecialty;

        private ModalForm? modalFormStaffSpecialty;

        private ModalFormType formType;

        private string formTitle = "";

        private int _tempInt;
        protected override async Task OnInitializedAsync()
        {
            Staff = await StaffsService.GetStaffById(Id);
            StaffSpecialty = new StaffSpecialty();
            StaffSpecialty.StaffId = Staff.Id;
            
            //preparing the dropdown list of specialties
            
            Specialties = await SpecialtiesService.GetSpecialtiesList();
            _tempInt = Specialties[0].Id;
        }

        //StaffSpecialty Related
        #region
        //DELETE
        public async Task DeleteStaffSpecialtyClick(int specialtyid)
        {
            StaffSpecialty = await StaffSpecialtiesService.GetStaffSpecialtyById(Id, specialtyid);
            if (StaffSpecialty != null)
            {
                await myConfirmationModalStaffSpecialty.Show();
            }
        }
        private async Task DeleteStaffSpecialtyConfirmedClick()
        {
            await StaffSpecialtiesService.DeleteStaffSpecialty(StaffSpecialty);
            Staff.StaffSpecialties.RemoveAll(x => x.SpecialtyId == StaffSpecialty.SpecialtyId);

        }

        //CREATE
        private async Task CreateStaffSpecialtyClick()
        {
            formTitle = "Add New Staff Specialty";
            formType = ModalFormType.Add;
            await modalFormStaffSpecialty.Show();
        }
        private async Task AddStaffSpecialtyConfirmedClick()
        {
            ////filling the staffspecialty variable before sending it to be created
            StaffSpecialty = new StaffSpecialty();
            StaffSpecialty.StaffId = Staff.Id;
            StaffSpecialty.SpecialtyId = _tempInt;

            bool IsAlreadyExisted = false;
            foreach (StaffSpecialty s in Staff.StaffSpecialties)
            {
                if (s.SpecialtyId == _tempInt)
                {
                    IsAlreadyExisted = true;
                }
            }

            if (IsAlreadyExisted)
            {
                await JSRuntime.InvokeVoidAsync("Alert", "Specialty already exist");
            }
            else
            {
                await StaffSpecialtiesService.CreateStaffSpecialty(StaffSpecialty);
                StateHasChanged();
                await modalFormStaffSpecialty.Hide();
            }
            

        }
        #endregion
    }
}
