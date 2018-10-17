using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIAndOAuth.Models
{
    public class BillingDetail
    {
        public int BillingDetailId { get; set; }
        public string Owner { get; set; }
        public string Number { get; set; }

        public string Note263 { get; set; }
    }

    public class BankAccount : BillingDetail
    {
        public string BankName { get; set; }
        public string Swift { get; set; }
    }

    public class CreditCard : BillingDetail
    {
        public int CardType { get; set; }
        public string ExpiryMonth { get; set; }
        public string ExpiryYear { get; set; }
    }
}