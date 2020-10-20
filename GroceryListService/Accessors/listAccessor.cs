using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryListService.Accessors
{
    public class listAccessor : dbAccessor
    {
        public listAccessor(SqlConnection connection) : base(connection)
        {
            //TODO
        }
    }
}
