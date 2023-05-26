using Bank_Orange;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Bank_Orange_MSTest
{
    [TestClass]
    public class BankSystemTest
    {
        //[TestMethod]
        //public void TransfereBetweenUsers_ShouldReturnAPendingTransactionInQueue()
        //{
        //    //Arrange
        //    BankSystem system = new BankSystem();
        //    BankAccount bankAccount1 = new BankAccount();
        //    BankAccount bankAccount2 = new BankAccount();
        //    AccountDetails ac1 = new AccountDetails("AccountP1", 1000, "Kr", false, false, 0);
        //    AccountDetails ac2 = new AccountDetails("AccountP2", 3000, "Kr", false, false, 0);
        //    AccountDetails ac3 = new AccountDetails("AccountP12", 5000, "Kr", false, false, 1);
        //    AccountDetails ac4 = new AccountDetails("AccountP22", 4000, "Kr", false, false, 1);
        //    bankAccount1.BankAccountList.Add(ac1);
        //    bankAccount2.BankAccountList.Add(ac2);
        //    bankAccount1.BankAccountList.Add(ac3);
        //    bankAccount2.BankAccountList.Add(ac4);

        //    string name = "Adam";
        //    string password = "12345";
        //    string name2 = "Sam";
        //    string password2 = "12BaD";
        //    Customer cus = new Customer(name, password)
        //    {
        //        UserName = name,
        //        Password = password
        //    };
        //    Customer cus2 = new Customer(name2, password2)
        //    {
        //        UserName = name2,
        //        Password = password2
        //    };
        //    system.PersonDictionary.Add(0, cus);
        //    system.PersonDictionary.Add(1, cus2);
        //    system.AccountDictionary.Add(0, bankAccount1);
        //    system.AccountDictionary.Add(1, bankAccount2);

        //    var reciever = bankAccount2;
        //    var money = 500;
        //    var UserIndex = 0;
        //    PendingTransactions pendingTransactions = new PendingTransactions(reciever, money, UserIndex);
        //    system.InLoggedUserAccount = bankAccount1;
        //    system.InLoggedUserIndex = 0;

        //    CurrencyExchanges cx = new CurrencyExchanges(10, 10);
        //    bankAccount1.currencyExchanges = cx;
        //    bankAccount2.currencyExchanges = cx;
        //    system.currencyExchanges = cx;

        //    //Act
        //    var input = new StringReader("1\n1\n500");
        //    Console.SetIn(input);

        //    var consoleOutPut = new StringWriter();
        //    Console.SetOut(consoleOutPut);

        //    system.TransfereBetweenUsers();
        //    var outPut = consoleOutPut.ToString();

        //    //var expected = system.pendingTransactionsQueue.Peek();

        //    //Assert
        //    //Assert.Equals(expected, pendingTransactions);
        //    Assert.IsTrue(outPut.Contains("[1]A: 500,00Kr"));
        //}
    }
}
