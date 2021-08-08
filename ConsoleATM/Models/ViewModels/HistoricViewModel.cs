using System;

namespace ConsoleATM.Models.ViewModels
{
    public class HistoricViewModel
    {
        public int Id { get; set; }
        public int OperationId { get; set; }
        public Guid CheckingAccount { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
