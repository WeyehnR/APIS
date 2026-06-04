namespace PayrollPractice.Api.Models

{
    public class Company
    {
        // this is the primary key for the company - it uniquely identifies the company in the database
        public required string Id { get; set; }

        public required string CompanyName { get; set; }

        //maintains a list of employees in the company
        internal List<Employee> Employees { get; set; } = [];
    }
}
