using SayfamaHosgeldinAPI.Core.Entities.Concrete;

namespace SayfamaHosgeldinAPI.Entities
{
    public class User:EntityBase
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
