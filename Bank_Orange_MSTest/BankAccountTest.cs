using Bank_Orange;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Bank_Orange_MSTest
{
    [TestClass]
    public class BankAccountTest
    {
        [TestMethod]
        public void AddNewBankAccount_ShouldReturnIsSavingsAccountFalse()
        {
            //Arrange
            BankAccount bankAcc = new BankAccount();


            //Act
            var input = new StringReader("1");
            Console.SetIn(input);

            bankAcc.AddNewBankAccount();


            //Assert
            Assert.IsFalse(bankAcc.isSavingsAccount);
        }

        [TestMethod]
        public void AddNewBankAccount_ShouldReturnIsSavingsAccountFalseException()
        {
            //Arrange
            BankAccount bankAcc = new BankAccount();


            //Act
            var input = new StringReader("12");
            Console.SetIn(input);

            bankAcc.AddNewBankAccount();


            //Assert
            Assert.IsFalse(bankAcc.isSavingsAccount);
        }

        [TestMethod]
        public void AddNewBankAccount_ShouldReturnIsSavingsAccountTrue()
        {
            //Arrange
            BankAccount bankAcc = new BankAccount();


            //Act
            var input = new StringReader("2");
            Console.SetIn(input);

            bankAcc.AddNewBankAccount();


            //Assert
            Assert.IsTrue(bankAcc.isSavingsAccount);
        }

        [TestMethod]
        public void AddNewBankAccount_ShouldReturnCurrencyKrAndCurrencyPositionTrue()
        {
            //Arrange
            BankAccount bankAcc = new BankAccount();


            //Act
            var input = new StringReader("1\nFilips\n1\n300");
            Console.SetIn(input);

            bankAcc.AddNewBankAccount();


            //Assert
            Assert.AreEqual("Kr", bankAcc.currency);
            Assert.IsTrue(bankAcc.currencyPosition);
        }

        [TestMethod]
        public void AddNewBankAccount_ShouldReturnCurrencyDollarAndCurrencyPositionFalse()
        {
            //Arrange
            BankAccount bankAcc = new BankAccount();
            CurrencyExchanges cExchanges = new CurrencyExchanges(10, 10);
            bankAcc.currencyExchanges = cExchanges;


            //Act
            var input = new StringReader("1\nFilips\n2\n300");
            Console.SetIn(input);

            bankAcc.AddNewBankAccount();


            //Assert
            Assert.AreEqual("$", bankAcc.currency);
            Assert.IsFalse(bankAcc.currencyPosition);
        }

        [TestMethod]
        public void AddNewBankAccount_ShouldReturnCurrencyEuroAndCurrencyPositionFalse()
        {
            //Arrange
            BankAccount bankAcc = new BankAccount();
            CurrencyExchanges cExchanges = new CurrencyExchanges(10, 10);
            bankAcc.currencyExchanges = cExchanges;


            //Act
            var input = new StringReader("1\nFilips\n3\n300");
            Console.SetIn(input);

            bankAcc.AddNewBankAccount();


            //Assert
            Assert.AreEqual("€", bankAcc.currency);
            Assert.IsFalse(bankAcc.currencyPosition);
        }

        [TestMethod]
        public void AddNewBankAccount_ShouldReturnCurrencyKrAndCurrencyPositionTrueDefault()
        {
            //Arrange
            BankAccount bankAcc = new BankAccount();


            //Act
            var input = new StringReader("1\nFilips\n12\n300");
            Console.SetIn(input);

            bankAcc.AddNewBankAccount();


            //Assert
            Assert.AreEqual("Kr", bankAcc.currency);
            Assert.IsTrue(bankAcc.currencyPosition);
        }

        [TestMethod]
        public void AddNewBankAccount_ShouldFindAnAccoutDetailsObjectInBankAccountList()
        {
            //Arrange
            BankAccount bankAcc = new BankAccount();


            //Act
            AccountDetails expected = new AccountDetails("Filips", 300.0m, "Kr", true, false, 0);

            var input = new StringReader("1\nFilips\n1\n300");
            Console.SetIn(input);

            bankAcc.AddNewBankAccount();

            //Assert
            CollectionAssert.Contains(bankAcc.BankAccountList, expected);
        }
    }
}