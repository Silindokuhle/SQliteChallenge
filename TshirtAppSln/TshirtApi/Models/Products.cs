using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TshirtApi.Models
{
    public class Products
    {
        
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public string T_shirtsize { get; set; }
        public string T_shirtcolor { get; set; }
        public DateTime Dateoforder { get; set; }
        public string ShippingAddress { get; set; }
    }
}
