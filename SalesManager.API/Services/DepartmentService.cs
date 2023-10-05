using Microsoft.EntityFrameworkCore;
using Models;
using SalesManager.API.Data;
using SalesManager.API.Interfaces;
using System.Data;

namespace SalesManager.API.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly SalesManagerContext _context;

        public DepartmentService(SalesManagerContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> GetDepartmentsAsync(string value)
        {
            IQueryable<Department> queryable = _context.Department
                                                       .AsNoTracking()
                                                       .AsSplitQuery()
                                                       .OrderByDescending(d => d.CreatedAt);

            if (!string.IsNullOrEmpty(value))
            {
                queryable = queryable.Where(d => d.DepartmentName.ToLower().Contains(value.ToLower()));
            }
            
            return await queryable.ToListAsync();
        }

        public async Task<Department> GetDepartmentByIdAsync(int departmentId)
        {
            return await _context.Department
                                 .AsNoTracking()
                                 .AsSplitQuery()
                                 .FirstOrDefaultAsync(d => d.Id == departmentId);
        }

        public async Task InsertAsync(Department department)
        {
            _context.Department.Add(department);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Department department)
        {
            try
            {
                _context.Entry(department).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DBConcurrencyException($"Erro ao atualizar: {e.Message}");
            }
        }

        public async Task DeleteAsync(Department department)
        {
            _context.Department.Remove(department);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int departmentId) => await _context.Department.AsNoTracking().AnyAsync(d => d.Id == departmentId);

        public async Task<bool> ExistsByNameAsync(string departmentName) => await _context.Department.AsNoTracking().AnyAsync(d => d.DepartmentName.ToLower() == departmentName.ToLower());

        public async Task<bool> ExistsByNameUpdateAsync(string departmentName, int departmentId) => await _context.Department.AsNoTracking().AnyAsync(d => d.DepartmentName.ToLower() == departmentName.ToLower() && d.Id != departmentId);
    }
}
