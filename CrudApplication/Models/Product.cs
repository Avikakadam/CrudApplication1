using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApplication.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CatagoryId { get; set; }
        public string CategoryName { get; set; }

        internal static int Count()
        {
            throw new NotImplementedException();
        }
    }
}
