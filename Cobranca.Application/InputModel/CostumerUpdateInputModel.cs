using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobranca.Application.InputModel
{
    public class CostumerUpdateInputModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
