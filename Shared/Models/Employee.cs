using System.Collections.Generic;

namespace Shared.Models
{
    public class Employee : BaseModel
    {
        // ======================================= //
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Picture { get; set; }
        // ======================================= //
        //        Navigation Properties
        // ======================================= //
        public virtual IEnumerable<EmployeeTask> Tasks { get; set; }
        // ======================================= //
        public Employee() : base() { }
        public Employee(string firstName, string lastName, string gender, string picture, string title, string description) : base(title, description)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Gender = gender;
            this.Picture = picture;
        }
    }
}