using ComITProject.Dal.Model;
using ComITProject.Dal.Model.Identity;
using ComITProject.Web.Services;
using ComITProject.Web.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComITProject.Web.Pages.StaffPages
{
    public partial class CreateStaffBlazor
    {
        [Inject]
        protected IStaffService StaffsService { get; set; }

        [Inject]
        protected IAppUserService AppUsersService { get; set; }

        //need specialty service to pull the list of specialties to put in the dropdown list
        [Inject]
        protected ISpecialtyService SpecialtiesService { get; set; }

        //need this to update the staffspecialty table
        [Inject]
        protected IStaffSpecialtyService StaffSpecialtiesService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public Staff Staff { get; set; }
        public StaffSpecialty StaffSpecialty { get; set; }
        private List<Specialty> Specialties { get; set; }

        
        protected override async Task OnInitializedAsync()
        {
            //instantiate these objects
            Staff = new Staff();
            Staff.AppUser = new AppUser();
            StaffSpecialty = new StaffSpecialty();

            //preparing the dropdown list of specialties
            StaffSpecialty.SpecialtyId = 1;
            Specialties = await SpecialtiesService.GetSpecialtiesList();

            
        }

        private async Task SubmitStaff()
        {
            await AppUsersService.CreateAppUser(Staff.AppUser);
            await StaffsService.CreateStaff(Staff);
            
            //filling the staffspecialty variable before sending it to be created
            StaffSpecialty.StaffId = Staff.Id;
            await StaffSpecialtiesService.CreateStaffSpecialty(StaffSpecialty);


            NavigationManager.NavigateTo("/staffs");
        }


    }
}
