using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFCRUDoperation
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProductService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ProductService.svc or ProductService.svc.cs at the Solution Explorer and start debugging.
    public class ProductService : IProductService
    {


        public List<Product> FindAll()
        {
            using (Test4Entities db=new Test4Entities())
            {
                return db.ProductEntities.Select(x => new Product
                {
                    ProductId = x.ProductId,
                    Name = x.Name,

                    Price = x.Price,
                    Quantity = x.Quantity

                }).ToList();
            }
            

        }

        public Product Find(string id)
        {
            using (Test4Entities db = new Test4Entities())
            {
                int nId = Convert.ToInt32(id);
                return db.ProductEntities.Where(p=>p.ProductId==nId).Select(x => new Product
                {
                    ProductId = x.ProductId,
                    Name = x.Name,

                    Price = x.Price,
                    Quantity = x.Quantity

                }).First();
            }
            

        }

        public bool Create(Product product)
        {
            using (Test4Entities db = new Test4Entities())
            {
                try
                {
                    ProductEntity pe = new ProductEntity();

                    ////pe.ProductId = product.ProductId;
                    pe.Name = product.Name;
                    pe.Price = product.Price;
                    pe.Quantity = product.Quantity;
                    db.ProductEntities.Add(pe);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }

            }
        }

        public bool Edit(Product product)
        {
            using (Test4Entities db = new Test4Entities())
            {
                int id = Convert.ToInt32(product.ProductId);
                try
                {
                    ProductEntity pe = db.ProductEntities.Single(p => p.ProductId == id);

                  
                    pe.Name = product.Name;
                    pe.Price = product.Price;
                    pe.Quantity = product.Quantity;
                    
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    
                    return false;
                }
               
            }
        }

        public bool Delete(Product product)
        {
            using (Test4Entities db = new Test4Entities())
            {
                try
                {
                    ProductEntity pe = db.ProductEntities.Single(p => p.ProductId == product.ProductId);


                    db.ProductEntities.Remove(pe);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }

            }
        }
    }
}
