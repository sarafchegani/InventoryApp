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
               try
               {
                   var dbcontext = new DataLayer.InventoryDBContext();
                   dbcontext.Database.Initialize(false);
                   return true;
               }
               catch 
               {
                   return false;
               }
               
            });
        }
    }
}
