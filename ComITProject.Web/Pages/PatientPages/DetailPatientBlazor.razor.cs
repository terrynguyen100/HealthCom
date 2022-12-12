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

namespace ComITProject.Web.Pages.PatientPages
{
    public partial class DetailPatientBlazor
    {
        [Inject]
        protected IPatientService PatientsService { get; set; }
        [Inject]
        protected IAddressService AddressService { get; set; }
        [Inject]
        protected IEmergencyContactService EmergencyContactService { get; set; }

        [Parameter]
        public int Id { get; set; }

        public Patient Patient { get; set; }

        public Address? Address { get; set; }
        public EmergencyContact? EmergencyContact { get; set; }

        private ConfirmationModal? myConfirmationModalAddress;

        private ConfirmationModal? myConfirmationModalEmergencyContact;

        private ModalForm? modalFormAddress;

        private ModalForm? modalFormEmergencyContact;

        private ModalFormType formType;

        private string formTitle = "";

        protected override async Task OnInitializedAsync()
        {
            Address = new Address();
            EmergencyContact = new EmergencyContact();
            Patient = await PatientsService.GetPatientById(Id);
        }

        //ADDRESS related
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


        //Emergency Contacts Related
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
