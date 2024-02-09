using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //controllerBase -> É ideal para controladores que fornecem serviços de API RESTful, pois não contém funcionalidades relacionadas a visualizações
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionario _funcionario;

        public FuncionarioController(IFuncionario funcionario)
        {
            _funcionario = funcionario;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Funcionario>>>> GetFuncionariosAsync()
        {
            return Ok(await _funcionario.GetFuncionariosAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Funcionario>>> GetFuncionarioByIdAsync(Guid id)
        {
            ServiceResponse<Funcionario> serviceResponse = await _funcionario.GetFuncionarioByIdAsync(id);

            return Ok(serviceResponse);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Funcionario>>> AddFuncionarioAsync(Funcionario novoFuncionario)
        {
            return Ok(await _funcionario.AddFuncionarioAsync(novoFuncionario));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<Funcionario>>> UpdateFuncionariosAsync(Funcionario funcionarioEditado)
        {
            ServiceResponse<Funcionario> serviceResponse = await _funcionario.UpdateFuncionariosAsync(funcionarioEditado);

            return Ok(serviceResponse);
        }

        [HttpPut("inativaFuncionario")]
        public async Task<ActionResult<List<Funcionario>>> InativaFuncionario(Guid id)
        {
            ServiceResponse<List<Funcionario>> serviceResponse = await _funcionario.InativaFuncionario(id);

            return Ok(serviceResponse);

        }

        [HttpDelete]
        public async Task<ActionResult<Funcionario>> DeleteFuncionarioAsync(Guid id)
        {
            ServiceResponse<Funcionario> serviceResponse = await _funcionario.DeleteFuncionarioAsync(id);

            return Ok(serviceResponse);

        }

    }
}
