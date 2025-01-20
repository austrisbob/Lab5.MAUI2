using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab5.MAUIData.Models;

namespace Lab5.MAUIData.Interfaces
{
    public interface IDataRepository
    {
        Task<Department[]> GetDepartmentsAsync();

        Task<Employee[]> GetDepartmentEmployeesAsync(int departmentId);

        Task DeleteEmployee(int departmentId, int employeeId);
        Task UpdateDepartmentAsync(Department department);

    }
}
