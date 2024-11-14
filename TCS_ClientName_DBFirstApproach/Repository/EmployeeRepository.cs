
using Microsoft.EntityFrameworkCore;
using TCS_ClientName_DBFirstApproach.DBConnect;


namespace TCS_ClientName_DBFirstApproach
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly TcsClinetNameCodeFirstApproachContext _tcsClinetNameCodeFirstApproachContext;
        public EmployeeRepository(TcsClinetNameCodeFirstApproachContext tcsClinetNameCodeFirstApproachContext)
        {
            _tcsClinetNameCodeFirstApproachContext = tcsClinetNameCodeFirstApproachContext;
        }
        public async Task<int> AddEmployes(Employee empdetail)
        {
            await _tcsClinetNameCodeFirstApproachContext.Employees.AddAsync(empdetail);//add the record by using addasync
            _tcsClinetNameCodeFirstApproachContext.SaveChanges();//it will commit/save the data perminently in table
            return 1;
        }
        public async Task<bool> DeleteEmployesById(int empid)
        {

            Employee rm = _tcsClinetNameCodeFirstApproachContext.Employees.SingleOrDefault(e => e.Empid == empid);
            if (rm != null)
            {//Here Remove() method is used for removing the data from database.

                _tcsClinetNameCodeFirstApproachContext.Employees.Remove(rm);
                _tcsClinetNameCodeFirstApproachContext.SaveChanges();
                return true;
            }
            else return false;
        }
        public async Task<Employee> GetEmployeeById(int empid)
        {
            var rm = await _tcsClinetNameCodeFirstApproachContext.Employees.Where(e => e.Empid == empid).FirstOrDefaultAsync();

            if (rm == null)
                return null;
            else
                return rm;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            var result = _tcsClinetNameCodeFirstApproachContext.Employees.ToList();
            if (result.Count == 0)
            {
                return null;
            }
            else
            {
                return result;
            }
        }

        public async Task<bool> UpdateEmploye(Employee empdetail)
        {

            _tcsClinetNameCodeFirstApproachContext.Update(empdetail);
            await _tcsClinetNameCodeFirstApproachContext.SaveChangesAsync();
            return true;

        }
    }
}
