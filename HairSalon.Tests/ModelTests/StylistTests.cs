using System;
using System.Collections.Generic;
using HairSalon.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HairSalon.Tests {
    [TestClass]
    public class StylistTests : IDisposable {
        public StylistTests () {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=john_murray_test;";
        }

        [TestMethod]
        public void StylistsShouldBe0 () {
            //Arrange, Act
            int result = Stylist.GetAll ().Count;

            //Assert
            Assert.AreEqual (0, result);
        }

        [TestMethod]
        public void StylistNamesMatch () {
            //Arrange, Act
            Stylist firstStylist = new Stylist ("Stylist");
            Stylist secondStylist = new Stylist ("Stylist");

            //Assert
            Assert.AreEqual (firstStylist, secondStylist);
        }

        [TestMethod]
        public void Saves () {
            //Arrange
            Stylist testStylist = new Stylist ("Stylist");
            testStylist.Save ();

            //Act
            List<Stylist> result = Stylist.GetAll ();
            List<Stylist> testList = new List<Stylist> { testStylist };

            //Assert
            CollectionAssert.AreEqual (testList, result);
        }

        [TestMethod]
        public void FindStylistsinDatabase () {
            //Arrange
            Stylist testStylist = new Stylist ("Stylist");
            testStylist.Save ();

            //Act
            Stylist foundStylist = Stylist.Find (testStylist.GetId ());

            //Assert
            Assert.AreEqual (testStylist, foundStylist);
        }

        [TestMethod]
        public void GetAllClients () {
            Stylist testStylist = new Stylist ("Stylist");
            testStylist.Save ();

            Client firstClient = new Client ("clientOne", testStylist.GetId ());
            firstClient.Save ();
            Client secondClient = new Client ("clientTwo", testStylist.GetId ());
            secondClient.Save ();

            List<Client> testClientList = new List<Client> { firstClient, secondClient };
            List<Client> resultClientList = testStylist.GetClients ();

            CollectionAssert.AreEqual (testClientList, resultClientList);
        }

        public void Dispose () {
            Stylist.DeleteAll ();
        }
    }
} 