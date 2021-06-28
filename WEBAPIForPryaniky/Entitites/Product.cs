using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebApiForPryaniky
{
    public class Product
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int Price { get; set; }


        //Как отдельно вынести этот Dictionary ?
        public static Dictionary<int, Product> AllProducts = new()
        {
            {

                //static список
                1,
                new Product
                {
                    id = 1,
                    Name = "sobaka",
                    Description = "good",
                    Price = 1488,
                }
            },
            {
                2,
                new Product
                {
                    id = 2,
                    Name = "Kot",
                    Description = "bad",
                    Price = 1337,
                }
            },
            {
                3,
                new Product
                {
                    id = 3,
                    Name = "StivJobs",
                    Description = "Angry",
                    Price = 228,
                }
            },
        };
    }
}
