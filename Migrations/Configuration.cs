namespace E_SHOPPING_WEB_SITE.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<E_SHOPPING_WEB_SITE.Entity.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "E_SHOPPING_WEB_SITE.Entity.DataContext";
        }

        protected override void Seed(E_SHOPPING_WEB_SITE.Entity.DataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
