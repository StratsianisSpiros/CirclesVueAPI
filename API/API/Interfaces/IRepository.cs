using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IRepository
    {
        Task<ICollection<Circle>> GetCirclesByUniqueCode(string uniqueCode);
        Task<ICollection<string>> GetAllDatabaseUniqueCodes();
        Task<bool> CodeExists(string uniqueCode);
        Task<bool> StoreCircle(Circle circle);
        
    }
}
