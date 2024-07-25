
namespace Core.Config
{
    public class Security
    {
        public string SharedSecret { get; set; }
        public string Issuer { get; set; }
        public string Audiance { get; set; }
        public int ExpireTimeMinutes { get; set; }
    }
}
