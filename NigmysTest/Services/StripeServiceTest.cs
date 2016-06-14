using System;
using NUnit.Framework;
using Moq;
using Stripe;
using Nigmys.Services.StripeAccessorService;
using Nigmys.Errors.StripeAccessorErrors;

namespace NigmysTest
{

    [TestFixture]
    public class StripeServiceTest
    {
        //Variables
        IStripeAccessorService stripeAccessor;
        Mock<StripeSubscriptionService> subService;
        Mock<StripeChargeService> charService;
        Mock<StripeCustomerService> cusService;

        string customerId = "cus_123x";
        string subscriptionId = "sub_123x";
        string chargeId = "char_123x";
        string planId = "plan_123x";

        [OneTimeSetUp]
        public void Init()
        {
            //Arrange: Mock Setup
            subService = new Mock<StripeSubscriptionService>(null);
            charService = new Mock<StripeChargeService>(null);
            cusService = new Mock<StripeCustomerService>(null);
        }

        [OneTimeTearDown]
        public void Dispose()
        {

        }

        /// <summary>
        /// Test a successful subscription cancelation
        /// </summary>
        [Test]
        public void CancelSubscription_SubscriptionExists_Successful()
        {
            //Arrange
            stripeAccessor = new StripeAccessorService(subService.Object, charService.Object, cusService.Object);

            //Act
            string returnedId = stripeAccessor.CancelSubscription(customerId, subscriptionId);

            //Assert
            Assert.That(returnedId, Is.EqualTo(subscriptionId));
        }

        /// <summary>
        /// Test a Stripe Exception is thrown
        /// </summary>
        [Test]
        public void CancelSubscription_InvalidParameters_ThrowsStripeException()
        {
            //Arrange
            StripeException exception = new StripeException();
            exception.StripeError = new StripeError();
            exception.StripeError.ErrorType = "invalid_request";

            Mock<StripeSubscriptionService> custSubService = new Mock<StripeSubscriptionService>(null);
            custSubService.Setup(sub => sub.Cancel(It.IsAny<string>(), It.IsAny<string>(), false, null)).Throws(exception);
            stripeAccessor = new StripeAccessorService(custSubService.Object, charService.Object, cusService.Object);

            //Act
            string returnMessage = stripeAccessor.CancelSubscription(customerId, subscriptionId);

            //Assert
            Assert.That(returnMessage, Is.EqualTo("invalid_request"));
        }

        /// <summary>
        /// Test if a regular exception is thrown
        /// </summary>
        [Test]
        public void CancelSubscription_InvalidParameters_ThrowsException()
        {
            //Arrange
            Exception exception = new Exception();

            Mock<StripeSubscriptionService> custSubService = new Mock<StripeSubscriptionService>(null);
            custSubService.Setup(sub => sub.Cancel(It.IsAny<string>(), It.IsAny<string>(), false, null)).Throws(exception);
            stripeAccessor = new StripeAccessorService(custSubService.Object, charService.Object, cusService.Object);

            //Act
            string returnMessage = stripeAccessor.CancelSubscription(customerId, subscriptionId);

            //Assert
            Assert.That(returnMessage, Is.Null);
        }

        /// <summary>
        /// Test a succussful charge of customer
        /// </summary>
        [Test]
        public void ChargeCustomer_ValidParameters_Successful()
        {
            //Arrange
            StripeCharge charge = new StripeCharge();
            charge.Id = chargeId;

            Mock<StripeChargeService> custChargeService = new Mock<StripeChargeService>(null);
            custChargeService.Setup(charg => charg.Create(It.IsAny<StripeChargeCreateOptions>(), null))
                .Returns(charge);
            stripeAccessor = new StripeAccessorService(subService.Object, custChargeService.Object, cusService.Object);

            //Act
            String returnedId = stripeAccessor.ChargeCustomer(customerId, 2, 15, 2016, 1, 25);

            //Assert
            Assert.That(returnedId, Is.EqualTo(chargeId));
        }

