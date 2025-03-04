namespace AuthenticationAuthorization.Infastructure
{
    internal class JwtOptions
    {
        public string SecretKey { get; set; } = string.Empty;
        public int ExpiteHours { get; set; }
    }
}
