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

namespace ComITProject.Web.Pages.UserPages
{
    public partial class ProfilePage
    {
        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationStateTask { get; set; }

        [Inject]
        protected IPatientService PatientService { get; set; }
        [Inject]
        protected IAddressService AddressService { get; set; }
        [Inject]
        protected IEmergencyContactService EmergencyContactService { get; set; }

        public int patientId { get; set; }
        public Patient Patient { get; set; }
        public Address? Address { get; set; }

        public EmergencyContact? EmergencyContact { get; set; }

        private ConfirmationModal? myConfirmationModalAddress;

        private ConfirmationModal? myConfirmationModalEmergencyContact;

        private ModalForm? modalFormAddress;

        private ModalForm? modalFormEmergencyContact;

        private ModalForm? modalFormPatient;

        private ModalFormType formType;

        private string formTitle = "";

        private AuthenticationState authenticationState;
        
        protected override async Task OnInitializedAsync()
        {
            //to retrieve the user data and id of the current user
            authenticationState = await AuthenticationStateTask;
            var user = authenticationState.User;
            int aspuserid = int.Parse(user.FindFirstValue(ClaimTypes.NameIdentifier));

            //instantiate to feed into the modalforms
            Address = new Address();
            EmergencyContact = new EmergencyContact();
            Patient = new Patient();
            Patient.AppUser = new AppUser();
            //getting data to feed in the html portion of this blazor page
            Patient = await PatientService.GetPatientByAppUserId(aspuserid);
            if (Patient == null)
            {
                Patient = new Patient();
                Patient.AppUserId = aspuserid;
                Patient.Gender = "Male";
                Patient.PreferredName = "";
                await PatientService.CreatePatient(Patient);
                Patient = await PatientService.GetPatientByAppUserId(aspuserid);
            }
            
        }

        //image uploading code
        //[HttpPost]
        //public IActionResult UploadImage()
        //{
        //    foreach (var file in Request.Form.Files)
        //    {
        //        Image img = new Image();
        //        img.ImageTitle = file.FileName;

        //        MemoryStream ms = new MemoryStream();
        //        file.CopyTo(ms);
        //        img.ImageData = ms.ToArray();

        //        ms.Close();
        //        ms.Dispose();

        //        db.Images.Add(img);
        //        db.SaveChanges();
        //    }
        //    ViewBag.Message = "Image(s) stored in database!";
        //    return View("Index");
        //}

        //PATIENT RELATED
        #region
        private async Task EditPatientClick(int _patientid)
        {
            formTitle = "Edit Patient";
            Patient = await PatientService.GetPatientById(_patientid);
            formType = ModalFormType.Edit;
            await modalFormPatient.Show();
        }

        private async Task ConfirmSavePatient()
        {
            //put some validation here
            await PatientService.UpdatePatient(Patient);
            //Patient = await PatientsService.GetPatientById(patientId);
            await modalFormPatient.Hide();
            StateHasChanged();
        }
        
        #endregion
        //ADDRESS RELATED
        #region
        //DELETE
        //we use patient.address in the MyConfirmationModal because that modal doesn't need an instance of Address 
        public async Task DeleteAddressClick(int addressId)
        {
            if (Patient.Address != null)
            {
                await myConfirmationModalAddress.Show();
            }
        }
        private async Task DeleteAddressConfirmedClick()
        {
            await AddressService.DeleteAddress(Patient.Address);

        }

        //CREATE
        private async Task CreateAddressClick()
        {
            Address = new Address();
            formTitle = "Create new Address";
            formType = ModalFormType.Add;
            await modalFormAddress.Show();
        }
        private async Task AddAddressConfirmedClick()
        {
            Address.PatientID = Patient.Id;
            await AddressService.CreateAddress(Address);
            StateHasChanged();
            await modalFormAddress.Hide();
        }

        //EDIT / UPDATE
        private async Task EditAddressClick(int addressid)
        {
            formTitle = "Edit Address";
            Address = await AddressService.GetAddressById(addressid);
            formType = ModalFormType.Edit;
            await modalFormAddress.Show();
        }
        private async Task UpdateAddressConfirmedClick()
        {
            //put some validation here
            await AddressService.UpdateAddress(Address);
            await modalFormAddress.Hide();
            StateHasChanged();
        }
        #endregion
        //EMERGENCY CONTACT RELATED
        #region
        //DELETE
        //we use patient.emergencycontact in the MyConfirmationModal because that modal doesn't need an instance of EmergencyContact 
        public async Task DeleteEmergencyContactClick(int emergencycontactId)
        {
            if (Patient.EmergencyContact != null)
            {
                await myConfirmationModalEmergencyContact.Show();
            }
        }
        private async Task DeleteEmergencyContactConfirmedClick()
        {
            await EmergencyContactService.DeleteEmergencyContact(Patient.EmergencyContact);

        }

        //CREATE
        private async Task CreateEmergencyContactClick()
        {
            EmergencyContact = new EmergencyContact();
            formTitle = "Create new Emergency Contact";
            formType = ModalFormType.Add;
            await modalFormEmergencyContact.Show();
        }
        private async Task AddEmergencyContactConfirmedClick()
        {
            EmergencyContact.PatientId = Patient.Id;
            await EmergencyContactService.CreateEmergencyContact(EmergencyContact);
            StateHasChanged();
            await modalFormEmergencyContact.Hide();
        }

        //EDIT / UPDATE
        private async Task EditEmergencyContactClick(int emergencycontactid)
        {
            formTitle = "Edit EmergencyContact";
            EmergencyContact = await EmergencyContactService.GetEmergencyContactById(emergencycontactid);
            formType = ModalFormType.Edit;
            await modalFormEmergencyContact.Show();
        }
        private async Task UpdateEmergencyContactConfirmedClick()
        {
            //put some validation here
            await EmergencyContactService.UpdateEmergencyContact(EmergencyContact);
            await modalFormEmergencyContact.Hide();
            StateHasChanged();
        }
        #endregion

        
    }
}
