namespace LembreMeApi.Domains.Dto
{
    public class ConsultarDespesaReq
    {
        public DateTime Vencimento { get; set; } = DateTime.Now;
        public string? IdUsuario { get; set; }
        public Int32 Baixado { get; set; }
    }

    public class ConsultarDespesaSwagger
    {
        public DateTime Vencimento { get; set; }
        public Int32 Baixado { get; set; }
    }
}
