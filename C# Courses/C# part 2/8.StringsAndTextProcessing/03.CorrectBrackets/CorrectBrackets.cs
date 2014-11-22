using System;

// 3.Write a program to check if in a given expression the brackets are put correctly.
// Example of correct expression: ((a+b)/5-d).
// Example of incorrect expression: )(a+b)).

class CorrectBrackets
{
    static void Main()
    {
        string expressionToCheck = "(a+b))(";
        Console.WriteLine(CheckExpression(expressionToCheck)); //true if correct
    }

    static bool CheckExpression(string expression)
    {
        int stack = 0;
        bool result = true;

        for (int i = 0; i < expression.Length; i++)
        {
            if (expression[i] == '(')
            {
                stack++;
            }
            if (expression[i] == ')')
            {
                stack--;
            }

            if (stack<0)
            {
                result = false;
                return result;
            }
            if ((i<expression.Length -1) && expression[i] == '(' && expression[i+1] == ')')
            {
                result = false;
                return result;
            }
        }
        if (stack == 0)
        {
            result = true;
        }
        if (stack > 0)
        {
            result = false;
        }
        return result;
    }
}
