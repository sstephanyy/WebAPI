using System.Text.Json.Serialization;

namespace WebAPI.Enums
{
    //O uso de JsonStringEnumConverter substituiria esses valores numéricos (REPRESENTADOS POR 0 - RH, 1 - CONTAS_A_PAGAR...) por strings representando os nomes dos enum
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DepartamentoEnum
    {
        RH, 
        Contas_A_Pagar,
        Financeiro,
        TI,
        Atendimento,
        Diretoria,
        Auditoria,
        Vendas,
        Logistica,
        Juridico,
        Marketing
    }
}
