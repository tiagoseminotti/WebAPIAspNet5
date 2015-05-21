using Microsoft.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace WebAPIAspNet5.Models
{
    /// <summary>
    /// The Entity class with Conexoes properties
    /// </summary>
    //[Table("ConexaoGesplan")]
    public class GspConexaoGesplan
    {
        /*[Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]*/
        [ScaffoldColumn(false)]
        public int idConexaoGesplan{ get; set; }

        [Required]
        [StringLength(50)]
        public string dsConexaoGesplan { get; set; }

        [Required]
        [StringLength(100)]
        public string dsServidor { get; set; }
        
        [StringLength(100)]
        public string dsDatabase { get; set; }

        [Required]
        [StringLength(50)]
        public string dsUsuario { get; set; }

        [Required]
        [StringLength(100)]
        public string dsSenha { get; set; }

        [Required]
        public int stTipoBanco { get; set; }
    }

    /// <summary>
    /// The context class. This uses the Sql Server with the Connection string
    /// defined in the config.json
    /// </summary>
    public class ConexaoDbContext : DbContext
    {   
        public DbSet<GspConexaoGesplan> Conexoes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {   
            options.UseSqlServer(Startup.Configuration.Get("Data:DefaultConnection:ConnectionString"));
        }

        //Sets the entity primary key
        protected override void OnModelCreating(ModelBuilder builder)
        {   
            builder.Entity<GspConexaoGesplan>().Key(p => p.idConexaoGesplan);

            base.OnModelCreating(builder);
        }
    }
}
