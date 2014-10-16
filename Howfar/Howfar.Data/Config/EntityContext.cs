using System.Collections.Generic;
using System.Data.Entity;
using Howfar.Model;

namespace Howfar.Data.Config
{
    public class EntityContext : DbContext
    {
        public EntityContext()
            : base("Dafault")
        {

            Database.SetInitializer<EntityContext>(new EntityContextInitializer());

            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<EntityContext, Howfar.Data.Migrations.Configuration>("Dafault"));
            //Database.SetInitializer<EntityContext>(new CreateDatabaseIfNotExists<EntityContext>());
            //Database.SetInitializer<EntityContext>(null);
        }

        public DbSet<City> Citys { get; set; }
    }
}
