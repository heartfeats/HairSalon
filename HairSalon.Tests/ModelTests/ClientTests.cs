using System;
using System.Collections.Generic;
using HairSalon.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HairSalon.Tests {

    [TestClass]
    public class ClientTests : IDisposable {
        public ClientTests () {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=john_murray_test;";
        }

        public void Dispose () {
            Client.DeleteAll ();
            Stylist.DeleteAll ();
        }

        [TestMethod]
        public void SameNameisTrue () {
            //Arrange, Act
            Client firstClient = new Client ("client", 1);
            Client secondClient = new Client ("client", 1);

            //Assert
            Assert.AreEqual (firstClient, secondClient);
        }

        [TestMethod]
        public void SavesClientToList () {
            //Arrange
            Client testClient = new Client ("client", 1);
            testClient.Save ();

            //Act
            List<Client> result = Client.GetAll ();
            List<Client> testList = new List<Client> { testClient };

            //Assert
            CollectionAssert.AreEqual (testList, result);
        }

        [TestMethod]
        public void Save_DatabaseAssignsIdToObject_Id () {
            //Arrange
            Client testClient = new Client ("client", 1);
            testClient.Save ();

            //Act
            Client savedClient = Client.GetAll ()[0];

            int result = savedClient.GetId ();
            int testId = testClient.GetId ();

            //Assert
            Assert.AreEqual (testId, result);
        }

        [TestMethod]
        public void FindClient () {
            //Arrange
            Client testClient = new Client ("client", 1);
            testClient.Save ();

            //Act
            Client foundClient = Client.Find (testClient.GetId ());

            //Assert
            Assert.AreEqual (testClient, foundClient);
        }
    }
}