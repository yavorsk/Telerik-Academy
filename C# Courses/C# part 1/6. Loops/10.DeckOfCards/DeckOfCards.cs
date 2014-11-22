using System;

class DeckOfCards
{
    static void Main()
    {
        //Console.BufferHeight = 60;
        string suit = "";
        string rank = "";
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 13; j++)
            {
                switch (i)
                {
                    case 0: suit = "spades"; break;
                    case 1: suit = "hearts"; break;
                    case 2: suit = "diamonds"; break;
                    case 3: suit = "clubs"; break;                        
                }
                switch (j) 
                {
                    case 0: rank = "ace"; break;
                    case 1: rank = "two"; break;
                    case 2: rank = "three"; break;
                    case 3: rank = "four"; break;
                    case 4: rank = "five"; break;
                    case 5: rank = "six"; break;
                    case 6: rank = "seven"; break;
                    case 7: rank = "eight"; break;
                    case 8: rank = "nine"; break;
                    case 9: rank = "ten"; break;
                    case 10: rank = "jack"; break;
                    case 11: rank = "queen"; break;
                    case 12: rank = "king"; break;
                }
                Console.WriteLine(rank + " of " + suit);
            }
        }
    }
}
