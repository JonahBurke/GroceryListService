namespace GroceryListService.Models
{
    public class Item
    {
        public int Id { get; set; }
        public int ListId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}