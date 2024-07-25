using Cobrancas.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobranca.Application.InputModel
{
    public  class CostumerInputModel
    {
        [Required(ErrorMessage = "Nome deve ser fornecido")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Documento deve ser fornecido")]
        public string Document { get; set; }
        [Required(ErrorMessage = "Celular deve ser fornecido")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "E-mail deve ser fornecido")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        [MaxLength(50, ErrorMessage = "{0} deve ter no máximo {1} caracteres")]
        public string Email { get; set; }

        public Customer ToEntity()
        {
            return new Customer(Name, Document, PhoneNumber, Email);
        }
    }
}
