using Bank_Orange;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace Bank_Orange_MSTest
{
    [TestClass]
    public class BankSystemTest
    {
        [TestMethod]
        [Category("BorrowMoney")]
        public void BorrowMoney_ShouldReturnMaxAmountToBorrow()
        {
            //Arrange
            BankSystem system = new BankSystem();
            BankAccount bankAccount1 = new BankAccount();
            AccountDetails ac1 = new AccountDetails("AccountP1", 1000, "Kr", false, false, 0);
            bankAccount1.BankAccountList.Add(ac1);
            system.AccountDictionary.Add(0, bankAccount1);
            system.InLoggedUserAccount = bankAccount1;

            //Act
            var input = new StringReader("2000");
            Console.SetIn(input);

            var consoleOutPut = new StringWriter();
            Console.SetOut(consoleOutPut);

            system.BorrowMoney();
            var outPut = consoleOutPut.ToString();

            //Assert
            StringAssert.Contains(outPut, "Max amount to borrow is 5.000,00 Kr");
        }

        [TestMethod]
        [Category("BorrowMoney")]
        public void BorrowMoney_ShouldReturnSomethingWentWrongMessage()
        {
            //Arrange
            BankSystem system = new BankSystem();
            BankAccount bankAccount1 = new BankAccount();
            AccountDetails ac1 = new AccountDetails("AccountP1", 1000, "Kr", false, false, 0);
            bankAccount1.BankAccountList.Add(ac1);
            system.AccountDictionary.Add(0, bankAccount1);
            system.InLoggedUserAccount = bankAccount1;

            //Act
            var input = new StringReader("-500");
            Console.SetIn(input);

            var consoleOutPut = new StringWriter();
            Console.SetOut(consoleOutPut);

            system.BorrowMoney();
            var outPut = consoleOutPut.ToString();

            //Assert
            StringAssert.Contains(outPut, "Something went wrong, please try again.");
        }

        [TestMethod]
        [Category("BorrowMoney")]
        public void BorrowMoney_ShouldReturnTheYearlyInterestAmount()
        {
            //Arrange
            BankSystem system = new BankSystem();
            BankAccount bankAccount1 = new BankAccount();
            AccountDetails ac1 = new AccountDetails("AccountP1", 1000, "Kr", false, false, 0);
            bankAccount1.BankAccountList.Add(ac1);
            system.AccountDictionary.Add(0, bankAccount1);
            system.InLoggedUserAccount = bankAccount1;

            //Act
            var input = new StringReader("2000");
            Console.SetIn(input);

            var consoleOutPut = new StringWriter();
            Console.SetOut(consoleOutPut);

            system.BorrowMoney();
            var outPut = consoleOutPut.ToString();

            //Assert
            StringAssert.Contains(outPut, "Your yearly paid interest will be 70,00kr!");
        }

        [TestMethod]
        [Category("BorrowMoney")]
        public void BorrowMoney_ShouldReturnTransfereWasCanceledMessage()
        {
            //Arrange
            BankSystem system = new BankSystem();
            BankAccount bankAccount1 = new BankAccount();
            AccountDetails ac1 = new AccountDetails("AccountP1", 1000, "Kr", false, false, 0);
            bankAccount1.BankAccountList.Add(ac1);
            system.AccountDictionary.Add(0, bankAccount1);
            system.InLoggedUserAccount = bankAccount1;

            //Act
            var input = new StringReader("2000\n2");
            Console.SetIn(input);

            var consoleOutPut = new StringWriter();
            Console.SetOut(consoleOutPut);

            system.BorrowMoney();
            var outPut = consoleOutPut.ToString();

            //Assert
            StringAssert.Contains(outPut, "Transfer was cancelled!");
        }

        [TestMethod]
        [Category("BorrowMoney")]
        public void BorrowMoney_ShouldReturnNotEligibleForThisLoanMessage()
        {
            //Arrange
            BankSystem system = new BankSystem();
            BankAccount bankAccount1 = new BankAccount();
            AccountDetails ac1 = new AccountDetails("AccountP1", 1000, "Kr", false, false, 0);
            bankAccount1.BankAccountList.Add(ac1);
            system.AccountDictionary.Add(0, bankAccount1);
            system.InLoggedUserAccount = bankAccount1;

            //Act
            var input = new StringReader("8000");
            Console.SetIn(input);

            var consoleOutPut = new StringWriter();
            Console.SetOut(consoleOutPut);

            system.BorrowMoney();
            var outPut = consoleOutPut.ToString();

            //Assert
            StringAssert.Contains(outPut, "You are not eligible for this loan!");
        }

        [TestMethod]
        [Category("BorrowMoney")]
        public void BorrowMoney_ShouldReturnTransferCompleteMessage()
        {
            //Arrange
            BankSystem system = new BankSystem();
            BankAccount bankAccount1 = new BankAccount();
            AccountDetails ac1 = new AccountDetails("AccountP1", 1000, "Kr", false, false, 0);
            bankAccount1.BankAccountList.Add(ac1);
            system.AccountDictionary.Add(0, bankAccount1);
            system.InLoggedUserAccount = bankAccount1;

            //Act
            var input = new StringReader("4000\n1");
            Console.SetIn(input);

            var consoleOutPut = new StringWriter();
            Console.SetOut(consoleOutPut);

            system.BorrowMoney();
            var outPut = consoleOutPut.ToString();

            //Assert
            StringAssert.Contains(outPut, "Transfer Complete!");
        }

        
    }
}
