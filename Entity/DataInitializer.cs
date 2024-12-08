using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace E_SHOPPING_WEB_SITE.Entity
{
    public class DataInitializer:DropCreateDatabaseIfModelChanges<DataContext>

    {

        protected override void Seed(DataContext context)

        {

           var categories = new List<Category>()
            {
                new Category() {Name="Hair Care" },
                new Category() {Name="Curling Irons and Straighteners" },
                new Category() {Name="Brushes" },
                new Category() {Name="Box Dyes" },


            };

            foreach(var item in categories)
            {
                context.Categories.Add(item);
            }
            context.SaveChanges();


            var Products = new List<Product>()
            {
                new Product() {Name="Loreal Serie Expert Şamp. Silver 500ml.", Description="Gri ve beyaz saçlar için parlaklık veren şampuan:\r\n\r\nGloss Protect Sistemi: Amino asitler ve sararmaya karşı etkili madde sayesinde\r\n\r\nsaçın iç yapısındaki keratinin sararmasını önler, saç telini yumuşatır.\r\n\r\nSilver Şampuan: Gri ve beyaz saçların sararmasını önleyerek saçlara yeniden ışıltı\r\n\r\nve canlılık verir. Bu sayede saflığını ve doğal parlaklığını kazanan yumuşak saçlar elde edilir.",
                    Price=925.00, Stock=15, isApproved=true, CategoryId=1},
                new Product() {Name="Loreal Serie Expert Şamp. Absolut Repair 500ml.", Description="LOREAL SERIE EXPERT ŞAMP. ABSOLUT REPAIR 500ML\r\n\r\nAşırı yıpranmış saçlar için onarıcı şampuan:\r\n\r\nSaç telini yeniden yapılandırmak ve korumak için formüle edilmiştir.\r\n\r\nSaçlar parlaklığını ve gücünü yeniden kazanır ve canlanır.\r\n\r\nNeofibrineTM: Saç için parlaklığı artırıcı bir birleşenin BioMimetic Ceramide, Silikonlar\r\n\r\nve UV filtresinin eşsiz birleşimi.",
                    Price=950.00, Stock=15, isApproved=true, CategoryId=1},
                new Product() {Name="Biocarin Bio Protein Saç Bakım Ürünü", Description="Gri ve beyaz saçlar için parlaklık veren şampuan:\r\n\r\nGloss Protect Sistemi: Amino asitler ve sararmaya karşı etkili madde sayesinde\r\n\r\nsaçın iç yapısındaki keratinin sararmasını önler, saç telini yumuşatır.\r\n\r\nSilver Şampuan: Gri ve beyaz saçların sararmasını önleyerek saçlara yeniden ışıltı\r\n\r\nve canlılık verir. Bu sayede saflığını ve doğal parlaklığını kazanan yumuşak saçlar elde edilir.",
                    Price=225.00, Stock=15, isApproved=true, CategoryId=1},
                new Product() {Name="Loreal Serie Expert Şamp. Silver 500ml.", Description="Gri ve beyaz saçlar için parlaklık veren şampuan:\r\n\r\nGloss Protect Sistemi: Amino asitler ve sararmaya karşı etkili madde sayesinde\r\n\r\nsaçın iç yapısındaki keratinin sararmasını önler, saç telini yumuşatır.\r\n\r\nSilver Şampuan: Gri ve beyaz saçların sararmasını önleyerek saçlara yeniden ışıltı\r\n\r\nve canlılık verir. Bu sayede saflığını ve doğal parlaklığını kazanan yumuşak saçlar elde edilir.",
                    Price=900.00, Stock=15, isApproved=true, CategoryId=1},

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