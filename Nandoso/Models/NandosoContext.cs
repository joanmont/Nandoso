using Special.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Nandoso.Models
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class NandosoContext : DbContext
    {

        public class MyConfiguration : DbMigrationsConfiguration<NandosoContext>
        {
            public MyConfiguration()
            {
                this.AutomaticMigrationsEnabled = true;
            }
            protected override void Seed(NandosoContext context)
            {

                var specials = new List<Specials>
            {
                new Specials { Price = 9,   Name = "Quarter Chicken",
                    Description = "Small fraction, big reaction." },
                new Specials { Price = 13, Name = "Quarter Chicken & Regular side",
                    Description = "Small fraction, big reaction." },
                new Specials { Price = 13,   Name = "Half Chicken",
                    Description = "Nothing half hearted here." },
                new Specials { Price = 12,    Name = "5 Grilled Tenderloins",
                    Description = "So tender you'll feel it in your loins." },
                new Specials { Price = 14,      Name = "Portuguese Paella",
                    Description = "Grilled chicken pieces combined with veggie strips, tossed over our spicy rice." },
                new Specials { Price = 16,    Name = "Espetada (Portuguese Chicken Skewer)",
                    Description = "Marinated thigh fillets skewered with fresh red capsicum and onion, flame-grilled to perfection, basted to your heart's desire, served over a regular side." },
                new Specials { Price = 12,    Name = "5 BBQ Wings",
                    Description = "Bite sized chicken on the bone." },
                new Specials { Price = 11,     Name = "5 BBQ Thigh Fillets",
                    Description = "Reach new heights of enjoyment." }
            };
                //specials.ForEach(s => context.Special.AddOrUpdate(p => p.LastName, s));
                context.SaveChanges();
            }
        }
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public NandosoContext() : base("name=NandosoContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NandosoContext, MyConfiguration>());
        }
        public System.Data.Entity.DbSet<Specials> Special { get; set; }
    }
}
