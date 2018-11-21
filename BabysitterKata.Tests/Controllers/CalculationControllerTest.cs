using System;
using System.Web.Mvc;
using BabysitterKata.Controllers;
using BabysitterKata.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BabysitterKata.Tests.Controllers
{
    [TestClass]
    public class CalculationControllerTest
    {
        [TestMethod]
        public void CalculateTotalPayA()
        {
            CalculationController controller = new CalculationController();

            CalculationViewModel vm = new CalculationViewModel
            {
                Family = "A",
                StartTime = "17",
                EndTime = "25"
            };

            var totalPay = controller.GetCalculation(vm);

            // Assert
            Assert.AreEqual(totalPay, 130);
        }

        [TestMethod]
        public void CalculateTotalPayB()
        {
            CalculationController controller = new CalculationController();

            CalculationViewModel vm = new CalculationViewModel
            {
                Family = "B",
                StartTime = "19",
                EndTime = "27"
            };

            var totalPay = controller.GetCalculation(vm);

            // Assert
            Assert.AreEqual(totalPay, 100);
        }
    }
}
