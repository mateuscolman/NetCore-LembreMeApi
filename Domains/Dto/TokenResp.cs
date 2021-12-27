namespace LembreMeApi.Domains.Dto
{
    public class TokenResp
    {
        public DateTime DataExpiracao { get; set; } = DateTime.UtcNow.AddHours(4);
        public string? Token { get; set; }
    }
}
