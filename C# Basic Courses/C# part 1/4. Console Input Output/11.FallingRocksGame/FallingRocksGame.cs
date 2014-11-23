using System;
using System.Collections.Generic;
using System.Threading;

struct FallingObj
{
    public int x;
    public int y;
    public char c;
    public ConsoleColor color;
}

class FallingRocksGame
{
    static void PrintCharOnPosition(int x, int y, char c, ConsoleColor color)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(c);
    }
    static void PrintStringOnPosition(int x, int y, string str, ConsoleColor color)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(str);
    }

    static void Main()
    {
        char dwarfSymb = '0';
        List<char> rockSymbols = new List<char> { '^', '@', '*', '&', '+', '%', '$', '#', '!', '.', ';' };
        Console.BufferHeight = Console.WindowHeight = 30;
        Console.BufferWidth = Console.WindowWidth = 45;
        int lives = 3;
        int speed = 200;
        int score = 0;
        FallingObj dwarf = new FallingObj();
        dwarf.x = Console.WindowWidth / 2 - 1;
        dwarf.y = Console.WindowHeight - 4;
        dwarf.c = dwarfSymb;
        dwarf.color = ConsoleColor.Yellow;
        Random randomGenerator = new Random();
        List<FallingObj> rocks = new List<FallingObj>();

        while (true)
        {
            bool hit = false;
            int chance = randomGenerator.Next(0, 100);
            // Spawn rocks:
            if (hit == false)
            {
                int chancePerc = randomGenerator.Next(0, 100);                                          
                if (chancePerc < 40)                                                                    
                {                                                                                       
                    FallingObj spawnRock = new FallingObj();                                            
                    spawnRock.x = randomGenerator.Next(0, Console.WindowWidth - 1);                     
                    spawnRock.y = 0;                                                                    
                    spawnRock.c = rockSymbols[randomGenerator.Next(0, rockSymbols.Count)];              
                    ConsoleColor randColor = ConsoleColor.Gray;                                         
                    int randColorN = randomGenerator.Next(0, 8);                                        
                    switch (randColorN)                                                                 
                    {                                                                                   
                        case 0: randColor = ConsoleColor.Blue; break;                                   
                        case 1: randColor = ConsoleColor.DarkBlue; break;                               
                        case 2: randColor = ConsoleColor.DarkCyan; break;                               
                        case 3: randColor = ConsoleColor.DarkGreen; break;                              
                        case 4: randColor = ConsoleColor.DarkMagenta; break;                            
                        case 5: randColor = ConsoleColor.DarkGray; break;                               
                        case 6: randColor = ConsoleColor.DarkRed; break;                                
                        case 7: randColor = ConsoleColor.DarkYellow; break;                             
                    }                                                                                   
                    spawnRock.color = randColor;                                                        
                    rocks.Add(spawnRock);                                                               
                }                                                                                       
                else if (chancePerc < 75)                                                               
                {                                                                                       
                    int doubleRockX = randomGenerator.Next(0, Console.WindowWidth - 2);                 
                    char doubleRockC = rockSymbols[randomGenerator.Next(0, rockSymbols.Count)];         
                    ConsoleColor randColor = ConsoleColor.Gray;                                         
                    int randColorN = randomGenerator.Next(0, 8);                                        
                    switch (randColorN)                                                                 
                    {                                                                                   
                        case 0: randColor = ConsoleColor.Blue; break;                                   
                        case 1: randColor = ConsoleColor.DarkBlue; break;                               
                        case 2: randColor = ConsoleColor.DarkCyan; break;                               
                        case 3: randColor = ConsoleColor.DarkGreen; break;                              
                        case 4: randColor = ConsoleColor.DarkMagenta; break;                            
                        case 5: randColor = ConsoleColor.DarkGray; break;                               
                        case 6: randColor = ConsoleColor.DarkRed; break;                                
                        case 7: randColor = ConsoleColor.DarkYellow; break;                             
                    }                                                                                   
                    for (int i = 0; i < 2; i++)                                                         
                    {                                                                                   
                        FallingObj spawnRock = new FallingObj();                                        
                        spawnRock.x = doubleRockX + i;                                                  
                        spawnRock.y = 0;                                                                
                        spawnRock.c = doubleRockC;                                                      
                        spawnRock.color = randColor;                                                    
                        rocks.Add(spawnRock);                                                           
                    }                                                                                   
                }                                                                                       
                else                                                                                    
                {                                                                                       
                    int tripleRockX = randomGenerator.Next(0, Console.WindowWidth - 3);                 
                    char tripleRockC = rockSymbols[randomGenerator.Next(0, rockSymbols.Count)];         
                    ConsoleColor randColor = ConsoleColor.Gray;                                         
                    int randColorN = randomGenerator.Next(0, 8);                                        
                    switch (randColorN)                                                                 
                    {                                                                                   
                        case 0: randColor = ConsoleColor.Blue; break;                                   
                        case 1: randColor = ConsoleColor.DarkBlue; break;                               
                        case 2: randColor = ConsoleColor.DarkCyan; break;                               
                        case 3: randColor = ConsoleColor.DarkGreen; break;                              
                        case 4: randColor = ConsoleColor.DarkMagenta; break;                            
                        case 5: randColor = ConsoleColor.DarkGray; break;                               
                        case 6: randColor = ConsoleColor.DarkRed; break;                                
                        case 7: randColor = ConsoleColor.DarkYellow; break;                             
                    }                                                                                   
                    for (int i = 0; i < 3; i++)                                                         
                    {                                                                                   
                        FallingObj spawnRock = new FallingObj();                                        
                        spawnRock.x = tripleRockX + i;                                                  
                        spawnRock.y = 0;                                                                
                        spawnRock.c = tripleRockC;                                                      
                        spawnRock.color = randColor;                                                    
                        rocks.Add(spawnRock);                                                           
                    }                                                                                   
                }                                                                                       
            }
            // Move dwarf:
            while (Console.KeyAvailable)                                     
            {                                                                
                ConsoleKeyInfo pressedKey = Console.ReadKey();           
                if (pressedKey.Key == ConsoleKey.LeftArrow)                  
                {                                                            
                    if (dwarf.x - 1 >= 0)                                    
                    {                                                        
                        dwarf.x = dwarf.x - 1;                               
                    }                                                        
                }                                                            
                if (pressedKey.Key == ConsoleKey.RightArrow)                 
                {                                                            
                    if (dwarf.x + 3 < Console.WindowWidth)                   
                    {                                                        
                        dwarf.x = dwarf.x + 1;                               
                    }                                                        
                }                                                            
            }                                                                
            // Move rocks:
            List<FallingObj> newRocks = new List<FallingObj>();                
            for (int i = 0; i < rocks.Count; i++)                              
            {                                                                  
                FallingObj oldRock = rocks[i];                                 
                FallingObj newRock = new FallingObj();                         
                newRock.x = oldRock.x;                                         
                newRock.y = oldRock.y + 1;                                     
                newRock.c = oldRock.c;                                         
                newRock.color = oldRock.color;                                 
                if (newRock.y < Console.WindowHeight-3)                        
                {                                                              
                    newRocks.Add(newRock);                                     
                }                                                              
            }                                                                  
            rocks = newRocks;                                                  
            // Check if rocks hit the dwarf:		
            for (int i = 0; i < rocks.Count; i++)
			{
                if ((dwarf.x == rocks[i].x && dwarf.y == rocks[i].y) || 
                    (dwarf.x - 1 == rocks[i].x && dwarf.y == rocks[i].y) ||
                    (dwarf.x + 1 == rocks[i].x && dwarf.y == rocks[i].y))
               {
                   lives--;
                   PrintStringOnPosition(dwarf.x-1, dwarf.y, "XXX", ConsoleColor.Red);
                   hit = true;
                   if (lives == 0)
                   {
                       PrintStringOnPosition(Console.WindowWidth / 2 - 6, Console.WindowHeight / 2 - 5, "GAME OVER!", ConsoleColor.Red);
                       Console.ReadLine();
                       Environment.Exit(0);                       
                   }
               }                        	 
			}
            //
            Console.Clear();
            //
            if (hit)
            {
                rocks.Clear();
                PrintStringOnPosition(dwarf.x - 1, dwarf.y, "XXX", ConsoleColor.Red);
                PrintStringOnPosition(Console.WindowWidth / 2 - 7, Console.WindowHeight / 2-5, "You got hit!", ConsoleColor.Red);
                PrintStringOnPosition(Console.WindowWidth/2 - 7, Console.WindowHeight/ 2-4, "Lives left: " + lives, ConsoleColor.Red);
                Thread.Sleep(800);
                speed = 200;
            }
            // Redraw rocks:
            foreach (FallingObj rock in rocks)                                   
            {                                                                    
                PrintCharOnPosition(rock.x, rock.y, rock.c, rock.color);         
            }                                                                    
            // Redraw rocks:
            PrintCharOnPosition(dwarf.x, dwarf.y, dwarf.c, dwarf.color);         
            PrintCharOnPosition(dwarf.x - 1, dwarf.y, '(', dwarf.color);         
            PrintCharOnPosition(dwarf.x + 1, dwarf.y, ')', dwarf.color);         
            // Draw in game info:
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                PrintCharOnPosition(i, Console.WindowHeight-3, '=', ConsoleColor.Gray);
            }
            PrintStringOnPosition(1, Console.WindowHeight - 2, "Score: " + score, ConsoleColor.White);
            PrintStringOnPosition(36, Console.WindowHeight - 1, "Lives: " + lives, ConsoleColor.White);
            PrintStringOnPosition(1, Console.WindowHeight - 1, "Speed: " + (300-speed), ConsoleColor.White);
            //
            if (speed>50)
            {
                speed -= 1;               
            }
            if (speed>150)
            {
                score++;                
            }
            else
            {
                score += 2;
            }
            // Slow down game:
            Thread.Sleep(speed);                                                   
        }
    }
}
