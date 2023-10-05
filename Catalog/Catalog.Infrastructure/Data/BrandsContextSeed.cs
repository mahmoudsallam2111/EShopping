using Catalog.Core.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Data
{
    public static class BrandsContextSeed
    {
        public static void Seed(IMongoCollection<ProductBrand> brandCollection)
        {
           bool BrandCheck = brandCollection.Find(b=> true).Any();

            string path = Path.Combine("Data", "SeedData", "brands.json");   // get path

            if (!BrandCheck)
            {
                string brandsData = File.ReadAllText(path);         // read the data from path
                var Brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);   // deserialize the data

                if (Brands !=null)
                {
                    foreach (var item in Brands)
                    {
                        brandCollection.InsertOneAsync(item);             
                    }
                }
                
            }
        }
    }
}
