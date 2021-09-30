using System.Collections.Generic;
using System.Linq;
using Livraria.WebAPI.Data;
using Livraria.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EditoraController : ControllerBase
    {
        private readonly LivrariaContext context;

        public EditoraController(LivrariaContext context)
        {
            this.context = context;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.context.Editoras);
        }


        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var editora = this.context.Editoras.FirstOrDefault(a => a.Id == id);
            if (editora == null) return BadRequest("Editora não encontrado");
            return Ok(editora);
        }
        [HttpGet("byName/{nome}")]
        public IActionResult GetByName(string nome)
        {
            var editora = this.context.Editoras.FirstOrDefault(a => a.NameEditora == nome);
            if (editora == null) return BadRequest("Editora não encontrado");
            return Ok(editora);
        }


        [HttpPost]
        public IActionResult Post(Editora editora)
        {
            return Ok(editora);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Editora editora)
        {
            return Ok(editora);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Editora editora)
        {
            return Ok(editora);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
            }
        


    }
}