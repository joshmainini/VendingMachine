using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class VendingMachineTest
    {
        [TestMethod]
        public void SaleCountTest_0()
        {
            VendingMachine myMachine = new VendingMachine();
            Assert.AreEqual(0, myMachine.SaleCount("A1"));

        }
        [TestMethod]
        public void SaleCountTest_1()
        {
            VendingMachine myMachine = new VendingMachine();
            myMachine.SellItem("A1");
            Assert.AreEqual(1, myMachine.SaleCount("A1"));

        }
        [TestMethod]
        public void GetQuantityTest_5()
        {
            VendingMachine myMachine = new VendingMachine();
            Assert.AreEqual(5, myMachine.GetQuantity("A1"));
        }
        [TestMethod]
        public void GetQuantityTest_4()
        {
            VendingMachine myMachine = new VendingMachine();
            myMachine.SellItem("A1");
            Assert.AreEqual(4, myMachine.GetQuantity("A1"));
        }
        [TestMethod]
        public void MachineContains_true()
        {
            VendingMachine myMachine = new VendingMachine();
            Assert.AreEqual(true, myMachine.MachineContains("A1"));
        }
        [TestMethod]
        public void MachineContains_false()
        {
            VendingMachine myMachine = new VendingMachine();
            Assert.AreEqual(false, myMachine.MachineContains("Q8"));
        }
        [TestMethod]
        public void MachineProductName_PotatoCrisps()
        {
            VendingMachine myMachine = new VendingMachine();
            Assert.AreEqual("Potato Crisps", myMachine.MachineProductName("A1"));
        }
        [TestMethod]
        public void MachineProductName_UChews()
        {
            VendingMachine myMachine = new VendingMachine();
            Assert.AreEqual("U-Chews", myMachine.MachineProductName("D1"));
        }
        [TestMethod]
        public void MachineProductName_DrSalt()
        {
            VendingMachine myMachine = new VendingMachine();
            Assert.AreEqual("Dr. Salt", myMachine.MachineProductName("C2"));
        }
        [TestMethod]
        public void MachineProductPrice_PotatoCrisps()
        {
            VendingMachine myMachine = new VendingMachine();
            Assert.AreEqual(3.05m, myMachine.MachineProductPrice("A1"));
        }
        [TestMethod]
        public void MachineProductPrice_Cola()
        {
            VendingMachine myMachine = new VendingMachine();
            Assert.AreEqual(1.25m, myMachine.MachineProductPrice("C1"));
        }
        [TestMethod]
        public void MachineProductPrice_GrainWaves()
        {
            VendingMachine myMachine = new VendingMachine();
            Assert.AreEqual(2.75m, myMachine.MachineProductPrice("A3"));
        }
        [TestMethod]
        public void ToString_ChipTest()
        {
            VendingMachine myMachine = new VendingMachine();
            Assert.AreEqual("Crunch Crunch Yum!", myMachine.ToString("A3"));
        }
        [TestMethod]
        public void ToString_GumTest()
        {
            VendingMachine myMachine = new VendingMachine();
            Assert.AreEqual("Chew Chew Yum!", myMachine.ToString("D1"));
        }
        [TestMethod]
        public void ToString_CandyTest()
        {
            VendingMachine myMachine = new VendingMachine();
            Assert.AreEqual("Munch Munch Yum!", myMachine.ToString("B1"));
        }
        [TestMethod]
        public void ToString_DrinkTest()
        {
            VendingMachine myMachine = new VendingMachine();
            Assert.AreEqual("Glug Glug Yum!", myMachine.ToString("C1"));
        }
    }
}
