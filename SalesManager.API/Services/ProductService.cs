using Microsoft.EntityFrameworkCore;
using Models;
using SalesManager.API.Data;
using SalesManager.API.Interfaces;
using System.Data;

namespace SalesManager.API.Services
{
    public class ProductService : IProductService
    {
        private readonly SalesManagerContext _context;

        public ProductService(SalesManagerContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProductAsync(string value)
        {
            IQueryable<Product> queryable = _context.Product
                                                       .AsNoTracking()
                                                       .AsSplitQuery()
                                                       .OrderByDescending(d => d.CreatedAt);

            if (!string.IsNullOrEmpty(value))
            {
                queryable = queryable.Where(p => p.ProductName.ToLower().Contains(value.ToLower()));
            }

            return await queryable.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            return await _context.Product
                                 .AsNoTracking()
                                 .AsSplitQuery()
                                 .FirstOrDefaultAsync(p => p.Id == productId);
        }

        public async Task InsertAsync(Product product)
        {
            _context.Product.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            try
            {
                _context.Entry(product).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DBConcurrencyException($"Erro ao atualizar: {e.Message}");
            }
        }

        public async Task DeleteAsync(Product product)
        {
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int productId) => await _context.Product.AsNoTracking().AnyAsync(p => p.Id == productId);

        public async Task<bool> ExistsByNameAsync(string productName) => await _context.Product.AsNoTracking().AnyAsync(p => p.ProductName.ToLower() == productName.ToLower());

        public async Task<bool> ExistsByNameUpdateAsync(string productName, int productId) => await _context.Product.AsNoTracking().AnyAsync(d => d.ProductName.ToLower() == productName.ToLower() && d.Id != productId);
    }
}
