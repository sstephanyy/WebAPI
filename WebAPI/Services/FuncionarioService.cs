using WebAPI.Data;
using WebAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace WebAPI.Services
{
    public class FuncionarioService : IFuncionario
    {
        private readonly AppDbContext _context;

        public FuncionarioService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Funcionario>>> GetFuncionariosAsync()
        {
            //criar uma instância para agrupar ou encapsular informações sobre o resultado de uma operação.
            ServiceResponse<List<Funcionario>> serviceResponse = new ServiceResponse<List<Funcionario>>();

            try
            {
                // tentar obter a lista de funcionários do contexto do banco de dados
                serviceResponse.Dados = await _context.Funcionarios.ToListAsync();

                if (serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum dado encontrado!";
                }


            }
            catch (Exception ex)
            {

                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse; // contém os dados da lista de funcionários (se houver) e quaisquer mensagens ou informações adicionais sobre o resultado da operação.
        }

        public async Task<ServiceResponse<Funcionario>> GetFuncionarioByIdAsync(int id)
        {
            ServiceResponse<Funcionario> serviceResponse = new ServiceResponse<Funcionario>();

            try
            {
                Funcionario funcionario = await _context.Funcionarios.FirstOrDefaultAsync(x => x.Id == id);

                if(funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Funcionário não localizado!!";
                    serviceResponse.Sucesso = false;
                }

                serviceResponse.Dados = funcionario;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<Funcionario>> AddFuncionarioAsync(Funcionario novoFuncionario)
        {
            ServiceResponse<Funcionario> serviceResponse = new ServiceResponse<Funcionario>();

            try
            {
                if(novoFuncionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informe os dados!!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                novoFuncionario.DataDeCriacao = DateTime.Now.ToLocalTime();
                novoFuncionario.DataDeAlteracao = DateTime.Now.ToLocalTime();

                await _context.AddAsync(novoFuncionario);
                await _context.SaveChangesAsync();


            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem= ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;

        }

        public async Task<ServiceResponse<Funcionario>> UpdateFuncionariosAsync(Funcionario funcionarioEditado)
        {
            ServiceResponse<Funcionario> serviceResponse= new ServiceResponse<Funcionario>();

            try
            {
                //você está informando explicitamente ao contexto do banco de dados para não rastrear as entidades recuperadas. Isso pode melhorar o desempenho da consulta, pois o contexto não precisa acompanhar as entidades recuperadas e suas mudanças. Isso é útil se você está apenas lendo o funcionário para exibição 
                Funcionario funcionario = await _context.Funcionarios.AsNoTracking().FirstOrDefaultAsync(x => x.Id == funcionarioEditado.Id);

                if(funcionarioEditado == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Funcionário não encontrado!!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                funcionario.DataDeAlteracao = DateTime.Now.ToLocalTime();

                _context.Funcionarios.Update(funcionarioEditado);
                await _context.SaveChangesAsync();


            }catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;

            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<Funcionario>> DeleteFuncionarioAsync (int id)
        {
            ServiceResponse<Funcionario> serviceResponse = new ServiceResponse<Funcionario>();

            try
            {
                Funcionario funcionario = await _context.Funcionarios.FirstOrDefaultAsync(x => x.Id == id);

                if (funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não localizado!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Funcionarios.Remove(funcionario);
                await _context.SaveChangesAsync();
            }catch(Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;

        }

        public async Task<ServiceResponse<Funcionario>> InativaFuncionario(int id)
        {
            ServiceResponse<Funcionario> serviceResponse = new ServiceResponse<Funcionario>();

            try
            {
                Funcionario funcionario = await _context.Funcionarios.FirstOrDefaultAsync(x => x.Id == id);

                if (funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Funcionário não localizado!";
                    serviceResponse.Sucesso = false;
                }

                funcionario.Ativo = false;
                funcionario.DataDeAlteracao = DateTime.Now.ToLocalTime();

                _context.Funcionarios.Update(funcionario);
                await _context.SaveChangesAsync();
            }catch(Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;

        }
    }
}
