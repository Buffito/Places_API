namespace Places_API.DTO.Auth
{
    public class AuthResult
    {
        public string Token { get; set; }
        
        public bool Success { get; set; }

        public string Message { get; set; }
    }
}
