using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TshirtApi.Data
{
    using System;
    using System.Linq;
    using global::TshirtApi.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
   

    namespace TshirtApi.Data
    {
        public static class SeedData
        {
            public static void Initialize(ProductsContext context)
            {
                if (!context.Productss.Any())
                {
                    context.Productss.AddRange(
                        new Products
                        {
                            Name = "Squeaky Bone",
                            Gender = "Male",
                            T_shirtcolor = "red",
                            T_shirtsize = "M",
                        },
                        new Products
                        {
                            Name = "Knotted Rope",
                            Gender = "Female",
                            T_shirtcolor = "green",
                            T_shirtsize = "S",
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}
