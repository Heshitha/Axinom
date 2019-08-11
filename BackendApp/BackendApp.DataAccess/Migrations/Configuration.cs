namespace BackendApp.DataAccess.Migrations
{
    using Core.Domain;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BackendApp.DataAccess.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BackendApp.DataAccess.DataContext context)
        {
            var Users = new List<User>()
            {
                new User {ID = 1, Email = "heshithachathuranga@gmail.com", Name="Heshitha", Password="srilanka", Username="Heshitha" },
                new User {ID = 2, Email = "Liis@gmail.com", Name="Liis", Username="Liis", Password="estonia" }
            };
            Users.ForEach(x => context.Users.Add(x));
            context.SaveChanges();
        }
    }
}
