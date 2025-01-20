using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab5.MAUIData.Interfaces;
using Lab5.MAUIData.Models;


namespace Lab5.MAUIData.Services
{
    public class ApiDataRepository : IDataRepository
    {
        private readonly IDepartmentApiClient _departmentApiClient;

        public ApiDataRepository(IDepartmentApiClient apiClient)
        {
            _departmentApiClient = apiClient;
        }

        public async Task DeleteGrade(int departmentId, int employeeId)
        {
            await _departmentApiClient
                .DeleteItemAsync($"{DepartmentApiConstants.DepartmentsUrl}/{departmentId}/{DepartmentApiConstants.EmployeesUrl}/{employeeId}");
        }

        public async Task<Employee[]> GetDepartmentEmployeesAsync(int departmentId)
        {
            var result = await _departmentApiClient
                .GetItemsAsync<Employee>($"{DepartmentApiConstants.DepartmentsUrl}/{departmentId}/{DepartmentApiConstants.EmployeesUrl}");
            return result;
        }

        public async Task<Department[]> GetDepartmentsAsync()
        {
            var result = await _departmentApiClient.GetItemsAsync<Department>(DepartmentApiConstants.DepartmentsUrl);
            return result;
        }

        public async Task UpdateDepartmentAsync(Department department)
        {
            await _departmentApiClient.UpdateItem<Department>($"{DepartmentApiConstants.DepartmentsUrl}/{department.Id}", department);
        }
        //fix
        Task IDataRepository.DeleteEmployee(int departmentId, int employeeId)
        {
            throw new NotImplementedException();
        }
    }
}

