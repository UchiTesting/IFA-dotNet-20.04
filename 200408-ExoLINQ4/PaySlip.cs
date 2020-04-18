namespace ExoLINQ4
{
    public class PaySlip
    {
        public int Id { get; set; }
        public int EmployeeID{ get; set; }
        public string Name{ get; set; }
        public int NbHours{ get; set; }
        public int NbExtraHours{ get; set; }
        public int Salary{ get; set; }

        public PaySlip(int id, int employeeId, string name, int nbHours, int nbExtraHours, int salary)
        {
            Id = id;
            EmployeeID = employeeId;
            Name = name;
            NbHours = nbHours;
            NbExtraHours = nbExtraHours;
            Salary = salary;
        }

        public override string ToString()
        {
            return $"Payslip {Id} {EmployeeID} {Name} {NbHours} {NbExtraHours} {Salary}";
        }
    }
}