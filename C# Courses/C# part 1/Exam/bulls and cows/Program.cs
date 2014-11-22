using System;

class Program
{
    static void Main()
    {
        int secret = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());
        int sOnes = secret % 10;
        int sTens = (secret % 100) / 10;
        int sHundreds = (secret % 1000) / 100;
        int sThous = secret / 1000;

        int bic = 0;
        int cow = 0;

        for (int i = 1000; i <= 9999; i++)
        {
            int iOnes = i % 10;
            int iTens = (i % 100) / 10;
            int iHundreds = (i % 1000) / 100;
            int iThous = i / 1000;

            bic = 0;
            cow = 0;

            if (b == 3 && c == 1)
            {
                Console.Write("No");
                break;
            }
            if (b + c > 4)
            {
                Console.Write("No");
                break;
            }
            if (iTens == 0 || iHundreds == 0 || iThous == 0 || iOnes == 0)
            {
                continue;
            }
            if (sOnes == iOnes)
            {
                bic++;
            }
            if (sTens == iTens)
            {
                bic++;
            }
            if (sHundreds == iHundreds)
            {
                bic++;
            }
            if (sThous == iThous)
            {
                bic++;
            }

            if (iOnes != sOnes && ((iOnes == sTens && iTens != sTens) || (iOnes == sHundreds && iHundreds != sHundreds) || (iOnes == sThous && iThous != sThous)))
            {
                cow++;
            }

            if ((iTens != sTens) && ((iTens == sOnes && iOnes != sOnes) || (iTens == sHundreds && iHundreds != sHundreds) || (iTens == sThous && iThous != sThous)))
            {
                cow++;
            }
            if (iHundreds != sHundreds && ((iHundreds == sOnes && iOnes != sOnes) || (iHundreds == sTens && iTens != sTens) || (iHundreds == sThous && iThous != sThous)))
            {
                cow++;
            }
            if (iThous != sThous && ((iThous == sOnes && iOnes != sOnes) || (iThous == sTens && iTens != sTens) || (iThous == sTens && iTens != sTens)))
            {
                cow++;
            }
            if (cow == c && bic == b)
            {
                Console.Write("{0} ", i);
            }
        }
    }
}
