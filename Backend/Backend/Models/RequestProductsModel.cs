using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services
{
    public class RequestProductsModel
    {
        public int CurrentPage { get; set; }
        public int ProductsPageCount { get; set; }
        public string OptionalFilterName { get; set; }
        public long OptionalFilterId { get; set; }
    }
}
