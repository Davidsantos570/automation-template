namespace Zitec.Automation.Domain.Entities;

// TODO: renomeie/adapte essa entidade para o que sua automação realmente processa
// (ex: Boleto, NotaFiscal, Pedido, ArquivoRecebido, etc.)
public class ItemProcessado
{
    public int IdItem { get; set; }
    public string Identificador { get; set; } = string.Empty;
    public DateTime ProcessadoEm { get; set; }
    public bool Sucesso { get; set; }
    public string? MensagemErro { get; set; }
}
