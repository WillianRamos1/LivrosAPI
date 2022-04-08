using LivrosAPI.Models;
using LivrosAPI.Repositorios;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LivrosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : Controller
    {
        private readonly ILivroRepositorio _livroRepositorio;

        public LivroController(ILivroRepositorio livroRepositorio)
        {
            _livroRepositorio = livroRepositorio;
        }

        [HttpGet]
        public async Task<IEnumerable<Livro>> GetLivros()
        {
            return await _livroRepositorio.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Livro>> GetLivros(int id)
        {
            return await _livroRepositorio.Get(id);
        }
        [HttpPost]
        public async Task<ActionResult<Livro>> PostLivros([FromBody] Livro livro)
        {
            var NovoLivro = await _livroRepositorio.Create(livro);
            return CreatedAtAction(nameof(GetLivros), new { id = NovoLivro.ID }, NovoLivro);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var livroDeletar = await _livroRepositorio.Get(id);
            if (livroDeletar == null)
                return NotFound();
                await _livroRepositorio.Delete(livroDeletar.ID);
            return NoContent();
        }
        [HttpPut]
        public async Task<ActionResult> PutLivros(int id, [FromBody] Livro livro)
        {
            if (id != livro.ID)
                return BadRequest();
            await _livroRepositorio.Update(livro);
            return NoContent();
        }
    }
}
