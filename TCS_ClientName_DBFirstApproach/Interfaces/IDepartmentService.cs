﻿namespace TCS_ClientName_DBFirstApproach
{
    public interface IDepartmentService
    {

        Task<List<DepartementDto>> GetDepartments();
        Task<DepartementDto> GetDepartmentById(int deptid);
        Task<int> AddDepartments(DepartementDto deptdetail);
        Task<bool> DeleteDepartmentById(int deptid);
        Task<bool> UpdateDepartment(DepartementDto deptdetail);
    }
}
