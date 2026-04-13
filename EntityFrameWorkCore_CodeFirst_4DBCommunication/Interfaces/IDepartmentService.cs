using EntityFrameWorkCore_CodeFirst_4DBCommunication.Dtos;

namespace EntityFrameWorkCore_CodeFirst_4DBCommunication.Interfaces
{
    public interface IDepartmentService
    {
        Task<List<DepartementDto>> GetDepartments();
        Task<DepartementDto> GetDepartmentById(int deptid);
        Task<int> AddDepartments(DepartementDto deptdetail);
        Task<bool> DeleteDepartmentById(int deptid);
        Task<bool> UpdateDepartment(DepartementDto deptdetail);

    }
}
