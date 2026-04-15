using EntityFrameWorkCore_CodeFirst_4DBCommunication.Entities;
using EntityFrameWorkCore_CodeFirst_4DBCommunication.Migrations.Department;

namespace EntityFrameWorkCore_CodeFirst_4DBCommunication.Interfaces
{
    public interface IDepartmentRepository123
    {
        Task<List<Department123>> GetDepartments();
        Task<Department123> GetDepartmentById(int departmentid);
        Task<int> AddDepartment(Department123 departmentdetail);
        Task<bool> DeleteDepartmentById(int departmentid);
        Task<bool> UpdateDepartment(Department123 departmentdetail);

    }
}
