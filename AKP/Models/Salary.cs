namespace AKP.Models
{
    public class Salary
    {
        public int SalaryId { get; set; }
        public int PersonId { get; set; }
        public int HoursWorked { get; set; }
        public double Rate { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public double TotalLoan { get; set; }

        public virtual Person person { get; set; }
    }
}