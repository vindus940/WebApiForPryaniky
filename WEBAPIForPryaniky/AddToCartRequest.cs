using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiForPryaniky
{
    public class AddToCartRequest
    {
        public int Id { get; set; }

        public int Count { get; set; }
    }
}
