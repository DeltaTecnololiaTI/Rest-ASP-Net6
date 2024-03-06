using Chassi.API.Projeto.Model;
using Chassi.API.Projeto.Model.Context;
using Chassi.API.Projeto.Services.Interface;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Chassi.API.Projeto.Services.Implementations
{
    public class PessoaServicoImplementacao : IPessoaService
    {
        //private volatile int count;
        private readonly MySqlContext _context;

        private bool Exists(long id)
        {
             return _context.Pessoas.Any(p => p.Id.Equals(id)); 
        }

        public PessoaServicoImplementacao(MySqlContext context)
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
