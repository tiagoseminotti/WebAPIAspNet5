using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIAspNet5.Models
{
    /// <summary>
    /// The Entity class with Product properties
    /// </summary>
    [Table("ConexaoGesplan")]
    public class Conexao
    {
        /*[Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]*/
        public int id { get; set; }
        public string dsConexaoGesplan { get; set; }
        public string dsServidor { get; set; }
        public string dsDatabase { get; set; }
        public string dsUsuario { get; set; }
        public string dsSenha { get; set; }
        public int stTipoBanco { get; set; }
    }

    /// <summary>
    /// The context class. This uses the Sql Server with the Connection string
    /// defined in the Config.json
    /// </summary>
    public class ConexaoDbContext : DbContext
    {
        public DbSet<Conexao> Conexoes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Startup.Configuration.Get("Data:DefaultConnection:ConnectionString"));
        }
    }
}
