using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AutomatedTellerMachine.Models
{
    public class TransferViewModel
    {
        [Required]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

        [Required]
        public int CheckingAccountId { get; set; }

        [Required]
        [Display(Name="To Account #")]
        public string DestinationCheckingAccountNumber { get; set; }
    }
}