using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace TshirtApp.Models
{
    class Tees
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }   
        public string T_shirtsize { get; set; }
        public string T_shirtcolor { get; set; }
        public string Dateoforder { get; set; }
        public string shippingaddress{ get; set; }
    }
}
