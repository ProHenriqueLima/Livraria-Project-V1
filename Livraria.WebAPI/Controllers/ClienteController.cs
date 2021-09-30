using System.Collections.Generic;
using System.Linq;
using Livraria.WebAPI.Data;
using Livraria.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly LivrariaContext context;

        public ClienteController(LivrariaContext context)
        {
            this.context = context;
        }




        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.context.Clientes);
        }


        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var cliente = this.context.Clientes.FirstOrDefault(a => a.Id == id);
            if (cliente == null) return BadRequest("Cliente não encontrado");
            return Ok(cliente);
        }
        [HttpGet("byName/{nome}")]
        public IActionResult GetByName(string nome)
        {
            var cliente = this.context.Clientes.FirstOrDefault(a => a.NomeCliente == nome);
            if (cliente == null) return BadRequest("Cliente não encontrado");
            return Ok(cliente);
        }


        [HttpPost]
        public IActionResult Post(Cliente cliente)
        {
            this.context.Add(cliente);
            this.context.SaveChanges();
            return Ok(cliente);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Cliente cliente)
        {
            var cli = this.context.Clientes.FirstOrDefault(a => a.Id == id);
            if (cli == null) return BadRequest("Cliente não encontrado");

            this.context.Update(cliente);
            this.context.SaveChanges();
            return Ok(cliente);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Cliente cliente)
        {
            var cli = this.context.Clientes.FirstOrDefault(a => a.Id == id);
            if (cli == null) return BadRequest("Cliente não encontrado");

            this.context.Update(cliente);
            this.context.SaveChanges();
            return Ok(cliente);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var cli = this.context.Clientes.FirstOrDefault(a => a.Id == id);
            if (cli == null) return BadRequest("Cliente não encontrado");

            this.context.Remove(cli);
            this.context.SaveChanges();
            return Ok();
            }
        


    }
}