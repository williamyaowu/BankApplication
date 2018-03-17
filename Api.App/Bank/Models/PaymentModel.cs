using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.App.Bank.Models
{
    public class PaymentModel
    {
        public string BSB { get; set; }
        public string AccountNumber { get; set; }

        public string AccountName { get; set; }

        public string Reference { get; set; }

        public decimal PaymentAmount { get; set; }
    }
}