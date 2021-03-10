using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Water.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        public void AddItem (Project proj, int qty)
        {
            CartLine line = Lines
                .Where(p => p.Project.ProjectId == proj.ProjectId)
                .FirstOrDefault();

            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Project = proj,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }

        public void RemoveLine(Project proj) =>
            Lines.RemoveAll(item => item.Project.ProjectId == proj.ProjectId);

        public void Clear() => Lines.Clear();

        public decimal ComputeTotalSum() => Lines.Sum(item => 25 * item.Quantity); // price is hard-coded
        }

        public class CartLine
        {
            public int CartLineID { get; set; }
            public Project Project { get; set; }
            public int Quantity { get; set; }
        }
}
