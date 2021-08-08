using System;

namespace ConsoleATM.Entities
{
    public class Client
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Cpf { get; set; }
        public Contacts Contacts { get; set; }
        public Address Address { get; set; }
    }
}
