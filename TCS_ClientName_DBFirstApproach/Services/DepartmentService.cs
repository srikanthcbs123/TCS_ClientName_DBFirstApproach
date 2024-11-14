

using TCS_ClientName_DBFirstApproach.DBConnect;

namespace TCS_ClientName_DBFirstApproach
{
    public class DepartmentService : IDepartmentService
    {
        private  readonly IDepartmentRepository _repository;
        //constructor injection
        public DepartmentService(IDepartmentRepository repository)
        {
            _repository= repository;
        }
        public async Task<int> AddDepartments(DepartementDto deptdetail)
        {
            //In future this code was replaced by automapper conncept.
            Departement dept = new Departement();
            dept.Deptid = deptdetail.deptid;
            dept.Deptname=deptdetail.deptname;
            dept.Deptlocation = deptdetail.deptlocation;
            var res = await _repository.AddDepartments(dept);
            return res;
        }

        public async  Task<bool> DeleteDepartmentById(int deptid)
        {
            await _repository.DeleteDepartmentById(deptid);
            return true;
        }

        public  async Task<DepartementDto> GetDepartmentById(int deptid)
        {
            var res = await _repository.GetDepartmentById(deptid);
            DepartementDto deptdto = new DepartementDto();
            deptdto.deptid = res.Deptid;
            deptdto.deptname = res.Deptname;
            deptdto.deptlocation = res.Deptlocation;
            return deptdto;
        }

        public async  Task<List<DepartementDto>> GetDepartments()
        {
            List<DepartementDto> lstdeptdto = new List<DepartementDto>();
            var res = await _repository.GetDepartments();
            foreach (Departement dept in res)
            {
                DepartementDto deptDto = new DepartementDto();
                deptDto.deptid = dept.Deptid;
                deptDto.deptname = dept.Deptname;
                deptDto.deptlocation = dept.Deptlocation;
                lstdeptdto.Add(deptDto);

            }
            return lstdeptdto;
        }

        public async Task<bool> UpdateDepartment(DepartementDto deptdetail)
        {
            Departement dept = new Departement();
            dept.Deptid = deptdetail.deptid;
            dept.Deptname = deptdetail.deptname;
            dept.Deptlocation = deptdetail.deptlocation;
            await _repository.UpdateDepartment(dept);
            return true;
        }
    }
}
