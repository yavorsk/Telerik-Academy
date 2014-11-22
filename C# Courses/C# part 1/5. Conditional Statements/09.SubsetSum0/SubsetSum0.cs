//We are given 5 integer numbers. Write a program that checks if the sum of some subset of them is 0. Example: 3, -2, 1, 1, 8  1+1-2=0.
using System;

class SubsetSum0
{
    static void Main()
    {
        Console.Write("Enter 1st integer number: ");
        int n1= int.Parse(Console.ReadLine());
        Console.Write("Enter 2nd integer number: ");
        int n2 = int.Parse(Console.ReadLine());
        Console.Write("Enter 3rd integer number: ");
        int n3 = int.Parse(Console.ReadLine());
        Console.Write("Enter 4th integer number: ");
        int n4 = int.Parse(Console.ReadLine());
        Console.Write("Enter 5th integer number: ");
        int n5 = int.Parse(Console.ReadLine());
        bool subSetSum0 = false;
        if (n1 + n2 + n3 + n4 + n5 == 0)
        {
            Console.WriteLine("({0})+({1})+({2})+({3})+({4})=0", n1, n2, n3,n4,n5);
            subSetSum0 = true;
        }
        if (n1 + n2 + n3 + n4 == 0)
        {
            Console.WriteLine("({0})+({1})+({2})+({3})=0", n1, n2, n3, n4, n5);
            subSetSum0 = true;            
        }
        if (n1 + n2 + n3 + n5 == 0)
        {
            Console.WriteLine("({0})+({1})+({2})+({4})=0", n1, n2, n3, n4, n5);
            subSetSum0 = true;                  
        }
        if (n1 + n2 + n4 + n5 == 0)
        {
            Console.WriteLine("({0})+({1})+({3})+({4})=0", n1, n2, n3, n4, n5);
            subSetSum0 = true;      
        }
        if (n1 + n3 + n4 + n5 == 0)
        {
            Console.WriteLine("({0})+({2})+({3})+({4})=0", n1, n2, n3, n4, n5);
            subSetSum0 = true;     
        }
        if (n2 + n3 + n4 + n5 == 0)
        {
            Console.WriteLine("({1})+({2})+({3})+({4})=0", n1, n2, n3, n4, n5);
            subSetSum0 = true;    
        }
        if (n1 + n2 + n3 == 0)
        {
            Console.WriteLine("({0})+({1})+({2})=0", n1, n2, n3, n4, n5);
            subSetSum0 = true;    
        }
        if (n1 + n2 + n4 == 0)
        {
            Console.WriteLine("({0})+({1})+({3})=0", n1, n2, n3, n4, n5);
            subSetSum0 = true;  
        }
        if (n1 + n2 + n5 == 0)
        {
            Console.WriteLine("({0})+({1})+({4})=0", n1, n2, n3, n4, n5);
            subSetSum0 = true;  
        }
        if (n4 + n2 + n3 == 0)
        {
            Console.WriteLine("({3})+({1})+({2})=0", n1, n2, n3, n4, n5);
            subSetSum0 = true;  
        }
        if (n5 + n2 + n3 == 0)
        {
            Console.WriteLine("({4})+({1})+({2})=0", n1, n2, n3, n4, n5);
            subSetSum0 = true;  
        }
        if (n1 + n4 + n3 == 0)
        {
            Console.WriteLine("({0})+({3})+({2})=0", n1, n2, n3, n4, n5);
            subSetSum0 = true;  
        }
        if (n1 + n5 + n3 == 0)
        {
            Console.WriteLine("({0})+({4})+({2})=0", n1, n2, n3, n4, n5);
            subSetSum0 = true;  
        }
        if (n1 + n2 == 0)
        {
            Console.WriteLine("({0})+({1})=0", n1, n2, n3, n4, n5);
            subSetSum0 = true;               
        }
        if (n1 + n3 == 0)
        {
            Console.WriteLine("({0})+({2})=0", n1, n2, n3, n4, n5);
            subSetSum0 = true;     
        }
        if (n1 + n4 == 0)
        {
            Console.WriteLine("({0})+({3})=0", n1, n2, n3, n4, n5);
            subSetSum0 = true;
        }
        if (n1 + n5 == 0)
        {
            Console.WriteLine("({0})+({4})=0", n1, n2, n3, n4, n5);
            subSetSum0 = true;
        }
        if (n2 + n3 == 0)
        {
            Console.WriteLine("({1})+({2})=0", n1, n2, n3, n4, n5);
            subSetSum0 = true;
        }
        if (n2 + n4 == 0)
        {
            Console.WriteLine("({1})+({3})=0", n1, n2, n3, n4, n5);
            subSetSum0 = true;
        }
        if (n2 + n5 == 0)
        {
            Console.WriteLine("({1})+({4})=0", n1, n2, n3, n4, n5);
            subSetSum0 = true;
        }
        if (n3 + n4 == 0)
        {
            Console.WriteLine("({2})+({3})=0", n1, n2, n3, n4, n5);
            subSetSum0 = true;
        }
        if (n3 + n5 == 0)
        {
            Console.WriteLine("({2})+({4})=0", n1, n2, n3, n4, n5);
            subSetSum0 = true;
        }
        if (n4 + n5 == 0)
        {
            Console.WriteLine("({3})+({4})=0", n1, n2, n3, n4, n5);
            subSetSum0 = true;
        }
        if (subSetSum0 == false)
        {
            Console.WriteLine("There is no subset, the sum of which equals 0.");            
        }
    }
}
