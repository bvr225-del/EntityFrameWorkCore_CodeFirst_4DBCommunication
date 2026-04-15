using EntityFrameWorkCore_CodeFirst_4DBCommunication.DbConnect;
using EntityFrameWorkCore_CodeFirst_4DBCommunication.Entities;
using EntityFrameWorkCore_CodeFirst_4DBCommunication.Interfaces;
using EntityFrameWorkCore_CodeFirst_4DBCommunication.Migrations.Department;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameWorkCore_CodeFirst_4DBCommunication.Repositories
{
    public class DepartmentRepository123 : IDepartmentRepository123
    {
        private readonly DepartmentContext _departmentContext;
        

        public DepartmentRepository123(DepartmentContext departmentContext)
        {
            _departmentContext= departmentContext;
        }
        public async Task<int> AddDepartment(Department123 departmentdetail)
        {
            await _departmentContext.Department123.AddAsync(departmentdetail);
            _departmentContext.SaveChanges();
            return 1;
        }

        public async Task<bool> DeleteDepartmentById(int departmentid)
        {
            var result= await _departmentContext.Department123.Where(a=>a.DepartmentId==departmentid).FirstOrDefaultAsync();
            if (result == null)
            {

                return false;
            }
            else
            {//Remove() metho is used to remove the data.
                _departmentContext.Department123.Remove(result);
                _departmentContext.SaveChanges() ;
              
                return true;
            }

        }

        public async Task<Department123> GetDepartmentById(int departmentid)
        {
            var result = await _departmentContext.Department123.Where(a=>a.DepartmentId == departmentid).FirstOrDefaultAsync();
            if (result == null)
            {//if result having no data i am returning null here.null means nothing.
                return null;
            }
            else
            {
                return result;
            }

        }

        public async Task<List<Department123>> GetDepartments()
        {
            var result = await _departmentContext.Department123.ToListAsync();
            if (result.Count == 0)
            {
                return null;
            }
            else
            {
                return result;
            }

        }

        public async Task<bool> UpdateDepartment(Department123 departmentdetail)
        {
            _departmentContext.Department123.Update(departmentdetail);
            await _departmentContext.SaveChangesAsync();
            return true;

        }
    }
}