        /// <summary>
        /// Test a charged throw of Stripe Exception
        /// </summary>
        [Test]
        public void ChargeCustomer_InvalidParameters_ThrowsStripeException()
        {
            //Arrange
            StripeException exception = new StripeException();
            exception.StripeError = new StripeError();
            exception.StripeError.ErrorType = "invalid_request";

            Mock<StripeChargeService> custChargeService = new Mock<StripeChargeService>(null);
            custChargeService.Setup(charg => charg.Create(It.IsAny<StripeChargeCreateOptions>(), null))
                .Throws(exception);
            stripeAccessor = new StripeAccessorService(subService.Object, custChargeService.Object, cusService.Object);

            //Act
            String returnedException = stripeAccessor.ChargeCustomer(customerId, 2, 15, 2016, 1, 25);

            //Assert
            Assert.That(returnedException, Is.EqualTo("invalid_request"));
        }

        /// <summary>
        /// Test a charged throw of Exception
        /// </summary>
        [Test]
        public void ChargeCustomer_InvalidParameters_ThrowsException()
        {
            //Arrange
            Exception exception = new Exception();

            Mock<StripeChargeService> custChargeService = new Mock<StripeChargeService>(null);
            custChargeService.Setup(charg => charg.Create(It.IsAny<StripeChargeCreateOptions>(), null))
                .Throws(exception);
            stripeAccessor = new StripeAccessorService(subService.Object, custChargeService.Object, cusService.Object);

            //Act
            //Act
            String returnedException = stripeAccessor.ChargeCustomer(customerId, 2, 15, 2016, 1, 25);

            //Assert
            Assert.That(returnedException, Is.Null);
        }

        /// <summary>
        /// Test a successful creation of customer in stripe
        /// </summary>
        [Test]
        public void CreateCustomer_ValidParameters_Successful()
        {
            //Arrange
            StripeCustomer customer = new StripeCustomer();
            customer.Id = customerId;

            Mock<StripeCustomerService> custCustService = new Mock<StripeCustomerService>(null);
            custCustService.Setup(cust => cust.Create(It.IsAny<StripeCustomerCreateOptions>(), null))
                .Returns(customer);
            stripeAccessor = new StripeAccessorService(subService.Object, charService.Object, custCustService.Object);

            //Act
            StripeObject returnedCustomer = stripeAccessor.CreateCustomer("email", "Hal", "Wilkerson");

            //Assert
            Assert.That(returnedCustomer.Id, Is.EqualTo(customerId));
            Assert.That(returnedCustomer, Is.InstanceOf<StripeCustomer>());
        }

        /// <summary>
        /// Test a create customer call with Stripe Exception
        /// </summary>
        [Test]
        public void CreateCustomer_InvalidParameters_ThrowsStripeException()
        {
            //Arrange
            StripeException exception = new StripeException();
            exception.StripeError = new StripeError();
            CreateCustomerError error;
            exception.StripeError.ErrorType = "invalid_request";

            Mock<StripeCustomerService> custCustService = new Mock<StripeCustomerService>(null);
            custCustService.Setup(cust => cust.Create(It.IsAny<StripeCustomerCreateOptions>(), null))
                .Throws(exception);
            stripeAccessor = new StripeAccessorService(subService.Object, charService.Object, custCustService.Object);

            //Act
            StripeObject returnedException = stripeAccessor.CreateCustomer("email", "Hal", "Wilkerson");
            error = (CreateCustomerError)returnedException;

            //Assert
            Assert.That(returnedException, Is.InstanceOf<CreateCustomerError>());
            Assert.That(error.Error_Type, Is.EqualTo("invalid_request"));
        }

