using System;

namespace ConsoleATM.Entities
{
    public class Card
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public string Expiration { get; set; }
        public int Cvvs { get; set; }
        public string CardType { get; set; }
    }
}
