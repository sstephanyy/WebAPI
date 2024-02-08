namespace WebAPI.Models
{
    public class ServiceResponse<T> // <T> é genérico e dá pra trabalhar com vários tipos de dados (string, int)
    {
        public T? Dados { get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public bool Sucesso { get; set; } = true;
    }
}
