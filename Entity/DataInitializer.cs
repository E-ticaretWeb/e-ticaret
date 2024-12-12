using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.EnterpriseServices.Internal;
using E_SHOPPING_WEB_SITE.Entity;

namespace E_SHOPPING_WEB_SITE.Entity
{
    public class DataInitializer : CreateDatabaseIfNotExists<DataContext>

    {

        protected override void Seed(DataContext context)

        {

            var Categories = new List<Category>()
            {
                new Category() {Name="Hair Care" },
                new Category() {Name="Skin Care" },
                new Category() {Name="Nail Care" },



            };

            foreach (var item in Categories)
            {
                context.Categories.Add(item);
            }
            context.SaveChanges();

            ///
            var SubCategories = new List<SubCategory>()
            {

                new SubCategory() {Name="Shampoos", CategoryId=1 },
                new SubCategory() {Name="Hair Serums", CategoryId=1 },
                new SubCategory() {Name="Brush-Comb", CategoryId=1 },
                new SubCategory() {Name="Blow Dryers", CategoryId=1 },
                 new SubCategory() {Name="Box Dyes", CategoryId=1 },



                new SubCategory() {Name="Moisturizer", CategoryId=2 },
                new SubCategory() {Name="Face Cream", CategoryId=2 },
                 new SubCategory() {Name="Stain Remover", CategoryId=2 },


                 new SubCategory() {Name="Nail Polish", CategoryId=3 },
                new SubCategory() {Name="Nail Polish Remover", CategoryId=3 },
                new SubCategory() {Name="Manicure-Pedicure-Set", CategoryId=3 },


            };

            foreach (var item in SubCategories)
            {
                context.SubCategories.Add(item);
            }
            context.SaveChanges();

            var Products = new List<Product>()
            {
                new Product() {Name="Loreal Serie Expert Şamp. Silver 500ml.", Description="Boş.",Price=925.00, Stock=15, isApproved=true, SubCategoryId=1, Brand="L'oreal", Image="1.jpg"},
                new Product() {Name="Loreal Serie Expert Şamp. Absolut Repair 500ml.", Description="boş",Price=950.00, Stock=15, isApproved=true, SubCategoryId=1,Brand="L'oreal", Image="2.jpg"},
                new Product() {Name="Biocarin Bio Protein Saç Bakım Ürünü",  Description="boş",Price=225.00, Stock=15, isApproved=true, SubCategoryId=1, Brand = "Biocarin", Image= "3.jpg"},
                new Product() {Name="Element Silver Touch Şampuan 500 ML", Description="boş",Price=900.00, Stock=15, isApproved=true, SubCategoryId=1, Brand = "Element", Image = "4.jpg"},

                new Product() { Name = "DENEME.", Description = "Boş.", Price = 925.00, Stock = 15, isApproved = true, SubCategoryId = 8, Brand = "L'oreal", Image = "1.jpg" },
                new Product() { Name = "DENEME2", Description = "boş", Price = 950.00, Stock = 15, isApproved = true, SubCategoryId = 9, Brand = "L'oreal", Image = "2.jpg" },
                new Product() { Name = "DENEME3", Description = "boş", Price = 225.00, Stock = 15, isApproved = true, SubCategoryId = 4, Brand = "Biocarin", Image = "3.jpg" },
                new Product() { Name = "DENEME4", Description = "boş", Price = 900.00, Stock = 15, isApproved = true, SubCategoryId = 5, Brand = "Element", Image = "4.jpg" },


            };

            foreach (var item in Products)
            {
                context.Products.Add(item);
            }

            context.SaveChanges();
            base.Seed(context);
        }
    }
}
