using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace acroyoga.it.admin.Models
{
    public class AcroyogaContext : DbContext
    {
        public AcroyogaContext(): base("Acroyoga")
        {
            Database.SetInitializer<AcroyogaContext>(null);
            //Database.SetInitializer(new AcroyogaInitializer());
        }

        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure domain classes using Fluent API here

            base.OnModelCreating(modelBuilder);
        }
    }
    
    public class AcroyogaInitializer : DropCreateDatabaseAlways<AcroyogaContext>
    {
        protected override void Seed(AcroyogaContext context)
        {
            IList<Event> events = new List<Event>();

            events.Add(new Event() { Title = "title1", Description = "1 Standard", Body = "body1", CreateDate = DateTime.Now, ImageLeft = "imagepath1" });
            events.Add(new Event() { Title = "title2", Description = "2 Standard", Body = "body2", CreateDate = DateTime.Now, ImageLeft = "imagepath2" });
            events.Add(new Event() { Title = "title3", Description = "3 Standard", Body = "body3", CreateDate = DateTime.Now, ImageLeft = "imagepath3" });

            foreach (Event ev in events)
                context.Events.Add(ev);

            base.Seed(context);
        }
    }
}

