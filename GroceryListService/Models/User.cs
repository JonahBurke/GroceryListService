namespace GroceryListService.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } // This might need to be changed for security reasons, but for now, we'll be okay
        public string Nickname { get; set; }
    }
}
