using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp
{
    public class DatabaseTools
    {
        public static int GetUserID {
            get {
                var contaxt = new DataLayer.InventoryDBContext();
                return contaxt.Users.FirstOrDefault(p => p.Username == System.Threading.Thread.CurrentPrincipal.Identity.Name).UserId;
            }
        }
    }
}
