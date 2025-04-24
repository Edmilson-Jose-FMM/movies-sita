using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesSita.Domain.Entities
{
    public class PagedItens
    {
        public int Page { get; set; }
        public int PerPage { get; set; }
        public IEnumerable<Movies> Movies { get; set; }
    }
}
