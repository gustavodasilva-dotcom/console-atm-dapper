using System;

namespace ConsoleATM.Entities
{
    public class Account
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public double Balance { get; set; }
        public int Password { get; set; }
        public Client Client { get; set; }
    }
}
