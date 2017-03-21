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
        void Clear(RegisterAdministrators_Form form);
        void BindTextboxControls(RegisterAdministrators_Form form, AdministratorsViewModel viewModel, TextBox textbox);
        void DisplayAdministratorEmails(RegisterAdministrators_Form form, AdministratorsController controller, AdministratorsModel model, CurrentSortingType sortingType);
        void OnPropertyChanged(string propertyName);
    }

}
