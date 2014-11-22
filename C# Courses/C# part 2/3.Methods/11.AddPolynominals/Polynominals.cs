//11. Write a method that adds two polynomials. Represent them as arrays of their coefficients as in the example below:
//		x2 + 5 = 1x2 + 0x + 5
//12. Extend the program to support also subtraction and multiplication of polynomials.

using System;

class Polynominals
{
    static int[] AddPolynominals(int[] arr1, int[] arr2)
    {
        int[] result = new int[arr1.Length];

        for (int i = 0; i < arr1.Length; i++)
        {
            result[i] = arr1[i] + arr2[i];
        }
        return result;
    }

    static int[] SubstractPolynominals(int[] arr1, int[] arr2)
    {
        int[] result = new int[arr1.Length];

        for (int i = 0; i < arr1.Length; i++)
        {
            result[i] = arr1[i] - arr2[i];
        }
        return result;
    }

    static void PrintPolynominal(int[] arr)
    {
        string result = string.Empty;

        for (int i = arr.Length - 1; i >= 0; i--)
        {
            if (arr[i] == 0)
            {
                result += "";
            }
            else if (arr[i] < 0)
            {
                if (i>1)
                {
                    result += arr[i] + "x^" + i;                    
                }
                else if (i == 1)
                {
                    result += arr[i] + "x";                       
                }
                else if (i == 0)
                {
                    result += arr[i];
                }
            }
            else if (arr[i] > 0)
            {
                if (i == arr.Length - 1)
                {
                    result += arr[i] + "x^" + i;
                }
                else
                {
                    if (i>1)
                    {
                        result += "+" + arr[i] + "x^" + i;                       
                    }
                    else if (i==1)
                    {
                        result += "+" + arr[i] + "x";       
                    }
                    else if (i == 0)
                    {
                        result += "+" + arr[i];
                    }
                }
            }
        }
        Console.WriteLine(result);
    }

    static void Main()
    {
        // The input arrays should have equal lengths...
        int[] firstPolinominal = { 4, -3, 5, 0 };
        int[] secondPolynominal = { 3, -5, 6, 4 };

        PrintPolynominal(firstPolinominal);
        PrintPolynominal(secondPolynominal);

        PrintPolynominal(AddPolynominals(firstPolinominal, secondPolynominal));
        PrintPolynominal(SubstractPolynominals(firstPolinominal, secondPolynominal));
    }
}
