namespace LembreMeApi.Models
{
    public class DespesaModel
    {
        public string? Id { get; set; }

        public DateTime? DataPagamento { get; set; }

        public string? Titulo { get; set; }

        public DateTime Vencimento { get; set; }

        public double Valor { get; set; }
    }
}
