using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Water.Models
{
    public interface ICharityRepository
    {
        IQueryable<Project> Projects { get; }
    }
}
