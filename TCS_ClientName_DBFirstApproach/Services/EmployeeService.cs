
using TCS_ClientName_DBFirstApproach.DBConnect;
namespace TCS_ClientName_DBFirstApproach
{
    public class EmployeeService : IEmployeeService
    {
        IEmployeeRepository _repository;
        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> AddEmployes(EmployeeDto empdetail)
        {
            Employee emp = new Employee();
            emp.Empid = empdetail.empid;
            emp.Empsalary = empdetail.empsalary;
            emp.Empname = empdetail.empname;
            var res = await _repository.AddEmployes(emp);
            return res;
        }

        public async Task<bool> DeleteEmployesById(int empid)
        {
            await _repository.DeleteEmployesById(empid);
            return true;
        }

        public async Task<EmployeeDto> GetEmployeeById(int empid)
        {
            var res = await _repository.GetEmployeeById(empid);
            EmployeeDto empdto = new EmployeeDto();
            empdto.empid = res.Empid;
            empdto.empname = res.Empname;
            empdto.empsalary = res.Empsalary;
            return empdto;
        }

        public async Task<List<EmployeeDto>> GetEmployees()
        {
            List<EmployeeDto> lstempdto = new List<EmployeeDto>();
            var res = await _repository.GetEmployees();
            foreach (Employee emp in res)
            {
                EmployeeDto empdto = new EmployeeDto();
                empdto.empid = emp.Empid;
                empdto.empsalary = emp.Empsalary;
                empdto.empname = emp.Empname;
                lstempdto.Add(empdto);

            }
            return lstempdto;
        }

        public async Task<bool> UpdateEmploye(EmployeeDto empdetail)
        {
            Employee emp = new Employee();
            emp.Empid = empdetail.empid;
            emp.Empsalary = empdetail.empsalary;
            emp.Empname = empdetail.empname;
            await _repository.UpdateEmploye(emp);
            return true;
        }
    }
}
