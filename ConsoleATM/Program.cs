using ConsoleATM.Interations;
using ConsoleATM.Models.ViewModels;
using System;

namespace ConsoleATM
{
    class Program
    {
        static void Main(string[] args)
        {
            var initialInterations = new InitialInterations();
            
            var operationsInteractions = new OperationsInteractions();

            LoginViewModel usuario = null;

            initialInterations.Greeting();

            usuario = initialInterations.FirstLogin();

            if (usuario == null)
            {
                Console.WriteLine("Usuário não encontrado.");

                return;
            }

            operationsInteractions.Operations();
        }
    }
}
