using System;

class Program
{
    static void Main()
    {
        string card1 = Console.ReadLine();
        string card2 = Console.ReadLine();
        string card3 = Console.ReadLine();
        string card4 = Console.ReadLine();
        string card5 = Console.ReadLine();
        int[] ind = new int[5];
        //int c1ind = -1;
        //int c2ind = -1;
        //int c3ind = -1;
        //int c4ind = -1;
        //int c5ind = -1;
        string[] deck = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

        for (int i = 0; i < 13; i++)
        {
            if (card1 == deck[i])
            {
                ind[0] = i;
                break;
            }
        }
        for (int i = 0; i < 13; i++)
        {
            if (card2 == deck[i])
            {
                ind[1] = i;
                break;
            }
        }
        for (int i = 0; i < 13; i++)
        {
            if (card3 == deck[i])
            {
                ind[2] = i;
                break;
            }
        }
        for (int i = 0; i < 13; i++)
        {
            if (card4 == deck[i])
            {
                ind[3] = i;
                break;
            }
        }
        for (int i = 0; i < 13; i++)
        {
            if (card5 == deck[i])
            {
                ind[4] = i;
                break;
            }
        }
        Array.Sort(ind);

        if (ind[0] == ind[1] && ind[1] == ind[2] && ind[2] == ind[3] && ind[3]== ind[4])
        {
            Console.WriteLine("Impossible");
        }
        else if ((ind[0] == ind[1] && ind[1] == ind[2] && ind[2] == ind[3] && ind[3] != ind[4]) || (ind[0] != ind[1] && ind[1] == ind[2] && ind[2] == ind[3] && ind[3] == ind[4]))
        {
            Console.WriteLine("Four of a Kind");            
        }
        else if ((ind[0] == ind[1] && ind[1] == ind[2] && ind[2] != ind[3] && ind[3] == ind[4]) || (ind[0] == ind[1] && ind[1] != ind[2] && ind[2] == ind[3] && ind[3] == ind[4]))
        {
            Console.WriteLine("Full House");
        }
        else if ((ind[0] == ind[1] && ind[1] == ind[2] && ind[2] != ind[3] && ind[3] != ind[4]) ||
                       (ind[0] != ind[1] && ind[1] == ind[2] && ind[2] == ind[3] && ind[3] != ind[4]) ||
                            (ind[0] != ind[1] && ind[1] != ind[2] && ind[2] == ind[3] && ind[3] == ind[4]))
        {
            Console.WriteLine("Three of a Kind");
        }
        else if ((ind[0] == ind[1] && ind[1] != ind[2] && ind[2] == ind[3] && ind[3] != ind[4] && ind[0]!=ind[4]) || 
                    (ind[0] == ind[1] && ind[1] != ind[2] && ind[2] != ind[3] && ind[3] == ind[4] && ind[0]!=ind[4]) ||
                         (ind[0] != ind[1] && ind[1] == ind[2] && ind[2] != ind[3] && ind[3] == ind[4] && ind[0] != ind[4]))
        {
            Console.WriteLine("Two Pairs");
        }
        else if ((ind[0] == ind[1] && ind[1] != ind[2] && ind[2] != ind[3] && ind[3] != ind[4]) ||
                     (ind[0] != ind[1] && ind[1] == ind[2] && ind[2] != ind[3] && ind[3] != ind[4]) ||
                         (ind[0] != ind[1] && ind[1] != ind[2] && ind[2] == ind[3] && ind[3] != ind[4]) ||
                             (ind[0] != ind[1] && ind[1] != ind[2] && ind[2] != ind[3] && ind[3] == ind[4]))
        {
            Console.WriteLine("One Pair");
        }
        else if (ind[0] != ind[1] && ind[1] != ind[2] && ind[2] != ind[3] && ind[3] != ind[4])
        {
            if ((ind[0] == ind[1]-1 && ind[1] == ind[2]-1 && ind[2] == ind[3]-1 && ind[3] == ind[4]-1) || (ind[0] == 0 && ind[1] ==1 && ind[2] == 2 && ind[3] == 3 && ind[4] == 12))
            {
                Console.WriteLine("Straight");                
            }
            else
            {
                Console.WriteLine("Nothing");
            }
        }
    }
}
