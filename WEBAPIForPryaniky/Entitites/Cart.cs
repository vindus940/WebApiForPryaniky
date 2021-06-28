using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiForPryaniky
{

    //we saved everything that we put in the basket
    public static class Cart
    {
        public static Dictionary <int, CartProduct> Products = new();
        public static object LockObject = new();

    }
}
