using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryListService.Accessors
{
    public class itemAccessor : dbAccessor
    {
        public itemAccessor(SqlConnection connection) : base(connection)
        {
            //TODO
        }
    }
}
