using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleSearch.Models
{
    public class SearchGoogleDTO
    {
        public List<ResultGoogle> items{ get; set; }
        public List<PaginationGoogle> paginations { get; set; }

    }
}
