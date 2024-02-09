using WebAPI.Models;

namespace WebAPI.Services
{
    public interface IFuncionario
    {
        Task<ServiceResponse<List<Funcionario>>> GetFuncionariosAsync();
        Task<ServiceResponse<Funcionario>> GetFuncionarioByIdAsync(Guid id);
        Task<ServiceResponse<Funcionario>> AddFuncionarioAsync(Funcionario novoFuncionario); 
        Task<ServiceResponse<Funcionario>> DeleteFuncionarioAsync(Guid id); 
        Task<ServiceResponse<Funcionario>> UpdateFuncionariosAsync(Funcionario funcionarioEditado); 
        Task<ServiceResponse<List<Funcionario>>> InativaFuncionario(Guid id);


    }
}
