using EntityFrameWorkCore_CodeFirst_4DBCommunication.Dtos;

namespace EntityFrameWorkCore_CodeFirst_4DBCommunication.Interfaces
{
    public interface IDepartmentService123
    {
        Task<List<Department123Dto>> GetDepartments();
        Task<Department123Dto> GetDepartmentById(int deptid);
        Task<int> AddDepartments(Department123Dto deptdetail);
        Task<bool> DeleteDepartmentById(int deptid);
        Task<bool> UpdateDepartment(Department123Dto deptdetail);

    }
}
