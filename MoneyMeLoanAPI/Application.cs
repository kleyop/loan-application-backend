using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyMeLoanAPI.Models
{
    public class Application
    {
        public int Id { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal AmountRequired { get; set; }

        public int Term { get; set; } // in months
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string RedirectUrl { get; set; } = "http://default.url"; // Default value if missing

        // New fields
        public decimal RepaymentAmount { get; set; }
        public decimal EstablishmentFee { get; set; }
        public decimal TotalInterest { get; set; }
    }
}
