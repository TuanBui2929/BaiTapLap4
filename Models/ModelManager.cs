using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BaiTapLap4.Models
{
    public partial class ModelManager : DbContext
    {
        public ModelManager()
            : base("name=ModelManager")
        {
        }

        public virtual DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
