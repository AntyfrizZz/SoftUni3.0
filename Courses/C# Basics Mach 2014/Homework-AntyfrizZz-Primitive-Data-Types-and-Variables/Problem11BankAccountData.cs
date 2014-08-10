using System;
//A bank account has a holder name (first name, middle name and last name), available amount of money (balance), bank name, IBAN, 3 credit card numbers associated with the account. 
//Declare the variables needed to keep the information for a single bank account using the appropriate data types and descriptive names.

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/2.%20Primitive-Data-Types-and-Variables-Homework.docx

class BankAccountData
{
    static void Main()
    {
        Console.Title = "Problem 11. Bank Account Data";

        string FirstName = "Ivan";
        string MiddleName = "Ivanov";
        string LastName = "Ivanov";
        decimal Balance = 125687.48m;
        char symbol = '$';
        string BankName = "UniCredit";
        object IBAN = "BE62510007547061";
        object FirstCreditCard = "1234 1234 1234 1234";
        object SecondCreditCard = "2234 1234 1234 1234";
        object ThirdCreditCard = "3234 1234 1234 1234";
        Console.WriteLine("First name: {0}", FirstName);
        Console.WriteLine("Middle name: {0}", MiddleName);
        Console.WriteLine("Last name: {0}", LastName);
        Console.WriteLine("Available balance: {0}", Balance);
        Console.WriteLine("Bank name: {0}", BankName);
        Console.WriteLine("IBAN: {0}", IBAN);
        Console.WriteLine("First credit card: {0}", FirstCreditCard);
        Console.WriteLine("Second credit card: {0}", SecondCreditCard);
        Console.WriteLine("Third credit card: {0}", ThirdCreditCard);
    }
}
