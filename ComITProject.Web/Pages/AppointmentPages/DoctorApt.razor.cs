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
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Principal;
using System.Security.Claims;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace ComITProject.Web.Pages.AppointmentPages
{
    public partial class DoctorApt
    {
        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationStateTask { get; set; }

        [Inject]
        protected IStaffService StaffService { get; set; }
        

        public int StaffId { get; set; }
        public Staff Staff { get; set; }
        
        private AuthenticationState authenticationState;
        
        protected override async Task OnInitializedAsync()
        {
            //to retrieve the user data and id of the current user
            authenticationState = await AuthenticationStateTask;
            var user = authenticationState.User;
            int aspuserid = int.Parse(user.FindFirstValue(ClaimTypes.NameIdentifier));

            Staff = await StaffService.GetStaffByAppUserId(aspuserid);
        }

     }
}
