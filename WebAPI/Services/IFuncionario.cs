using WebAPI.Models;

namespace WebAPI.Services
{
    public interface IFuncionario
    {
        Task<ServiceResponse<List<Funcionario>>> GetFuncionariosAsync();
        Task<ServiceResponse<Funcionario>> GetFuncionarioByIdAsync(int id);
        Task<ServiceResponse<Funcionario>> AddFuncionarioAsync(Funcionario novoFuncionario); 
        Task<ServiceResponse<Funcionario>> DeleteFuncionarioAsync(int id); 
        Task<ServiceResponse<Funcionario>> UpdateFuncionariosAsync(Funcionario funcionarioEditado); 
        Task<ServiceResponse<List<Funcionario>>> InativaFuncionario(int id);


    }
}
