using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestCustomerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestCustomerService.Tests
{
    [TestClass()]
    public class CustomerServiceTests
    {
        [TestMethod()]
        public void GetCustomersTest()
        {
            CustomerService customerservice = new CustomerService();

            IList<Customer> customer = customerservice.GetCustomers();

            Assert.AreEqual(4, customer.Count);
        }

        [TestMethod()]
        public void PostCustomerTest()
        {
            CustomerService customerservice = new CustomerService();
            // Arrange
            IList<Customer> customerlist = customerservice.GetCustomers();
            // Act
            Customer customer05 = new Customer(5, "Frans", "Folles", 1972);
            customerlist.Add(customer05);
            // Assert
            Assert.AreEqual(5, customerlist.Count);
        }

        [TestMethod()]
        public void DeleteCustomerTest()
        {
            
            // Arrange
            CustomerService cs = new CustomerService();
            // Act
            Customer customer = cs.DeleteCustomer("1");
            // Assert
            Assert.AreEqual(1, customer.Id);
        }

        [TestMethod()]
        public void GetCustomersFromIdTest_fornavn()
        {
            // Arrange
            CustomerService cs = new CustomerService();
            // Act
            Customer customer = cs.GetCustomersFromId("1");
            // Assert
            Assert.AreEqual("Hans", customer.FirstName);
        }

        [TestMethod()]
        public void GetCustomersFromIdTest_efternavn()
        {
            // Arrange
            CustomerService cs = new CustomerService();
            // Act
            Customer customer = cs.GetCustomersFromId("1");
            // Assert
            Assert.AreEqual("Hansen", customer.LastName);
        }

        [TestMethod()]
        public void GetCustomersFromIdTest_year()
        {
            // Arrange
            CustomerService cs = new CustomerService();
            // Act
            Customer customer = cs.GetCustomersFromId("1");
            // Assert
            Assert.AreEqual(23, customer.Year);
        }

        [TestMethod()]
        public void GetCustomersFromIdTest_id()
        {
            // Arrange
            CustomerService cs = new CustomerService();
            // Act
            Customer customer = cs.GetCustomersFromId("1");
            // Assert
            Assert.AreEqual(1, customer.Id);
        }

        [TestMethod()]
        public void PutCustomerTest()
        {
            CustomerService customerservice = new CustomerService();
            // Arrange
            IList<Customer> customerlist = customerservice.GetCustomers();
            Customer customer05 = new Customer(4, "Fjolle", "Fjollesen", 1980);
            customerlist.Add(customer05);
            // Act
            Customer updatekunde = customerservice.PutCustomer(customer05.Id.ToString(), customer05);

            // Assert
            Assert.AreEqual("Fjolle", updatekunde.FirstName);
        }
    }
}