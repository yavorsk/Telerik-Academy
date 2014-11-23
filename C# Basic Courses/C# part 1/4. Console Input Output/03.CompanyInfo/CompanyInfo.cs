using System;

class CompanyInfo
{
    static void Main()
    {
        Console.Write("Please enter company name: ");
        string companyName = Console.ReadLine();
        Console.Write("Please enter company address: ");
        string companyAddress = Console.ReadLine();
        Console.Write("Please enter company phone number: ");
        int companyPhone = int.Parse(Console.ReadLine());
        Console.Write("Please enter company fax number: ");
        int companyFax = int.Parse(Console.ReadLine());
        Console.Write("Please enter company web page: ");
        string webPage = Console.ReadLine();
        Console.Write("Please enter manager's first name: ");
        string managerFirstN = Console.ReadLine();
        Console.Write("Please enter manager's last name: ");
        string managerLastN = Console.ReadLine();
        Console.Write("Please enter manager's age: ");
        byte managerAge = byte.Parse(Console.ReadLine());
        Console.Write("Please enter manager's phone number: ");
        int managerPhone = int.Parse(Console.ReadLine());
        Console.WriteLine("Company Name: {0, -5} /n Address: {1}, ", companyName, companyAddress, companyPhone, companyFax, webPage, managerFirstN, managerLastN, managerAge, managerPhone);
    }
}
