using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiForPryaniky
{
    public class CartListResponse
    {
        public IEnumerable<CartProduct> Products { get; set; }
        public int TotalPrice { get; set; }
    }
}
