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
using ComITProject.Web.Services;
using Microsoft.Extensions.ObjectPool;

namespace ComITProject.Web.Pages.StaffPages
{
    public partial class ListStaffBlazor
    {
        [Inject]
        protected IStaffService StaffService { get; set; }
        [Inject]
        protected IStaffSpecialtyService StaffSpecialtyService { get; set; }
        [Inject]
        protected IAppUserService AppUserService { get; set; }
        [Inject]
        protected ISpecialtyService SpecialtyService { get; set; }
        [Inject]
        protected ISpecialtyService SpecialtiesService { get; set; }
        private List<Staff> Staffs { get; set; }

        private Staff? Staff { get; set; }

        private AppUser? AppUser { get; set; }
        private List<Specialty> Specialties { get; set; }
        public StaffSpecialty? StaffSpecialty { get; set; }

        private ConfirmationModal? myConfirmationModal;

        //the following 3 variable is for the modal form of create, edit, etc.
        private ModalForm? modalForm;

        private ModalFormType formType;

        private string formTitle = "";
       
        protected override async Task OnInitializedAsync()
        {
            Staff = new Staff();
            Staff.AppUser = new AppUser();
            Staff.StaffSpecialties = new List<StaffSpecialty>();

            Staffs = await StaffService.GetStaffsList();
            Specialties = await SpecialtiesService.GetSpecialtiesList();
        }


        //DELETE STAFF
        public async Task DeleteStaffClick(int staffId)
        {
            Staff = await StaffService.GetStaffById(staffId);
      
            if (Staff != null)
            {
                await myConfirmationModal.Show();
            }
        }
        private async Task DeleteConfirmedClick()
        {
            
            await StaffService.DeleteStaff(Staff);
            await AppUserService.DeleteAppUser(Staff.AppUser);
            Staffs.RemoveAll(p => p.Id == Staff.Id);
        }

        //EDIT STAFF
        private async Task UpdateConfirmedClick()
        {
            //put some validation here
            await StaffService.UpdateStaff(Staff);
            Staffs = await StaffService.GetStaffsList();
            await modalForm.Hide();
            StateHasChanged();
        }
        private async Task EditStaffClick(int staffid)
        {
            formTitle = "Edit Staff";
            Staff = await StaffService.GetStaffById(staffid);
            formType = ModalFormType.Edit;
            await modalForm.Show();
        }


    }
}
