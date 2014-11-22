using System;

class FighterAttack
{
    static void Main()
    {
        int pX1 = int.Parse(Console.ReadLine());
        int pY1 = int.Parse(Console.ReadLine());
        int pX2 = int.Parse(Console.ReadLine());
        int pY2 = int.Parse(Console.ReadLine());

        if (pX1 > pX2)
        {
            int temp = pX1;
            pX1 = pX2;
            pX2 = temp;
        }

        if (pY1 > pY2)
        {
            int temp = pY1;
            pY1 = pY2;
            pY2 = temp;
        }

        int fX = int.Parse(Console.ReadLine());
        int fY = int.Parse(Console.ReadLine());
        int dist = int.Parse(Console.ReadLine());

        int damage = 0;
        fX += dist;

        if (pX1 <= fX && fX <= pX2)
        {
            if (pY1 <= fY && fY <= pY2)
            {
                damage += 100;
            }

            if (pY1 <= fY - 1 && fY - 1 <= pY2)
            {
                damage += 50;
            }

            if (pY1 <= fY + 1 && fY + 1 <= pY2)
            {
                damage += 50;
            }
        }

        if (pX1 <= fX + 1 && fX + 1 <= pX2)
        {
            if (pY1 <= fY && fY <= pY2)
            {
                damage += 75;
            }
        }

        Console.WriteLine("{0}%", damage);
    }
}

