using Livraria.WebAPI.Data;
using Livraria.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.WebAPI.Controllers
{
    public class LivroController: ControllerBase
    {
        private readonly LivrariaContext context;

        public LivroController(LivrariaContext context)
        {
            this.context = context;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.context.Livros);
        }


        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var livro = this.context.Livros.FirstOrDefault(a => a.Id == id);
            if (livro == null) return BadRequest("Cliente não encontrado");
            return Ok(livro);
        }
        [HttpGet("byName/{nome}")]
        public IActionResult GetByName(string nome)
        {
            var livro = this.context.Livros.FirstOrDefault(a => a.NomeLivro == nome);
            if (livro == null) return BadRequest("Cliente não encontrado");
            return Ok(livro);
        }


        [HttpPost]
        public IActionResult Post(Livro livro)
        {
            return Ok(livro);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Livro livro)
        {
            return Ok(livro);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Livro livro)
        {
            return Ok(livro);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
