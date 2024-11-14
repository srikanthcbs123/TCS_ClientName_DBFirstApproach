using Microsoft.EntityFrameworkCore;
using TCS_ClientName_DBFirstApproach.DBConnect;


namespace TCS_ClientName_DBFirstApproach
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly TcsClinetNameCodeFirstApproachContext _tcsClinetNameCodeFirstApproachContext;
        public DepartmentRepository(TcsClinetNameCodeFirstApproachContext tcsClinetNameCodeFirstApproachContext)
        {
            _tcsClinetNameCodeFirstApproachContext = tcsClinetNameCodeFirstApproachContext;
        }
        public async Task<int> AddDepartments(Departement deptdetail)
        {
            await _tcsClinetNameCodeFirstApproachContext.Departements.AddAsync(deptdetail);//add the record by using addasync
            _tcsClinetNameCodeFirstApproachContext.SaveChanges();//it will commit/save the data perminently in table
            return 1;
        }

        public async Task<bool> DeleteDepartmentById(int deptid)
        {
            Departement rm = _tcsClinetNameCodeFirstApproachContext.Departements.SingleOrDefault(e => e.Deptid == deptid);
            if (rm != null)
            {//Here Remove() method is used for removing the data from database.

                _tcsClinetNameCodeFirstApproachContext.Departements.Remove(rm);
                _tcsClinetNameCodeFirstApproachContext.SaveChanges();
                return true;
            }
            else return false;
        }

        public async Task<Departement> GetDepartmentById(int deptid)
        {
            var rm = await _tcsClinetNameCodeFirstApproachContext.Departements.Where(e => e.Deptid == deptid).FirstOrDefaultAsync();

            if (rm == null)
                return null;
            else
                return rm;
        }

        public async Task<List<Departement>> GetDepartments()
        {
            var result = _tcsClinetNameCodeFirstApproachContext.Departements.ToList();
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
            _tcsClinetNameCodeFirstApproachContext.Update(deptdetail);
            await _tcsClinetNameCodeFirstApproachContext.SaveChangesAsync();
            return true;

        }
    }
}
