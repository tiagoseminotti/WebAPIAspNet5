using System.Collections.Generic;
using System.Linq;
using WebAPIAspNet5.Models;

namespace WebAPIAspNet5.Services
{
    /// <summary>
    /// Interface for defining the methods for performing CRUD operations 
    /// on the Product table
    /// </summary>
    public interface IConexaoService
    {
        IEnumerable<GspConexaoGesplan> GetConexoes();
        GspConexaoGesplan GetConexao(int id);
        GspConexaoGesplan CreateConexao(GspConexaoGesplan Conexao);
        GspConexaoGesplan UpdateConexao(int id, GspConexaoGesplan Conexao);
        bool DeleteConexao(int id);
    }
    /// <summary>
    /// The service class containing logic for CRUD operations
    /// </summary>
    public class ConexaoService : IConexaoService
    {
        ConexaoDbContext ctx;

        public ConexaoService(ConexaoDbContext c)
        {
            ctx = c;
        }

        public GspConexaoGesplan CreateConexao(GspConexaoGesplan Conexao)
        {
            ctx.Conexoes.Add(Conexao);
            ctx.SaveChanges();
            return Conexao;
        }

        public bool DeleteConexao(int id)
        {
            var conexao = ctx.Conexoes.Where(p => p.idConexaoGesplan == id).First();
            ctx.Conexoes.Remove(conexao);
            if (ctx.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public GspConexaoGesplan GetConexao(int id)
        {
            var product = ctx.Conexoes.Where(p => p.idConexaoGesplan == id).First();
            return product;
        }

        public IEnumerable<GspConexaoGesplan> GetConexoes()
        {
            return ctx.Conexoes.AsEnumerable();
        }

        public GspConexaoGesplan UpdateConexao(int id, GspConexaoGesplan Conexao)
        {
            var conex = ctx.Conexoes.Where(p => p.idConexaoGesplan == id).First();

            if (conex != null)
            {
                conex.dsConexaoGesplan = Conexao.dsConexaoGesplan;
                conex.dsDatabase = Conexao.dsDatabase;
                conex.dsServidor = Conexao.dsServidor;
                conex.dsUsuario = Conexao.dsUsuario;
                conex.stTipoBanco = Conexao.stTipoBanco;

                ctx.SaveChanges();
            }
            return conex;
        }
    }
}