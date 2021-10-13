using Livraria.WebAPI.Data;
using Livraria.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.WebAPI.Controllers
{
    public class LivroController : ControllerBase
    {
 

        private readonly IRepository _repo;
        public LivroController(IRepository repo)
        {
            _repo = repo;

        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repo.GetAllLivro());
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var livro = _repo.GetAllEditoraByID(id);
            if (livro == null) return BadRequest("Livro não encontrado");
            return Ok(livro);
        }


        [HttpPost]
        public IActionResult Post(Livro livro)
        {
            _repo.Add(livro);
           if (_repo.SaveChanges())
           {
               return Ok(livro);
           }
           return BadRequest("Livro não Encontrado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Livro livro)
        {
            var liv = _repo.GetAllLivroByID(id);
            if (liv == null) return BadRequest("Livro não encontrado");

            _repo.update(livro);
           if (_repo.SaveChanges())
           {
               return Ok("Livro Atualizado");
           }
           return BadRequest("Livro não Atualizado");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Livro livro)
        {
            var liv = _repo.GetAllLivroByID(id);
            if (liv == null) return BadRequest("Livro não encontrado");

            _repo.update(livro);
           if (_repo.SaveChanges())
           {
               return Ok("Livro Atualizado");
           }
           return BadRequest("Livro não Atualizado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var liv = _repo.GetAllLivroByID(id);
            if (liv == null) return BadRequest("Livro não encontrado");

            _repo.delete(liv);
           if (_repo.SaveChanges())
           {
               return Ok("Livro Deletado");
           }
           return BadRequest("Livro Deletado");
        }
    }
}
