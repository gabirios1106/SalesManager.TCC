using Models;

namespace SalesManager.API.Interfaces
{
    public interface IDepartmentService
    {
        Task<List<Department>> GetDepartmentsAsync(string value);

        Task<Department> GetDepartmentByIdAsync(int departmentId);

        Task InsertAsync(Department department);

        Task UpdateAsync(Department department);

        Task DeleteAsync(Department department);

        Task<bool> ExistsAsync(int departmentId);

        Task<bool> ExistsByNameAsync(string departmentName);

        Task<bool> ExistsByNameUpdateAsync(string departmentName, int departmentId);
    }
}
