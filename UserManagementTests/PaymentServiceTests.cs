using Lap5;
using Moq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace UserManagementTests
{
    public class PaymentServiceTests
    {
        [Fact]
        public void MakePayment_ShouldReturnTrue_WhenPaymentIsSuccessful()
        {
            // Arrange
            var mockGateway = new Mock<IPaymentGateway>();
            mockGateway.Setup(g => g.ProcessPayment(It.IsAny<string>(), It.IsAny<decimal>())).Returns(true);

            var service = new PaymentService(mockGateway.Object);

            // Act
            var result = service.MakePayment("12345", 100);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void MakePayment_ShouldThrowException_ForInvalidAccountNumber()
        {
            var mockGateway = new Mock<IPaymentGateway>();
            var service = new PaymentService(mockGateway.Object);

            Assert.Throws<ArgumentException>(() => service.MakePayment("", 100));
        }
    }
}
