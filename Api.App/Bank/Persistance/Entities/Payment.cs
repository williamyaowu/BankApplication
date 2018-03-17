using Api.App.Infrastructure.Persistance.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.App.Bank.Persistance.Entities
{
    public class Payment: IPEntity
    {
        public string BSB { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string Reference { get; set; }
        public decimal PaymentAmount { get; set; }
    }
}