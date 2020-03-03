namespace EF6
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class User : DbContext
    {
        public User()
            : base("name=UserContext")
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

    public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
