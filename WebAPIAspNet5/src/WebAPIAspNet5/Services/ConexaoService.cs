using System;
using System.Collections.Generic;
using WebAPIAspNet5.Models;
using System.Linq;

namespace WebAPIAspNet5.Services
{
    /// <summary>
    /// Interface for defining the methods for performing CRUD operations 
    /// on the Product table
    /// </summary>
    public interface IConexaoService
    {
        IEnumerable<Conexao> GetConexoes();
        Conexao GetConexao(int id);
        Conexao CreateConexao(Conexao Conexao);
        Conexao UpdateConexao(int id, Conexao Conexao);
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

        public Conexao CreateConexao(Conexao Conexao)
        {
            ctx.Conexoes.Add(Conexao);
            ctx.SaveChanges();
            return Conexao;
        }

        public bool DeleteConexao(int id)
        {
            var conexao = ctx.Conexoes.Where(p => p.id == id).First();
            ctx.Conexoes.Remove(conexao);
            if (ctx.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public Conexao GetConexao(int id)
        {
            var product = ctx.Conexoes.Where(p => p.id == id).First();
            return product;
        }

        public IEnumerable<Conexao> GetConexoes()
        {
            return ctx.Conexoes.AsEnumerable();
        }

        public Conexao UpdateConexao(int id, Conexao Conexao)
        {
            var conex = ctx.Conexoes.Where(p => p.id == id).First();

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