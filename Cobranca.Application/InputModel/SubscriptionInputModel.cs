using Cobrancas.Domain.Enum;
using Cobrancas.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Cobranca.Application.InputModel
{
    public class SubscriptionInputModel
    {
        [Required(ErrorMessage = "{0} deve ser fornecido")]
        public BillingTypeEnum BillingType { get;  set; }
        [Required(ErrorMessage = "{0} deve ser fornecido")]
        public float Amount { get;  set; }
        [Required(ErrorMessage = "{0} deve ser fornecido")]
        public DateTime? FirstPayment { get;  set; }
        [Required(ErrorMessage = "{0} deve ser fornecido")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Valor selecionado é inválido")]
        public int CostumerId { get;  set; }

        public Subscription ToEntity()
        {
            return new Subscription(BillingType, Amount,(DateTime)FirstPayment, CostumerId);
        }

    }
}
