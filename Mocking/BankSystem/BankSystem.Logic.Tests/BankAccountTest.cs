using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankSystem.Logics;
using Moq;

namespace BankSystem.Logic.Tests
{
    [TestClass]
    public class BankAccountTest
    {
        [TestMethod]
        public void Constructor_ShouldSetMoneyTo0()
        {
            BankAccount bankAccount = new BankAccount();
            Assert.AreEqual(0, bankAccount.Money);
        }

        [TestMethod]
        public void Deposit_ShouldAddToMoneyTo()
        {
            BankAccount bankAccount = new BankAccount();
            bankAccount.Deposit(582);
            Assert.AreEqual(582, bankAccount.Money);
        }

        [TestMethod]
        public void DepositAndThanWithdraw_ShouldLeaveMoneyTo0()
        {
            BankAccount bankAccount = new BankAccount();
            bankAccount.Deposit(582);
            bankAccount.Withdraw(582);
            Assert.AreEqual(0, bankAccount.Money);
        }

        [TestMethod] //new feature coming from the clients 
        public void Deposit_ShouldNotThrowExceptionWhenLoggerFails()
        {
            var loggerMock = new Mock<ILogger>();
            //todo: add throw new Exception in loggerMock - how to do it - with SetUp
            loggerMock.Setup(
                x => x.Log(It.IsAny<string>()))
                .Throws(new Exception());

            var bankAccount = new BankAccount(loggerMock.Object);
            bankAccount.Deposit(100);
        }

        [TestMethod] //new feature coming from the clients 
        public void Deposit_ShouldWriteMessageInTestOutput()
        {
            string message = "";
            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(
                x => x.Log(It.IsAny<string>()))
                .Callback<string>((x) => message = x);

            var bankAccount = new BankAccount(loggerMock.Object);
            bankAccount.Deposit(100);
            Console.WriteLine(message);
        }



        //using moq to write the same as below without the nees of extra class
        [TestMethod]
        public void TestWithMoq_Deposit_ShouldLogTransaction()
        {
            var mockedLogger = new Mock<ILogger>();
            var bankAccount = new BankAccount(mockedLogger.Object);
            bankAccount.Deposit(1000);
            mockedLogger.Verify(
           //   x => x.Log(It.IsAny<string>()),
           //x => x.Log(It.Is<string>(y => y =="neshtoSpecifichno")),
           x => x.Log(It.IsNotNull<string>()),
           //x => x.Log(It.Is<string>(y => y.Contains("deposit"))),
           Times.Exactly(1));  //Once()); 
        }



        //this test Methods depends on the mocking class/object that 
        //we have created below, if order not to creat such an objects
        //every time, we use MOQ or JUST MOCK
        [TestMethod]
        public void Deposit_ShouldLogTransaction()
        {
            var mockedLogger = new IsLogMethodCalledLogger();
            var bankAccount = new BankAccount(mockedLogger);
            bankAccount.Deposit(1000);
            Assert.IsTrue(mockedLogger.LogIsCalled);
        }
    }

    public class IsLogMethodCalledLogger : ILogger
    {
        public bool LogIsCalled { get; private set; }
        public void Log(string message)
        {
            this.LogIsCalled = true;
        }
    }

}
