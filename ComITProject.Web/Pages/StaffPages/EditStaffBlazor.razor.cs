using ComITProject.Dal.Model;
using ComITProject.Dal.Model.Identity;
using ComITProject.Web.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComITProject.Web.Pages.StaffPages
{
    public partial class EditStaffBlazor
    {
        [Inject]
        protected IStaffService StaffsService { get; set; }
        [Inject]
        protected IAppUserService AppUsersService{ get; set; }
        
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public int Id { get; set; }

        public Staff Staff { get; set; }
        
        public AppUser AppUser { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Staff = await StaffsService.GetStaffById(Id);
            //AppUser = await AppUsersService.GetAppUserById(Staff.AppUserId);
            
        }

        private async void SubmitStaff()
        {
            await StaffsService.UpdateStaff(Staff);
            AppUser = await AppUsersService.GetAppUserById(Staff.AppUserId);
            await AppUsersService.UpdateAppUser(AppUser);
            NavigationManager.NavigateTo("/staffs");
        }
    }
}
