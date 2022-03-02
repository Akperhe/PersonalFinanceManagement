using System.ComponentModel.DataAnnotations;

namespace PersonalFinanceManagement.Data.Dtos
{
    
    public class CreateAccountSummaryDto
    {
        public string AccountNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public double Balance { get; set; }
       
    }
    public class AccountSummaryDto
    {
        public string AccountNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public double Balance { get; set; }

    }
    public class UpdateAccountSummaryDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
       // [Required]
        public string Address { get; set; }
    }
  
}
