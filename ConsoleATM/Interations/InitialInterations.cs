using ConsoleATM.Models.InputModels;
using ConsoleATM.Models.ViewModels;
using ConsoleATM.Services;
using System;

namespace ConsoleATM.Interations
{
    public class InitialInterations
    {
        UserService userService = new UserService();

        public void Greeting()
        {
            Console.WriteLine("****************************************");
            Console.WriteLine("*** Bem-vindo(a) ao Banco Prioridade ***");
            Console.WriteLine("****************************************");
            Console.WriteLine();
        }

        public LoginViewModel FirstLogin()
        {
            Console.Write("Senha: ");
            var password = Console.ReadLine();
            Console.WriteLine();

            var loginInput = new LoginInputModel
            {
                Password = password
            };

            var usuario = userService.Login(loginInput);

            if (usuario == null)
                return null;

            Console.WriteLine("Seja bem-vindo(a), {0}.", usuario.FirstName);
            Console.WriteLine();

            return usuario;
        }

        public LoginViewModel SecurityLogin()
        {
            Console.WriteLine();

            Console.Write("Senha: ");
            var password = Console.ReadLine();
            Console.WriteLine();

            var loginInput = new LoginInputModel
            {
                Password = password
            };

            var usuario = userService.Login(loginInput);

            if (usuario == null)
                return null;

            return usuario;
        }
    }
}
