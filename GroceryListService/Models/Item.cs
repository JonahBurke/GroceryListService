using System;
using System.ComponentModel.DataAnnotations;

namespace _GroceryListService.Model
{
    public class Item
    {

        public int ItemId { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public int ListId { get; set; }
        public int Id { get; internal set; }
    }
}
