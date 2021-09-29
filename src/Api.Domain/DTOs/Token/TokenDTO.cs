namespace Api.Domain.DTOs.Token
{
    public class TokenDTO
    {
        public bool Authenticated { get; set; }
        public string CreateDate { get; set; }
        public string ExpirationDate { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
