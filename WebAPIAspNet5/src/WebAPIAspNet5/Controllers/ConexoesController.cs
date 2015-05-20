using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using WebAPIAspNet5.Services;
using WebAPIAspNet5.Models;

namespace WebAPIAspNet5.Controllers
{
    [Route("api/[controller]")]
    public class ConexoesController : Controller
    {
        IConexaoService service;

        public ConexoesController(IConexaoService serv)
        {
            service = serv;
        }

        // GET: api/conexoes
        [HttpGet]
        public IEnumerable<Conexao> Get()
        {
            return service.GetConexoes();
        }

        // GET api/conexoes/5
        [HttpGet("{id}")]
        public Conexao Get(int id)
        {
            return service.GetConexao(id);
        }

        // POST api/conexoes
        [HttpPost]
        public Conexao Post(Conexao conex)
        {
            return service.CreateConexao(conex);
        }

        // PUT api/conexoes/5
        [HttpPut("{id}")]
        public Conexao Put(int id, Conexao conex)
        {
            return service.UpdateConexao(id, conex);
        }

        // DELETE api/conexoes/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return service.DeleteConexao(id);
        }
    }
}
