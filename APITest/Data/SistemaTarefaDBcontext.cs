using APITest.Data.Map;
using APITest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace APITest.Data
{
    public class SistemaTarefaDBcontext : DbContext
    {
        public SistemaTarefaDBcontext(DbContextOptions options) : base(options)
        {
        }

        public class YourDbContextFactory : IDesignTimeDbContextFactory<SistemaTarefaDBcontext>
        {
            public SistemaTarefaDBcontext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<SistemaTarefaDBcontext>();
                optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=tempdb;Integrated Security=True");

                return new SistemaTarefaDBcontext(optionsBuilder.Options);
            }
        }


        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<TarefaModel> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());
            base.OnModelCreating(modelBuilder);
        }
    }

}
