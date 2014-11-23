using System;

class Program
{
    static void Main()
    {
        int n = 0;
        int[,] field = new int[8, 8];

        for (int i = 0; i < 8; i++)
        {
            n = int.Parse(Console.ReadLine());
            for (int j = 0; j < 8; j++)
            {
                field[i, j] = (n >> j) & 1;
            }
        }

        //for (int i = 0; i < 8; i++)
        //{
        //    for (int j = 0; j < 8; j++)
        //    {
        //        Console.Write(field[i,j]);
        //    }
        //    Console.WriteLine();
        //}

        int x = 0;
        int y = 0;
        int trackLength = 1;
        int turnsCount = 0;

        while (true)
        {
            if (field[x,y]==1)
            {
                trackLength = 0;
                Console.WriteLine("NO " + trackLength);
                break;          
            }
            while ( x < 7 && field[x+1, y] == 0) // move south
            {
                x++;
                trackLength++;
            }
            if (x == 7 && y == 7) // check if track end
            {
                Console.WriteLine(trackLength +" "+ turnsCount);
                break;
            }
            if (y == 7 || field[x, y + 1] == 1) // check if we can go west
            {
                Console.WriteLine("NO " + trackLength);
                break;
            }

            turnsCount++;   //turn west
            while (y < 7 && field[x, y+1] == 0)  // move west
            {
                y++;
                trackLength++;
            }
            if (x == 7 && y == 7) // check if track end
            {
                Console.WriteLine(trackLength + " " + turnsCount);
                break;
            }
            if (x == 0 || field[x -1, y] == 1) // check if we can go north
            {
                Console.WriteLine("NO " + trackLength);
                break;
            }


            turnsCount++;   //turn north
            while ( x > 0 && field[x-1,y] == 0)  // move north
            {
                x--;
                trackLength++;
            }
            if (x == 7 && y == 7) // check if track end
            {
                Console.WriteLine(trackLength + " " + turnsCount);
                break;
            }
            if ( y == 7 || field[x, y+1] == 1) // check if we can go west
            {
                Console.WriteLine("NO " + trackLength);
                break;
            }

            turnsCount++;   //turn west
            while ( y < 7 && field[x, y + 1] == 0)  // move west
            {
                y++;
                trackLength++;
            }
            if (x == 7 && y == 7) // check if track end
            {
                Console.WriteLine(trackLength + " " + turnsCount);
                break;
            }
            if (x == 7 || field[x+1, y] == 1) // check if we can go south
            {
                Console.WriteLine("NO " + trackLength);
                break;
            }
            turnsCount++;   //turn south
        }
    }
}
