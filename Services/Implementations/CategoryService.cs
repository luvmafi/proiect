using Microsoft.EntityFrameworkCore;
using proiect.Data;
using proiect.Models;
using proiect.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace proiect.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task CreateAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return false; 
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return true; 
        }

        public async Task<IEnumerable<Category>> GetCategoriesWithProductsAsync() // one-to-many
        {
            return await _context.Categories
                .Include(c => c.Products)
                .ToListAsync();
        }

    }
}