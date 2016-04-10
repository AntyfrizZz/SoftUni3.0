using System;
//A company has name, address, phone number, fax number, web site and manager.
//The manager has first name, last name, age and a phone number.
//Write a program that reads the information about a company and its manager and prints it back on the console.

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/4.%20Console-Input-Output-Homework.docx

class PrintCompanyInformation
{
    static void Main()
    {
        Console.Title = "Problem 2.	Print Company Information";

        Console.Write("Enter the name of the company: ");
        string companyName = Console.ReadLine();

        Console.Write("Enter the address of the company: ");
        string companyAddress = Console.ReadLine();

        Console.Write("Enter the phone number of the company: ");
        string companyPhoneNumber = Console.ReadLine();

        Console.Write("Enter the fax number of the company: ");
        string companyFaxNumber = Console.ReadLine();

        if (String.IsNullOrEmpty(companyFaxNumber) == true)
        {
            companyFaxNumber = "(no fax)";
        }

        Console.Write("Enter the web site of the company: ");
        string companyWebSite = Console.ReadLine();

        Console.Write("Enter the first name of the manager: ");
        string managerFirstName = Console.ReadLine();

        Console.Write("Enter the last name of the manager: ");
        string managerLastName = Console.ReadLine();

        Console.Write("Enter the age of the manager: ");
        string managerAge = Console.ReadLine();

        Console.Write("Enter the phone number of the manager: ");
        string managerPhoneNumber = Console.ReadLine();

        Console.WriteLine();

        Console.WriteLine("{0}\nAddress: {1}\nTel. {2}\nFax: {3}\nWeb site: {4}\nManager: {5} {6} (age: {7}, tel: {8})", companyName, companyAddress, companyPhoneNumber, companyFaxNumber, companyWebSite, managerFirstName, managerLastName, managerAge, managerPhoneNumber);


    }
}