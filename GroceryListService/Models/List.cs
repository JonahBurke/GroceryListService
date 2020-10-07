using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryListService.Models
{
    public class List
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public Dictionary<int, string> item { get; set; }
    }
}
