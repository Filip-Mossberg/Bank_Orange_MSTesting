using Bank_Orange;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Transactions;

namespace Bank_Orange_MSTest
{
    [TestClass]
    public class BankAccountTest
    {
        [TestMethod]
        [Category("AddNewBankAccount")]
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
        [Category("AddNewBankAccount")]
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
        [Category("AddNewBankAccount")]
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
        [Category("AddNewBankAccount")]
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
        [Category("AddNewBankAccount")]
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
        [Category("AddNewBankAccount")]

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
        [Category("AddNewBankAccount")]
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
        [Category("AddNewBankAccount")]
        public void AddNewBankAccount_ShouldFindAnAccoutDetailsObjectInBankAccountList()
        {
            //Arrange
            BankAccount bankAcc = new BankAccount();

            //Act
            var input = new StringReader("1\nFilips\n1\n300");
            Console.SetIn(input);

            int before = bankAcc.BankAccountList.Count;
            bankAcc.AddNewBankAccount();
            int after = bankAcc.BankAccountList.Count;

            //Assert
            Assert.IsTrue(before < after);

        }

        [TestMethod]
        [Category("SendMoney")]
        public void SendMoney_ShouldReturnEnterValidNumberMessage()
        {
            //Arrange
            BankAccount bc1 = new BankAccount();
            AccountDetails account1 = new AccountDetails("Filips", 1000.00m, "Kr", true, false, 0);
            AccountDetails account2 = new AccountDetails("Filips2", 1000.00m, "Kr", true, false, 1);
            bc1.BankAccountList.Add(account1);
            bc1.BankAccountList.Add(account2);

            //Act
            var input = new StringReader("1\n0");
            Console.SetIn(input);

            var consoleOutPut = new StringWriter();
            Console.SetOut(consoleOutPut);

            bc1.SendMoney(1);
            var outPut = consoleOutPut.ToString();

            //Assert
            StringAssert.Contains(outPut, "Please enter a valid number.");
        }

        [TestMethod]
        [Category("SendMoney")]
        public void SendMoney_ShouldReturnCanNotSendANegativeAmountMessage()
        {
            //Arrange
            BankAccount bc1 = new BankAccount();
            AccountDetails account1 = new AccountDetails("Filips", 1000.00m, "Kr", true, false, 0);
            AccountDetails account2 = new AccountDetails("Filips2", 1000.00m, "Kr", true, false, 1);
            bc1.BankAccountList.Add(account1);
            bc1.BankAccountList.Add(account2);

            //Act
            var input = new StringReader("1\n-100");
            Console.SetIn(input);

            var consoleOutPut = new StringWriter();
            Console.SetOut(consoleOutPut);

            bc1.SendMoney(1);
            var outPut = consoleOutPut.ToString();

            //Assert
            StringAssert.Contains(outPut, "Can not send a negative amount.");
        }

        [TestMethod]
        [Category("SendMoney")]
        public void SendMoney_ShouldReturnInsufficientFundsMessage()
        {
            //Arrange
            BankAccount bc1 = new BankAccount();
            AccountDetails account1 = new AccountDetails("Filips", 1000.00m, "Kr", true, false, 0);
            AccountDetails account2 = new AccountDetails("Filips2", 1000.00m, "Kr", true, false, 1);
            bc1.BankAccountList.Add(account1);
            bc1.BankAccountList.Add(account2);

            //Act
            var input = new StringReader("1\n10000");
            Console.SetIn(input);

            var consoleOutPut = new StringWriter();
            Console.SetOut(consoleOutPut);

            bc1.SendMoney(1);
            var outPut = consoleOutPut.ToString();

            //Assert
            StringAssert.Contains(outPut, "Insufficent funds.");
        }

        [TestMethod]
        [Category("SendMoney")]
        public void SendMoney_ShouldReturnAccountDoesNotExistMessage()
        {
            //Arrange
            BankAccount bc1 = new BankAccount();
            AccountDetails account1 = new AccountDetails("Filips", 1000.00m, "Kr", true, false, 0);
            AccountDetails account2 = new AccountDetails("Filips2", 1000.00m, "Kr", true, false, 1);
            bc1.BankAccountList.Add(account1);
            bc1.BankAccountList.Add(account2);

            //Act
            var input = new StringReader("10\n100");
            Console.SetIn(input);

            var consoleOutPut = new StringWriter();
            Console.SetOut(consoleOutPut);

            bc1.SendMoney(1);
            var outPut = consoleOutPut.ToString();

            //Assert
            StringAssert.Contains(outPut, "One of the accounts you are trying to access does not exist.");
        }

        [TestMethod]
        [Category("SendMoney")]
        public void SendMoney_ShouldReturnTransactionHasBeenSuccessfulMessage()
        {
            //Arrange
            BankAccount bc1 = new BankAccount();
            AccountDetails account1 = new AccountDetails("Filips", 1000.00m, "Kr", true, false, 0);
            AccountDetails account2 = new AccountDetails("Filips2", 1000.00m, "Kr", true, false, 1);
            bc1.BankAccountList.Add(account1);
            bc1.BankAccountList.Add(account2);

            //Act
            var input = new StringReader("1\n100");
            Console.SetIn(input);

            var consoleOutPut = new StringWriter();
            Console.SetOut(consoleOutPut);

            bc1.SendMoney(1);
            var outPut = consoleOutPut.ToString();

            //Assert
            StringAssert.Contains(outPut, "Transaction has been successful.");
        }

        [TestMethod]
        [Category("SendMoney")]
        public void SendMoney_ShouldReturnTrueThatMoneyHasBeenRemovedFromSederAccount()
        {
            //Arrange
            BankAccount bc1 = new BankAccount();
            AccountDetails account1 = new AccountDetails("Filips", 1000.00m, "Kr", true, false, 0);
            AccountDetails account2 = new AccountDetails("Filips2", 1000.00m, "Kr", true, false, 1);
            bc1.BankAccountList.Add(account1);
            bc1.BankAccountList.Add(account2);

            //Act
            var input = new StringReader("1\n100");
            Console.SetIn(input);

            decimal before = account1.Money;
            bc1.SendMoney(1);
            decimal after = bc1.sendAccount.Money;

            //Assert
            Assert.IsTrue(before > after);
            Assert.IsTrue(before == 1000);
            Assert.IsTrue(after == 900);
        }
    }
}