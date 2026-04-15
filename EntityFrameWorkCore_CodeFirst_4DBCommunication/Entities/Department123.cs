using System.ComponentModel.DataAnnotations;

namespace EntityFrameWorkCore_CodeFirst_4DBCommunication.Entities
{
    public class Department123
    {
        [Key]
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        public string DepartmentLocation { get; set; }

        public string EmployeeName { get; set; }

    }
}
