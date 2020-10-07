using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroceryListService.Models;

namespace GroceryListService.Engine
{
    public class ListEngine
    {
        public void createlist(int id, string name, int Userid, Dictionary<int, string> Item)
        {
            List newlist = new List();
            newlist.Id = id;
            newlist.Name = name;
            newlist.UserId = Userid;
            newlist.item = Item;

        }
    }
}
