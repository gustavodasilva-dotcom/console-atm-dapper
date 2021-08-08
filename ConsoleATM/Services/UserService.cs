using ConsoleATM.Models.InputModels;
using ConsoleATM.Models.ViewModels;
using ConsoleATM.Repositories;
using ConsoleATM.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace ConsoleATM.Services
{
    public class UserService : IUserService
    {
        UserRepository userRepository = new UserRepository();

        public LoginViewModel Login(LoginInputModel login)
        {
            var query = $"SELECT Number, Balance, FirstName, LastName FROM CheckingAccount AS CA INNER JOIN  Client AS CL ON CA.ClientId = CL.ClientId WHERE CA.Password = {login.Password}";

            var result = userRepository.Login(query);

            return result;
        }

        public void Operation(LoginViewModel login, double money, int operation)
        {
            var query = $"EXEC [dbo].[spi_Operations] {operation}, {login.Number}, {money}";

            userRepository.Update(query);
        }

        public IEnumerable<HistoricViewModel> Historic(LoginViewModel login)
        {
            var query = $"SELECT * FROM OperationLogs AS O INNER JOIN CheckingAccount AS C ON C.CheckingAccountId = O.CheckingAccountId WHERE C.Number = {login.Number}";

            var historic = userRepository.Historic(query);

            return historic;
        }
    }
}
