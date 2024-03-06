using Chassi.API.Projeto.Model;
using Chassi.API.Projeto.Model.Context;
using Chassi.API.Projeto.Repository.Interface;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Chassi.API.Projeto.Repository.Implementations
{
    public class PessoaRepositoryImplementacao : IPessoaRepository
    {
        //private volatile int count;
        private readonly MySqlContext _context;

        public bool Exists(long id)
        {
             return _context.Pessoas.Any(p => p.Id.Equals(id)); 
        }

        public PessoaRepositoryImplementacao(MySqlContext context)
        {
            _context = context;  
        }
        public List<Pessoa> BuscarTodos()
        {
            return _context.Pessoas.ToList();
        }        
        public Pessoa BuscarPorId(long id)
        {
            var retorno = _context.Pessoas.SingleOrDefault(p => p.Id.Equals(id));
            if (retorno != null) { 
                return retorno; 
            }
            throw new Exception($"Não encontrado o id {id} requisitado.");

        }
        public Pessoa Incluir(Pessoa pessoa)
        {
            try
            {
                _context.Add(pessoa);
                _context.SaveChanges(); 
            }
            catch (Exception)
            {

                throw;
            }
            return pessoa; 
        }
        public Pessoa Atualizar(Pessoa pessoa)
        {
            if (!Exists(pessoa.Id))
            {
                return new Pessoa();
            }
            var result = _context.Pessoas.SingleOrDefault(p => p.Id.Equals(pessoa.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(pessoa);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            
            return pessoa;
        }
        public void Excluir(long id)
        {
            var result = _context.Pessoas.SingleOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.Pessoas.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
