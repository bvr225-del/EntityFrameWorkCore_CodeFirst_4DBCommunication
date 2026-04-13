using EntityFrameWorkCore_CodeFirst_4DBCommunication.Entities;

namespace EntityFrameWorkCore_CodeFirst_4DBCommunication.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<List<Departement>> GetDepartments();
        Task<Departement> GetDepartmentById(int deptid);
        Task<int> AddDepartments(Departement deptdetail);
        Task<bool> DeleteDepartmentById(int deptid);
        Task<bool> UpdateDepartment(Departement deptdetail);

    }
}