        /// <summary>
        /// Test a create customer call with Exception
        /// </summary>
        [Test]
        public void CreateCustomer_InvalidParameters_ThrowsException()
        {
            //Arrange
            Exception exception = new Exception();

            Mock<StripeCustomerService> custCustService = new Mock<StripeCustomerService>(null);
            custCustService.Setup(cust => cust.Create(It.IsAny<StripeCustomerCreateOptions>(), null))
                .Throws(exception);
            stripeAccessor = new StripeAccessorService(subService.Object, charService.Object, custCustService.Object);

            //Act
            StripeObject returnedException = stripeAccessor.CreateCustomer("email", "Hal", "Wilkerson");

            //Assert
            Assert.That(returnedException, Is.Null);
        }

        /// <summary>
        /// Test proper creation of subscription
        /// </summary>
        [Test]
        public void SubscribeCustomer_ValidParameters_Successful()
        {
            //Arrange
            StripeSubscription subscription = new StripeSubscription();
            subscription.Id = subscriptionId;

            Mock<StripeSubscriptionService> custSubService = new Mock<StripeSubscriptionService>(null);
            custSubService.Setup(sub => sub.Create(It.IsAny<string>(), It.IsAny<string>(), null, null)).Returns(subscription);
            stripeAccessor = new StripeAccessorService(custSubService.Object, charService.Object, cusService.Object);

            //Act
            string returnedId = stripeAccessor.SubscribeCustomer(customerId, planId);

            //Assert
            Assert.That(returnedId, Is.EqualTo(subscriptionId));
        }

        /// <summary>
        /// Test proper throw of Stripe Exception
        /// </summary>
        [Test]
        public void SubscribeCustomer_InvalidParameters_ThrowsStripeException()
        {
            //Arrange
            StripeException exception = new StripeException();
            exception.StripeError = new StripeError();
            exception.StripeError.ErrorType = "invalid_request";

            Mock<StripeSubscriptionService> custSubService = new Mock<StripeSubscriptionService>(null);
            custSubService.Setup(sub => sub.Create(It.IsAny<string>(), It.IsAny<string>(), null, null)).Throws(exception);
            stripeAccessor = new StripeAccessorService(custSubService.Object, charService.Object, cusService.Object);

            //Act
            string returnedException = stripeAccessor.SubscribeCustomer(customerId, planId);

            //Arrange
            Assert.That(returnedException, Is.EqualTo("invalid_request"));
        }

        /// <summary>
        /// Test proper subscription throw of Exception
        /// </summary>
        [Test]
        public void SubscribeCustomer_InvalidParameters_ThrowsException()
        {
            //Arrange
            Exception exception = new Exception();

            Mock<StripeSubscriptionService> custSubService = new Mock<StripeSubscriptionService>(null);
            custSubService.Setup(sub => sub.Create(It.IsAny<string>(), It.IsAny<string>(), null, null)).Throws(exception);
            stripeAccessor = new StripeAccessorService(custSubService.Object, charService.Object, cusService.Object);

            //Act
            string returnedException = stripeAccessor.SubscribeCustomer(customerId, planId);

            //Arrange
            Assert.That(returnedException, Is.Null);
        }

        /// <summary>
        /// Test succussful update of customer information
        /// </summary>
        [Test]
        public void UpdateCustomer_ValidParameters_Successful()
        {
            //Arrange
            StripeCustomer customer = new StripeCustomer();
            customer.Id = customerId;

            Mock<StripeCustomerService> custCustService = new Mock<StripeCustomerService>(null);
            custCustService.Setup(cust => cust.Update(It.IsAny<string>(), It.IsAny<StripeCustomerUpdateOptions>(), null))
                .Returns(customer);
            stripeAccessor = new StripeAccessorService(subService.Object, charService.Object, custCustService.Object);

            //Act
            string returnedId = stripeAccessor.UpdateCustomer(customerId, "email", "Hal", "Wilkerson");

            //Assert
            Assert.That(returnedId, Is.EqualTo(customerId));
        }

