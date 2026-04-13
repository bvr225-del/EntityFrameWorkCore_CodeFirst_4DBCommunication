using EntityFrameWorkCore_CodeFirst_4DBCommunication.DbConnect;
using EntityFrameWorkCore_CodeFirst_4DBCommunication.Entities;
using EntityFrameWorkCore_CodeFirst_4DBCommunication.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace EntityFrameWorkCore_CodeFirst_4DBCommunication.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly EmployeeContext _employeeContext;//one of the datasource.
        public DepartmentRepository(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }
        public async Task<int> AddDepartments(Departement deptdetail)
        {
            await _employeeContext.departements.AddAsync(deptdetail);//add the record by using addasync
            _employeeContext.SaveChanges();//it will commit/save the data perminently in table
            return 1;
        }

        public async Task<bool> DeleteDepartmentById(int deptid)
        {
            Departement rm = _employeeContext.departements.Where(e => e.deptid == deptid).SingleOrDefault();
            if (rm != null)
            {//Here Remove() method is used for removing the data from database.

                _employeeContext.departements.Remove(rm);
                _employeeContext.SaveChanges();//similart to commit
                return true;
            }
            else return false;
        }

        public async Task<Departement> GetDepartmentById(int deptid)
        {
            var rm = await _employeeContext.departements.Where(e => e.deptid == deptid).FirstOrDefaultAsync();
            var rm1 = await _employeeContext.departements.FirstOrDefaultAsync(e => e.deptid == deptid);

            if (rm == null)
                return null;
            else
                return rm;
        }

        public async Task<List<Departement>> GetDepartments()
        {
            var result = _employeeContext.departements.ToList();
            if (result.Count == 0)
            {
                return null;
            }
            else
            {
                return result;
            }
        }

        public async Task<bool> UpdateDepartment(Departement deptdetail)
        {
            _employeeContext.Update(deptdetail);
            await _employeeContext.SaveChangesAsync();
            return true;

        }
    }
}
