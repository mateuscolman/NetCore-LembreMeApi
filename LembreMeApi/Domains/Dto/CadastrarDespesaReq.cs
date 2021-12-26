namespace LembreMeApi.Domains.Dto
{
    public class CadastrarDespesaReq
    {
        public string? Titulo { get; set; }
        public DateTime Vencimento { get; set; }
        public double Valor { get; set; }
        public string? IdUsuario { get; set; }
    }

    public class CadastrarDespesaSwagger
    {
        public string? Titulo { get; set; }
        public DateTime Vencimento { get; set; }
        public double Valor { get; set; }
    }
}
