using InventoryApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.RepositortAbstracts
{
    public interface IProduct
    {
        bool Add(Product product);
        bool Update(Product product);
        bool Delete(int id);
        Product Find(int id);
        ICollection<Product> Search(ProductSearchType SearchType, string value);
    }
    public enum ProductSearchType
    {
        All = 0,
        CorporationId = 1,
        Title = 2,
        code = 3,
    }

}
