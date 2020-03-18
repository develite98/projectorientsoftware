using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreManager.Models;

namespace StoreManager.Repository
{
    public interface iProductsRepository
    {
        Task Add(Products products);

        List<Products> GetAll();

    }

    public class ProductsRepository : iProductsRepository
    {
        private StoreManagerDbContext Db;

        public ProductsRepository(StoreManagerDbContext _Db)
        {
            this.Db = _Db;
        }

        public async Task Add(Products products)
        {
            Db.Add(products);
            await Db.SaveChangesAsync();
        }

        public List<Products> GetAll()
        {
            List<Products> temp = Db.Products.ToList();
            return temp;
        }
    }
}
