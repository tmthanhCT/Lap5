using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lap5
{
    public interface IPaymentGateway
    {
        bool ProcessPayment(string accountNumber, decimal amount);
    }

    public class PaymentService
    {
        private readonly IPaymentGateway _paymentGateway;

        public PaymentService(IPaymentGateway paymentGateway)
        {
            _paymentGateway = paymentGateway;
        }

        public bool MakePayment(string accountNumber, decimal amount)
        {
            if (string.IsNullOrWhiteSpace(accountNumber)) throw new ArgumentException("Invalid account number.");
            if (amount <= 0) throw new ArgumentException("Amount must be greater than zero.");

            return _paymentGateway.ProcessPayment(accountNumber, amount);
        }
    }
}
