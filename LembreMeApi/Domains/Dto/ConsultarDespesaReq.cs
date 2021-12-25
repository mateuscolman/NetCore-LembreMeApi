namespace LembreMeApi.Domains.Dto
{
    public class ConsultarDespesaReq
    {
        public DateTime Vencimento { get; set; }

        public string? IdUsuario { get; set; }

        public Int32 Baixado { get; set; }
    }
}
