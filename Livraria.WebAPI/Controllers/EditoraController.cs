using System.Collections.Generic;
using System.Linq;
using Livraria.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EditoraController : ControllerBase
    {
        
        
        
        public List<Editora> Editoras = new List<Editora>(){
            new Editora(){
                id_editora = 1,
                name_editora = "Henrique",
                cidade_editora = "São paulo"
            },new Editora(){
                id_editora = 2,
                name_editora = "Paulo",
                cidade_editora = "São paulo"
            },new Editora(){
                id_editora = 3,
                name_editora = "João",
                cidade_editora = "São paulo"
            },
        };
        public EditoraController(){}
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Editoras);
        }


        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var editora = Editoras.FirstOrDefault(a => a.id_editora == id);
            if (editora == null) return BadRequest("Editora não encontrado");
            return Ok(editora);
        }
        [HttpGet("byName/{nome}")]
        public IActionResult GetByName(string nome)
        {
            var editora = Editoras.FirstOrDefault(a => a.name_editora == nome);
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