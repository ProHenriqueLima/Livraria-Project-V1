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
        
        private readonly IRepository _repo;
       

        public EditoraController( IRepository repo)
        {
            _repo = repo;
           
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repo.GetAllEditoras());
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var editora = _repo.GetAllEditoraByID(id);
            if (editora == null) return BadRequest("Editora não encontrado");
            return Ok(editora);
        }
        
        [HttpPost]
        public IActionResult Post(Editora editora)
        {
           _repo.Add(editora);
           if (_repo.SaveChanges())
           {
               return Ok(editora);
           }
           return BadRequest("Editora não encontrada");
            
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Editora editora)
        {
            var edi = _repo.GetAllEditoraByID(id);
            if (edi == null) return BadRequest("Editora não encontrado");

            _repo.update(editora);
           if (_repo.SaveChanges())
           {
               return Ok("Editora Atualizada");
           }
           return BadRequest("Editora não Atualizada");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Editora editora)
        {   
           var edi = _repo.GetAllEditoraByID(id);
            if (edi == null) return BadRequest("Editora não encontrado");

            _repo.update(editora);
           if (_repo.SaveChanges())
           {
               return Ok(editora);
           }
           return BadRequest("Editora não Atualizada");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {   
            var edi = _repo.GetAllEditoraByID(id);
            if (edi == null) return BadRequest("Editora não encontrado");

            _repo.delete(edi);
           if (_repo.SaveChanges())
           {
               return Ok("Editora Deletada");
           }
           return BadRequest("Editora não Deletada");
        }



    }
}