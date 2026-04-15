using EntityFrameWorkCore_CodeFirst_4DBCommunication.Dtos;
using EntityFrameWorkCore_CodeFirst_4DBCommunication.Entities;
using EntityFrameWorkCore_CodeFirst_4DBCommunication.Interfaces;
using EntityFrameWorkCore_CodeFirst_4DBCommunication.Migrations.Department;
using EntityFrameWorkCore_CodeFirst_4DBCommunication.Repositories;

namespace EntityFrameWorkCore_CodeFirst_4DBCommunication.Services
{
    public class DepartmentService123 : IDepartmentService123
    {
        private readonly IDepartmentRepository123 _departmentRepository123;
        public DepartmentService123(IDepartmentRepository123 departmentRepository123)
        {
            _departmentRepository123= departmentRepository123;
        }
        public async Task<int> AddDepartments(Department123Dto deptdetail)
        {
            //In future this code was replaced by automapper conncept.
            Department123 dept = new Department123();
            dept.DepartmentId = deptdetail.DepartmentId;
            dept.DepartmentName = deptdetail.DepartmentName;
            dept.DepartmentLocation = deptdetail.DepartmentLocation;
            dept.EmployeeName = deptdetail.EmployeeName;
            var res = await _departmentRepository123.AddDepartment(dept);
            return res;
        }

        public async Task<bool> DeleteDepartmentById(int deptid)
        {
            await _departmentRepository123.DeleteDepartmentById(deptid);
            return true;

        }

        public async Task<Department123Dto> GetDepartmentById(int deptid)
        {
            var res = await _departmentRepository123.GetDepartmentById(deptid);
            Department123Dto deptdto = new Department123Dto();
            deptdto.DepartmentId = res.DepartmentId;
            deptdto.DepartmentName = res.DepartmentName;
            deptdto.DepartmentLocation = res.DepartmentLocation;
            deptdto.EmployeeName = res.EmployeeName;
            return deptdto;

        }

        public async Task<List<Department123Dto>> GetDepartments()
        {
            List<Department123Dto> lstdeptdto = new List<Department123Dto>();
            var res = await _departmentRepository123.GetDepartments();
            foreach (Department123 dept in res)
            {
                Department123Dto deptDto = new Department123Dto();
                deptDto.DepartmentId = dept.DepartmentId;
                deptDto.DepartmentName = dept.DepartmentName;
                deptDto.DepartmentLocation = dept.DepartmentLocation;
                deptDto.EmployeeName = dept.EmployeeName;
                lstdeptdto.Add(deptDto);

            }
            return lstdeptdto;

        }

        public async Task<bool> UpdateDepartment(Department123Dto deptdetail)
        {
            Department123 dept = new Department123();
            dept.DepartmentId = deptdetail.DepartmentId;
            dept.DepartmentName = deptdetail.DepartmentName;
            dept.DepartmentLocation = deptdetail.DepartmentLocation;
            dept.EmployeeName = deptdetail.EmployeeName;
            await _departmentRepository123.UpdateDepartment(dept);
            return true;

        }
    }
}
