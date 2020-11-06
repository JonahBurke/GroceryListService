using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using GroceryListService.Models;
using GroceryListService.Accessors;

namespace _GroceryListService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ItemAccessor _accessor;

        public ItemsController(ItemAccessor accessor)
        {
            _accessor = accessor;
        }

        // GET: api/Items
        [HttpGet]
        public List<Item> GetItem(List list)
        {
            return _accessor.SelectAllItems(list);
        }

        // GET: api/Items/5
        [HttpGet("{id}")]
        public Item GetItem(int id)
        {
            return _accessor.SelectItem(id);
        }

        // PUT: api/Items/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public void PutItem(int id, Item item)
        {
            if (id != item.Id)
            {
                return;
            }

            _accessor.UpdateItem(item);
        }

        // POST: api/Items
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public void PostItem(Item item)
        {
            _accessor.InsertItem(item);
        }

        // DELETE: api/Items/5
        [HttpDelete("{id}")]
        public void DeleteItem(int id)
        {
            _accessor.RemoveItem(id);
        }

        private bool ItemExists(int id)
        {
            return _accessor.ItemExists(id);
        }
    }
}