        /// <summary>
        /// Test proper throw of Stripe Exception when updating customer
        /// </summary>
        [Test]
        public void UpdateCustomer_InvalidParameters_ThrowsStripeException()
        {
            //Arrange
            StripeException exception = new StripeException();
            exception.StripeError = new StripeError();
            exception.StripeError.ErrorType = "invalid_request";

            Mock<StripeCustomerService> custCustService = new Mock<StripeCustomerService>(null);
            custCustService.Setup(cust => cust.Update(It.IsAny<string>(), It.IsAny<StripeCustomerUpdateOptions>(), null))
                .Throws(exception);
            stripeAccessor = new StripeAccessorService(subService.Object, charService.Object, custCustService.Object);

            //Act
            string returnedException = stripeAccessor.UpdateCustomer(customerId, "email", "Hal", "Wilkerson");

            //Assert
            Assert.That(returnedException, Is.EqualTo("invalid_request"));
        }

        /// <summary>
        /// Test proper throw of Exception when updating customer
        /// </summary>
        [Test]
        public void UpdateCustomer_InvalidParameters_ThrowsException()
        {
            //Arrange
            Exception exception = new Exception();

            Mock<StripeCustomerService> custCustService = new Mock<StripeCustomerService>(null);
            custCustService.Setup(cust => cust.Update(It.IsAny<string>(), It.IsAny<StripeCustomerUpdateOptions>(), null))
                .Throws(exception);
            stripeAccessor = new StripeAccessorService(subService.Object, charService.Object, custCustService.Object);

            //Act
            string returnedException = stripeAccessor.UpdateCustomer(customerId, "email", "Hal", "Wilkerson");

            //Assert
            Assert.That(returnedException, Is.Null);
        }

        /// <summary>
        /// Test successful update of subscription
        /// </summary>
        [Test]
        public void UpdateSubscription_ValidParameters_Successful()
        {
            //Arrange
            StripeSubscription subscription = new StripeSubscription();
            subscription.Id = subscriptionId;

            Mock<StripeSubscriptionService> custSubService = new Mock<StripeSubscriptionService>(null);
            custSubService.Setup(sub => sub.Update(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<StripeSubscriptionUpdateOptions>(), null)).Returns(subscription);
            stripeAccessor = new StripeAccessorService(custSubService.Object, charService.Object, cusService.Object);

            //Act
            string returnedId = stripeAccessor.UpdateSubscription(customerId, subscriptionId, planId);

            //Assert
            Assert.That(returnedId, Is.EqualTo(subscriptionId));
        }

        /// <summary>
        /// Test proper throw of Stripe Exception when updating subscription
        /// </summary>
        [Test]
        public void UpdateSubscription_InvalidParameters_ThrowsStripeException()
        {
            //Arrange
            StripeException exception = new StripeException();
            exception.StripeError = new StripeError();
            exception.StripeError.ErrorType = "invalid_request";

            Mock<StripeSubscriptionService> custSubService = new Mock<StripeSubscriptionService>(null);
            custSubService.Setup(sub => sub.Update(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<StripeSubscriptionUpdateOptions>(), null)).Throws(exception);
            stripeAccessor = new StripeAccessorService(custSubService.Object, charService.Object, cusService.Object);

            //Act
            string returnedException = stripeAccessor.UpdateSubscription(customerId, subscriptionId, planId);

            //Assert
            Assert.That(returnedException, Is.EqualTo("invalid_request"));
        }

        /// <summary>
        /// Test proper throw of Exception when updating subscription
        /// </summary>
        [Test]
        public void UpdateSubscription_InvalidParameters_ThrowsException()
        {
            //Arrange
            Exception exception = new Exception();

            Mock<StripeSubscriptionService> custSubService = new Mock<StripeSubscriptionService>(null);
            custSubService.Setup(sub => sub.Update(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<StripeSubscriptionUpdateOptions>(), null)).Throws(exception);
            stripeAccessor = new StripeAccessorService(custSubService.Object, charService.Object, cusService.Object);

            //Act
            string returnedException = stripeAccessor.UpdateSubscription(customerId, subscriptionId, planId);

            //Assert
            Assert.That(returnedException, Is.Null);
        }
    }
}
