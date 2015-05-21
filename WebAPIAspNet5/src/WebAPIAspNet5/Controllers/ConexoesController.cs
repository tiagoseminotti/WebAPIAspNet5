using Microsoft.AspNet.Mvc;
using System.Collections.Generic;
using WebAPIAspNet5.Models;
using WebAPIAspNet5.Services;

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
        public IEnumerable<GspConexaoGesplan> Get()
        {
            return service.GetConexoes();
        }

        // GET api/conexoes/5
        [HttpGet("{id}")]
        public GspConexaoGesplan Get(int id)
        {
            return service.GetConexao(id);
        }

        // POST api/conexoes
        [HttpPost]
        public GspConexaoGesplan Post(GspConexaoGesplan conex)
        {
            return service.CreateConexao(conex);
        }

        // PUT api/conexoes/5
        [HttpPut("{id}")]
        public GspConexaoGesplan Put(int id, GspConexaoGesplan conex)
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
