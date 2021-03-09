using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Water.Models.ViewModels
{
    public class ProjectList
    {
        public IEnumerable<Project> Projects { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string Type { get; set; }
    }
}
