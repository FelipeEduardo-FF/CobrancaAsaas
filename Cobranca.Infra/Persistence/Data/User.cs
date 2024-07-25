using Cobrancas.Infra.Persistence.Data;

namespace Cobrancas.Domain.Models
{
    public class User : ApplicationUser
    {
        public string Name { get; set; } = null!;
    }
}
