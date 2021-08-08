using ConsoleATM.Models.ViewModels;
using ConsoleATM.Repositories.Interfaces;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleATM.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository()
        {
            _connectionString = "Data Source=DESKTOP-8J62RD3\\SQLEXPRESS;Initial Catalog=ATM;Integrated Security=True;Connect Timeout=30";
        }

        public LoginViewModel Login(string query)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                db.Open();

                var login = db.QueryFirstOrDefault<LoginViewModel>(query);

                db.Close();

                return login;
            }
        }

        public void Update(string query)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                db.Open();

                var login = db.Execute(query);

                db.Close();
            }
        }

        public IEnumerable<HistoricViewModel> Historic(string query)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                db.Open();

                var historic = db.Query<HistoricViewModel>(query);

                db.Close();

                return historic;
            }
        }
    }
}
