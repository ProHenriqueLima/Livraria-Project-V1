using System;
using System.Collections.Generic;
using AutoMapper;
using Livraria.WebAPI.Data;
using Livraria.WebAPI.Dtos;
using Livraria.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AluguelController : ControllerBase
    {
        public readonly IRepository _repo;
        public readonly IMapper _mapper;
        public AluguelController(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        
        

        [HttpGet]
        public IActionResult Get()
        {
            var alugueis = _repo.GetAllAluguel(includeLivro:true, includeCliente:true);
            return Ok(_mapper.Map<IEnumerable<AluguelDto>>(alugueis));
        }


        [HttpPost]
        public IActionResult Post(Editora editora)
        {
            _repo.Add(editora);
           if (_repo.SaveChanges())
           {
               var editoraDto = _mapper.Map<EditoraDto>(editora);
               return Ok(editoraDto);
           }
           return BadRequest("Editora não Adicionada");
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluguel aluguel)
        {
            var alu = _repo.GetAluguelById(id, includeLivro:true, includeCliente:true);
            if (alu == null) return BadRequest("Aluguel não encontrado");

            _repo.update(aluguel);
           if (_repo.SaveChanges())
           {
               return Ok("Aluguel Atualizado");
           }
           return BadRequest("Aluguel não Atualizado");
        }


        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluguel aluguel)
        {
            var alu = _repo.GetAluguelById(id, includeLivro:true, includeCliente:true);
            if (alu == null) return BadRequest("Aluguel não encontrado");

            _repo.update(aluguel);
           if (_repo.SaveChanges())
           {
               return Ok("Aluguel Atualizado");
           }
           return BadRequest("Aluguel não Atualizado");
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var alu = _repo.GetAluguelById(id,false,false);
            if (alu == null) return BadRequest("Aluguel não encontrado");

            _repo.delete(alu);
           if (_repo.SaveChanges())
           {
               return Ok("Aluguel Deletado");
           }
           return BadRequest("Aluguel Deletado");
        }
    }
}