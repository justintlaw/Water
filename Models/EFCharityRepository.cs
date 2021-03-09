using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Water.Models
{
    public class EFCharityRepository : ICharityRepository
    {
        private CharityDbContext _context;
        public EFCharityRepository (CharityDbContext context)
        {
            _context = context;
        }

        public IQueryable<Project> Projects => _context.Projects;
    }
}
