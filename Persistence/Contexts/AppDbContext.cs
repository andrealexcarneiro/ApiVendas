using Microsoft.EntityFrameworkCore;


using ApiVendas.Models;
using ApiVendas.Models;

namespace ApiVendas.Persistence.Context
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }


       
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Produto> produtos { get; set; }
        public DbSet<PercDesconto> percDescontos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-V71BOOE;Initial Catalog=WebVendas;Integrated Security=False;User ID=sa;Password=Ju250298@");
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Produto>().ToTable("tProduto");
            builder.Entity<Produto>().HasKey(p => p.ID);
            builder.Entity<Produto>().Property(p => p.ID).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Produto>().Property(p => p.Descricao).IsRequired().HasMaxLength(50);
            builder.Entity<Produto>().Property(p => p.Valor).IsRequired();
            builder.Entity<Produto>().Property(p => p.PercDesc01).IsRequired();
            builder.Entity<Produto>().Property(p => p.PercDesc02).IsRequired();
            builder.Entity<Produto>().Property(p => p.PercDesc03).IsRequired();
            builder.Entity<Produto>().Property(p => p.PercDesc04).IsRequired();
            builder.Entity<Produto>().Property(p => p.PercDesc05).IsRequired();
            builder.Entity<Produto>().Property(p => p.PercDesc06).IsRequired();
            builder.Entity<Produto>().Property(p => p.PercDesc07).IsRequired();


            builder.Entity<PercDesconto>().ToTable("tPercDesconto");
            builder.Entity<PercDesconto>().HasKey(p => p.ID);
            builder.Entity<PercDesconto>().Property(p => p.ID).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<PercDesconto>().Property(p => p.Descricao).IsRequired().HasMaxLength(50);




            //builder.Entity<CaixaCab>(entity =>
            //{
            //    entity
            //    entity.HasKey(e => new { e.tUsuarioId, e.Usuario.ID });
            //});
        }

        private string stringConexao()
        {
            string strCon = "Data Source=BI03;Initial Catalog=WebVendas;Integrated Security=False;User ID=sa;Password=Ju250298@";
            // string strCon = "Server=tcp:canaldevcore.database.windows.net,1433;Initial Catalog=dev;Persist Security Info=False;User ID=valdir;Password=@Beatriz222;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            return strCon;
        }

        
    }
}
