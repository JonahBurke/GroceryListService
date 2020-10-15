using _GroceryListService.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryListService.Accessors
{
    public class UserAccessor : DbAccessor
    {
        public UserAccessor(SqlConnection connection) : base(connection)
        {
            //TODO
        }

        public void insertUser(ApplicationUser user)
        {

        }
    }
}
