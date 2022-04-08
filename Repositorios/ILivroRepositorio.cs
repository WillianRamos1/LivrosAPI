using LivrosAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LivrosAPI.Repositorios
{
    public interface ILivroRepositorio
    {
        Task<IEnumerable<Livro>> Get();
        Task<Livro> Get(int Id);
        Task<Livro> Create(Livro livro);
        Task Update(Livro livro);
        Task Delete(int Id);
    }
}
