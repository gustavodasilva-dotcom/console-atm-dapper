using ConsoleATM.Models.InputModels;
using ConsoleATM.Models.ViewModels;

namespace ConsoleATM.Services.Interfaces
{
    public interface IUserService
    {
        LoginViewModel Login(LoginInputModel login);
    }
}
