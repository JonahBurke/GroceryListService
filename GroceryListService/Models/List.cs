using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryListService.Models
{
    public class List
    {
        public int ListId { get; set; }

        public string Name { get; set; }

        public int UserId { get; set; }

        public virtual User User{ get; set;}
        public int Id { get; internal set; }
    }
}
