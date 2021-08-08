using ConsoleATM.Models.ViewModels;
using ConsoleATM.Services;
using System;
using System.Text;

namespace ConsoleATM.Interations
{
    public class OperationsInteractions
    {
        private readonly UserService userService = new UserService();

        private readonly InitialInterations initialInterations = new InitialInterations();

        public void Operations()
        {
            Console.WriteLine("O que podemos fazer por você hoje?");
            Menu();

            var operation = Console.ReadLine();

            while (true)
            {
                switch (operation.Trim())
                {
                    case "1":
                        Console.Clear();

                        Console.WriteLine("**********************");
                        Console.WriteLine("*** Consultar saldo **");
                        Console.WriteLine("**********************");

                        var user = initialInterations.SecurityLogin();

                        if (user == null)
                        {
                            Console.WriteLine("Senha inválida.");

                            break;
                        }

                        Console.WriteLine("------------------------------------");
                        Console.WriteLine($"Nome completo: {user.FirstName} {user.LastName}");
                        Console.WriteLine($"Número da conta: {user.Number.ToString()}");
                        Console.WriteLine($"Saldo: {user.Balance.ToString("C")}");
                        Console.WriteLine("------------------------------------");
                        break;
                    case "2":
                        Console.Clear();

                        Console.WriteLine("**********************");
                        Console.WriteLine("** Realizar depósito *");
                        Console.WriteLine("**********************");

                        user = initialInterations.SecurityLogin();

                        if (user == null)
                        {
                            Console.WriteLine("Senha inválida.");

                            break;
                        }

                        Console.Write("Valor para depósito: ");
                        var money = Convert.ToDouble(Console.ReadLine());

                        var operationId = 1;

                        userService.Operation(user, money, operationId);

                        Console.WriteLine("---------------------------------------------------------");
                        Console.WriteLine($"Depósito de {money.ToString("C")} realizado com sucesso!");
                        Console.WriteLine("---------------------------------------------------------");
                        break;
                    case "3":
                        Console.Clear();

                        Console.WriteLine("**********************");
                        Console.WriteLine("*** Realizar saque ***");
                        Console.WriteLine("**********************");

                        user = initialInterations.SecurityLogin();

                        if (user == null)
                        {
                            Console.WriteLine("Senha inválida.");

                            break;
                        }

                        Console.Write("Valor para saque: ");
                        money = Convert.ToDouble(Console.ReadLine());

                        operationId = 2;

                        userService.Operation(user, money, operationId);

                        Console.WriteLine("---------------------------------------------------------");
                        Console.WriteLine($"Saque de {money.ToString("C")} realizado com sucesso!");
                        Console.WriteLine("---------------------------------------------------------");
                        break;
                    case "4":
                        Console.Clear();

                        Console.WriteLine("**********************");
                        Console.WriteLine("****** Histórico *****");
                        Console.WriteLine("**********************");

                        user = initialInterations.SecurityLogin();

                        if (user == null)
                        {
                            Console.WriteLine("Senha inválida.");

                            break;
                        }

                        var historic = userService.Historic(user);

                        foreach (HistoricViewModel h in historic)
                        {
                            StringBuilder s = new StringBuilder();

                            s.Append(" -- ");
                            s.Append(h.Id.ToString());
                            s.Append(" -- ");
                            s.Append(h.OperationId.ToString());
                            s.Append(" -- ");
                            s.Append(h.Description.ToString());
                            s.Append(" -- ");
                            s.Append(h.Date.ToString());
                            s.Append(" -- ");

                            Console.WriteLine(s);
                        }
                        break;
                    case "5":
                        Console.Clear();
                        break;
                    case "6":
                        Console.Clear();
                        Console.WriteLine("Obrigado pela preferência! Volte sempre.");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("A operação selecionada está inválida ou não existe! Tente novamente.");
                        break;
                }

                Console.WriteLine();
                Console.WriteLine("**********************");
                Console.WriteLine("* Operação encerrada *");
                Console.WriteLine("**********************");

                Console.WriteLine();
                Console.WriteLine("Mais alguma coisa?");

                Menu();
                operation = Console.ReadLine();
            }
        }

        private void Menu()
        {
            Console.WriteLine("1 - Consultar saldo;");
            Console.WriteLine("2 - Realizar deposito;");
            Console.WriteLine("3 - Realizar saque;");
            Console.WriteLine("4 - Historico;");
            Console.WriteLine("5 - Limpar tela;");
            Console.WriteLine("6 - Sair.");
            Console.WriteLine();

            Console.Write("Operação: ");
        }
    }
}
