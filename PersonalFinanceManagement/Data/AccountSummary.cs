namespace PersonalFinanceManagement.Data
{
    public class AccountSummary
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string AccountNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public double Balance { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateModified { get; set; } = DateTime.Now;

    }
}
