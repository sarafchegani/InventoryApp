using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryApp.Entities;
using InventoryApp.RepositortAbstracts;

namespace InventoryApp.Repositories
{
    public class ProductRepository : IProduct
    {
        public bool Add(Product product)
        {
            try
            {
                var contaxt = new DataLayer.InventoryDBContext();
                product.CreatedDate = DateTime.Now;
                product.CreatedByUserId = DatabaseTools.GetUserID;
                contaxt.Products.Add(product);
                contaxt.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var contaxt = new DataLayer.InventoryDBContext();
                var product = contaxt.Products.Where(p => p.ProductId == id).FirstOrDefault();
                product.Deleted = true;
                product.DeletedDate = DateTime.Now;
                product.DeletedByUserId = DatabaseTools.GetUserID;
                contaxt.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Product Find(int id)
        {
            try
            {
                var contaxt = new DataLayer.InventoryDBContext();
                return contaxt.Products.Where(p => p.ProductId == id).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }

        public ICollection<Product> Search(ProductSearchType SearchType, string value)
        {
            List<Product> List = new List<Product>();
            var contaxt = new DataLayer.InventoryDBContext();
            switch (SearchType)
            {
                case ProductSearchType.All:
                    {
                        //search by title
                        var _product = contaxt.Products.Where(p => p.Title.Contains(value)).ToList();
                        List.AddRange(_product);

                        //search by id
                        int id = 0;
                        if (int.TryParse(value, out id))
                        {
                            _product = contaxt.Products.Where(p => p.ProductId == id).ToList();
                            List.AddRange(_product);
                        }
                        //search by code
                        int code = 0;
                        if (int.TryParse(value, out code))
                        {
                            _product = contaxt.Products.Where(p => p.Code == code).ToList();
                            List.AddRange(_product);
                        }
                        return List;
                    }
                case ProductSearchType.CorporationId:
                    {
                        //search by id
                        int id = 0;
                        if (int.TryParse(value, out id))
                        {
                            var _product = contaxt.Products.Where(p => p.ProductId == id).ToList();
                            List.AddRange(_product);
                        }
                        return List;
                    }
                case ProductSearchType.Title:
                    {
                        //search by title
                        var _product = contaxt.Products.Where(p => p.Title.Contains(value)).ToList();
                        List.AddRange(_product);
                        return List;
                    }
               
                case ProductSearchType.code:
                    {
                        int code = 0;
                        if (int.TryParse(value, out code))
                        {
                           var  _product = contaxt.Products.Where(p => p.Code == code).ToList();
                            List.AddRange(_product);
                        }
                        return List;
                    }
                default:
                    {
                        return null;
                    }
            }
        }

        public bool Update(Product product)
        {
            try
            {
                var contaxt = new DataLayer.InventoryDBContext();
                var _product = contaxt.Products.Where(p => p.ProductId == product.ProductId).FirstOrDefault();
                _product = product;
                _product.ChangedDate = DateTime.Now;
                _product.ChangedByUserId = DatabaseTools.GetUserID;
                contaxt.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
