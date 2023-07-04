namespace EmployeeRestAPI.Models
{
    public  class Employee
    {
        public int EmployeeCode { get; set; } 
        public string? Title { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? IDNumber { get; set; }
        public string? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? ContactNumber { get; set; }
        public string? EmailAddress { get; set; }
        public int DepartmentID { get; set; }
    }
}
