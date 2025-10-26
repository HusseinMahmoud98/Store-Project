using Microsoft.EntityFrameworkCore;
using Store.Domain.Contract;
using Store.Persistence.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Persistance
{
    public class DbIntitializer : IDbInitializer
    {
        private readonly StoreDbContext _context;

        public DbIntitializer(StoreDbContext context)
        {
            _context = context;
        }

        public async Task InitializeAsync()
        {
            //Create Database if not exists

            //Update Database
            if (_context.Database.GetPendingMigrationsAsync().GetAwaiter().GetResult().Any())
            {
                await _context.Database.MigrateAsync();
            }

            //Data Seeding
            //ProductBrand 
            // 1. Read All Data From Json File
            File.ReadAllTextAsync(@"C:\Users\hp\Desktop\Store Web Api2\Store\Store.Persistence\Data\DataSeeding\brands.json"); //
            //ProductType C:\Users\hp\Desktop\Store Web Api2\Store\Store.Persistence\Data\DataSeeding\
            //Product


        }
    }
}
