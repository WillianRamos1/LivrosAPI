using LivrosAPI.Data;
using LivrosAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LivrosAPI.Repositorios
{
    public class LivroRepositorio : ILivroRepositorio
    {
        public readonly DatabaseContext _databaseContext;
        public LivroRepositorio(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public async Task<Livro> Create(Livro livro)
        {
            _databaseContext.Livros.Add(livro);
            await _databaseContext.SaveChangesAsync();
            return livro;
        }

        public async Task Delete(int id)
        {
            var livroDeletar = await _databaseContext.Livros.FindAsync(id);
            _databaseContext.Livros.Remove(livroDeletar);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Livro>> Get()
        {
          return await  _databaseContext.Livros.ToListAsync();
        }

        public async Task<Livro> Get(int id)
        {
            return await _databaseContext.Livros.FindAsync(id);
        }

        public async Task Update(Livro livro)
        {
            _databaseContext.Entry(livro).State = EntityState.Modified;
            await _databaseContext.SaveChangesAsync();
        }
    }
}
