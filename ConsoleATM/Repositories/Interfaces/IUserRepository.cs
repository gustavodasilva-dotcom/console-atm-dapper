using ConsoleATM.Models.ViewModels;

namespace ConsoleATM.Repositories.Interfaces
{
    public interface IUserRepository
    {
        LoginViewModel Login(string query);
    }
}
