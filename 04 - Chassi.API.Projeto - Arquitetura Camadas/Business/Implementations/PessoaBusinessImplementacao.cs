using Chassi.API.Projeto.Model;
using Chassi.API.Projeto.Business.Interface;
using Chassi.API.Projeto.Repository.Interface;

namespace Chassi.API.Projeto.Business.Implementations
{
    public class PessoaBusinessImplementacao : IPessoaBusiness
    {
        //private volatile int count;
        private readonly IPessoaRepository _repository;
        public PessoaBusinessImplementacao(IPessoaRepository repository)
        {
            _repository = repository;  
        }
        public List<Pessoa> BuscarTodos()
        {
            return _repository.BuscarTodos();
        }        
        public Pessoa BuscarPorId(long id)
        {
            var retorno = _repository.BuscarPorId(id);  
            return retorno;
        }
        public Pessoa Incluir(Pessoa pessoa)
        {
            return _repository.Incluir(pessoa); 
        }
        public Pessoa Atualizar(Pessoa pessoa)
        {

            return _repository.Atualizar(pessoa);
        }
        public void Excluir(long id)
        {
            _repository.Excluir(id);    
        }
    }
}
