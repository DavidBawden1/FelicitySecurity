using FelicitySecurity.Applications.Config.Controllers;
using FelicitySecurity.Applications.Config.ViewModels;
using FelicitySecurity.Core.Models;
using System.Windows.Forms;

namespace FelicitySecurity.Applications.Config.Interfaces
{
    public interface IAdministratorsViewModel
    {
        int AdminID { get; set; }
        string Email { get; set; }
        string Username { get; set; }
        string PinCode { get; set; }
        string PinCodeConfirmed { get; set; }
        void Clear(RegisterAdministratorsForm form);
        void BindFormControls(RegisterAdministratorsForm form, AdministratorsViewModel viewModel, TextBox textbox);
        void DisplayAdministratorEmails(RegisterAdministratorsForm form, AdministratorsController controller, AdministratorsModel model, CurrentSortingType sortingType);
        void OnPropertyChanged(string propertyName);
    }

}
