using Chassi.API.Projeto.Model;

namespace Chassi.API.Projeto.Business.Interface
{
    public interface IPessoaBusiness

    {
        Pessoa Incluir(Pessoa pessoa);
        Pessoa BuscarPorId(long id);
        List<Pessoa> BuscarTodos();
        Pessoa Atualizar(Pessoa pessoa);
        void Excluir(long id);
    }
}
