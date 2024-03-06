using Chassi.API.Projeto.Model;
using Chassi.API.Projeto.Business.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Chassi.API.Projeto.Controllers.V2
{
    [ApiController]
    [ApiVersion("2")]
    [Route("[controller]/api/v{version:apiVersion}/")]
    public class PessoaController : ControllerBase
    {
        private readonly ILogger<PessoaController> _logger;
        private readonly IPessoaBusiness _pessoa;

        public PessoaController(ILogger<PessoaController> logger,
                                IPessoaBusiness pessoa)
        {
            _logger = logger;
            _pessoa = pessoa;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_pessoa.BuscarTodos());
        }
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            Pessoa pessoa = _pessoa.BuscarPorId(id);
            if (pessoa == null) { return NotFound(); }
            return Ok(pessoa);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Pessoa pessoa)
        {
            if (pessoa == null) { return BadRequest(); }
            return Ok(_pessoa.Incluir(pessoa));
        }
        [HttpPut]
        public IActionResult Put([FromBody] Pessoa pessoa)
        {
            if (pessoa == null) { return BadRequest(); }
            return Ok(_pessoa.Atualizar(pessoa));
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _pessoa.Excluir(id);
            return NoContent();
        }
    }
}
