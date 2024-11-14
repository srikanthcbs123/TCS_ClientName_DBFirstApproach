using TCS_ClientName_DBFirstApproach.DBConnect;

namespace TCS_ClientName_DBFirstApproach
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
