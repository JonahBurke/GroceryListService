using NuGet.Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryListService.Engines
{
    public class ItemEngine
    {
        int _id;
        string _name;
        int _quantity;

        public ItemEngine(int id, string name, int quantity)
        {
            _id = id;
            _name = name;
            _quantity = quantity;
        }

        public int getID()
        {
            return _id;
        }

        public string getName()
        {
            return _name;
        }

        public int getQuantity()
        {
            return _quantity;
        }
    }
}
