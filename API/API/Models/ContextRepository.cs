using API.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class ContextRepository : IRepository
    {
        private readonly AppDBContext _context;

        public ContextRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<bool> CodeExists(string uniqueCode)
        {
            return await _context.Circles.AnyAsync(c => c.UniqueCode == uniqueCode);
        }

        public async Task<ICollection<string>> GetAllDatabaseUniqueCodes()
        {
            var codes = _context.Circles.Select(c => c.UniqueCode).Distinct();
            return await codes.ToListAsync();
        }

        public async Task<ICollection<Circle>> GetCirclesByUniqueCode(string uniqueCode)
        {
            return await _context.Circles.Where(c => c.UniqueCode == uniqueCode)
                .OrderByDescending(c => c.Diameter).ToListAsync();
        }

        public async Task<bool> StoreCircle(Circle circle)
        {
            _context.Circles.Add(circle);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
