using EntityFrameWorkCore_CodeFirst_4DBCommunication.Dtos;
using EntityFrameWorkCore_CodeFirst_4DBCommunication.Entities;
using EntityFrameWorkCore_CodeFirst_4DBCommunication.Interfaces;

namespace EntityFrameWorkCore_CodeFirst_4DBCommunication.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _repository;
        //constructor injection
        public DepartmentService(IDepartmentRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> AddDepartments(DepartementDto deptdetail)
        {
            //In future this code was replaced by automapper conncept.
            Departement dept = new Departement();
            dept.deptid = deptdetail.deptid;
            dept.deptname = deptdetail.deptname;
            dept.deptlocation = deptdetail.deptlocation;
            var res = await _repository.AddDepartments(dept);
            return res;
        }

        public async Task<bool> DeleteDepartmentById(int deptid)
        {
            await _repository.DeleteDepartmentById(deptid);
            return true;
        }

        public async Task<DepartementDto> GetDepartmentById(int deptid)
        {
            var res = await _repository.GetDepartmentById(deptid);
            DepartementDto deptdto = new DepartementDto();
            deptdto.deptid = res.deptid;
            deptdto.deptname = res.deptname;
            deptdto.deptlocation = res.deptlocation;
            return deptdto;
        }

        public async Task<List<DepartementDto>> GetDepartments()
        {
            List<DepartementDto> lstdeptdto = new List<DepartementDto>();
            var res = await _repository.GetDepartments();
            foreach (Departement dept in res)
            {
                DepartementDto deptDto = new DepartementDto();
                deptDto.deptid = dept.deptid;
                deptDto.deptname = dept.deptname;
                deptDto.deptlocation = dept.deptlocation;
                lstdeptdto.Add(deptDto);

            }
            return lstdeptdto;
        }

        public async Task<bool> UpdateDepartment(DepartementDto deptdetail)
        {
            Departement dept = new Departement();
            dept.deptid = deptdetail.deptid;
            dept.deptname = deptdetail.deptname;
            dept.deptlocation = deptdetail.deptlocation;
            await _repository.UpdateDepartment(dept);
            return true;
        }
    }
}
