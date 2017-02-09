using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace DocDesckApp.Models
{
    public class DocDeskContext : DbContext
    {
        public DbSet<Activ> Activs { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Lifecycle> Lifecircles { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
     }
}