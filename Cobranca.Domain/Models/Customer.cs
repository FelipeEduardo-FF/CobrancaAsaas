namespace Cobrancas.Domain.Models
{
    public class Customer
    {
        public Customer(string name, string document, string phoneNumber, string email)
        {
            Name = name;
            Document = document;
            PhoneNumber = phoneNumber;
            Email = email;
            IsDeleted=false;
        }
        public int Id { get; set; }
        public string Name { get; private set; }
        public string Document { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string IdGatewayPayment { get;private set; }
        public bool IsDeleted { get; private set; }


        public void SetIdGatewayPayment(string idGatewayPayment)
        {
            IdGatewayPayment= idGatewayPayment;
        }
        public void Update(string name, string document, string phoneNumber, string email)
        {
            if (!string.IsNullOrEmpty(name)) Name = name;
            if (!string.IsNullOrEmpty(document)) Document = document;
            if (!string.IsNullOrEmpty(phoneNumber)) PhoneNumber = phoneNumber;
            if (!string.IsNullOrEmpty(email)) Email = email;
        }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
