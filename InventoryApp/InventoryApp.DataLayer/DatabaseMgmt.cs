using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.DataLayer
{
    public class DatabaseMgmt
    {
        public static async Task<bool> InitialDataBase()
        {
           return await Task<bool>.Run(() => {
                var dbcontext = new DataLayer.InventoryDBContext();
                return dbcontext.Database.CreateIfNotExists();
            });
        }
    }
}
