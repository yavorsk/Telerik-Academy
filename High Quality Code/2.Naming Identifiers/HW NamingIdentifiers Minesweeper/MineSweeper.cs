namespace MinesweeperGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Minesweeper
    {
        static void Main(string[] args)
        {
            const int SAFE_CELLS_COUNT = 35;
            string command = string.Empty;
            char[,] playField = CreatePlayField();
            char[,] mines = PlaceMines();
            int pointCounter = 0;
            bool exploded = false;
            List<Result> ranking = new List<Result>(6);
            int row = 0;
            int column = 0;
            bool atStart = true;
            bool allSafeCellsRevealed = false;

            do
            {
                if (atStart)
                {
                    Console.WriteLine("Let's play \"Minesweeper\". Try to reveal all cells that don't contain a mine." +
                    " Enter 'top' to see the Hall of fame, 'restart' to start a new game, 'exit' to ... exit the game!");
                    DrawField(playField);
                    atStart = false;
                }

                Console.Write("Enter row and column: ");
                command = Console.ReadLine().Trim();

                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                    int.TryParse(command[2].ToString(), out column) &&
                        row <= playField.GetLength(0) && column <= playField.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        ShowHallOfFame(ranking);
                        break;
                    case "restart":
                        playField = CreatePlayField();
                        mines = PlaceMines();
                        DrawField(playField);
                        exploded = false;
                        atStart = false;
                        break;
                    case "exit":
                        Console.WriteLine("Bye bye!");
                        break;
                    case "turn":
                        if (mines[row, column] != '*')
                        {
                            if (mines[row, column] == '-')
                            {
                                RevealSafeCell(playField, mines, row, column);
                                pointCounter++;
                            }

                            if (SAFE_CELLS_COUNT == pointCounter)
                            {
                                allSafeCellsRevealed = true;
                            }
                            else
                            {
                                DrawField(playField);
                            }
                        }
                        else
                        {
                            exploded = true;
                        }
                        break;
                    default:
                        Console.WriteLine("\nInvalid command\n");
                        break;
                }

                if (exploded)
                {
                    DrawField(mines);

                    Console.Write("\nYou died heroically with {0} cell revealed. " + "Please enter your name: ", pointCounter);
                    string nickName = Console.ReadLine();

                    Result rankingEntry = new Result(nickName, pointCounter);

                    if (ranking.Count < 5)
                    {
                        ranking.Add(rankingEntry);
                    }
                    else
                    {
                        for (int i = 0; i < ranking.Count; i++)
                        {
                            if (ranking[i].Points < rankingEntry.Points)
                            {
                                ranking.Insert(i, rankingEntry);
                                ranking.RemoveAt(ranking.Count - 1);
                                break;
                            }
                        }
                    }

                    ranking.Sort((Result r1, Result r2) => r2.Name.CompareTo(r1.Name));
                    ranking.Sort((Result r1, Result r2) => r2.Points.CompareTo(r1.Points));
                    ShowHallOfFame(ranking);

                    playField = CreatePlayField();
                    mines = PlaceMines();
                    pointCounter = 0;
                    exploded = false;
                    atStart = true;
                }

                if (allSafeCellsRevealed)
                {
                    Console.WriteLine("\nCONGRATULATIONS! You revealed all 35 safe cells without a single drop of blood spilled!");

                    DrawField(mines);

                    Console.WriteLine("Enter your name: ");
                    string name = Console.ReadLine();
                    Result rank = new Result(name, pointCounter);
                    ranking.Add(rank);

                    ShowHallOfFame(ranking);
                    playField = CreatePlayField();
                    mines = PlaceMines();
                    pointCounter = 0;
                    allSafeCellsRevealed = false;
                    atStart = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.Read();
        }

        private static void ShowHallOfFame(List<Result> results)
        {
            Console.WriteLine("\nHall of fame:");

            if (results.Count > 0)
            {
                for (int i = 0; i < results.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} revealed cells", i + 1, results[i].Name, results[i].Points);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("The Hall of fame is empty!\n");
            }
        }

        private static void RevealSafeCell(char[,] field, char[,] mines, int row, int col)
        {
            char adjacentMinesCount = CountAdjacentMines(mines, row, col);

            mines[row, col] = adjacentMinesCount;
            field[row, col] = adjacentMinesCount;
        }

        private static void DrawField(char[,] field)
        {
            int rows = field.GetLength(0);
            int cols = field.GetLength(1);

            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            for (int i = 0; i < rows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(string.Format("{0} ", field[i, j]));
                }
                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreatePlayField()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];

            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] PlaceMines()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] mineField = new char[boardRows, boardColumns];

            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    mineField[i, j] = '-';
                }
            }

            List<int> minesPositionsList = new List<int>();

            while (minesPositionsList.Count < 15)
            {
                Random randomGenerator = new Random();
                int minePosition = randomGenerator.Next(50);

                if (!minesPositionsList.Contains(minePosition))
                {
                    minesPositionsList.Add(minePosition);
                }
            }

            foreach (int pos in minesPositionsList)
            {
                int mineRow = pos / boardColumns;
                int mineCol = pos % boardColumns;

                if (mineCol == 0 && pos != 0)
                {
                    mineRow--;
                    mineCol = boardColumns;
                }
                else
                {
                    mineCol++;
                }

                mineField[mineRow, mineCol - 1] = '*';
            }

            return mineField;
        }

        private static char CountAdjacentMines(char[,] mineField, int row, int col)
        {
            int adjacentMinesCount = 0;
            int rows = mineField.GetLength(0);
            int cols = mineField.GetLength(1);

            if (row - 1 >= 0)
            {
                if (mineField[row - 1, col] == '*')
                {
                    adjacentMinesCount++;
                }
            }
            if (row + 1 < rows)
            {
                if (mineField[row + 1, col] == '*')
                {
                    adjacentMinesCount++;
                }
            }
            if (col - 1 >= 0)
            {
                if (mineField[row, col - 1] == '*')
                {
                    adjacentMinesCount++;
                }
            }
            if (col + 1 < cols)
            {
                if (mineField[row, col + 1] == '*')
                {
                    adjacentMinesCount++;
                }
            }
            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (mineField[row - 1, col - 1] == '*')
                {
                    adjacentMinesCount++;
                }
            }
            if ((row - 1 >= 0) && (col + 1 < cols))
            {
                if (mineField[row - 1, col + 1] == '*')
                {
                    adjacentMinesCount++;
                }
            }
            if ((row + 1 < rows) && (col - 1 >= 0))
            {
                if (mineField[row + 1, col - 1] == '*')
                {
                    adjacentMinesCount++;
                }
            }
            if ((row + 1 < rows) && (col + 1 < cols))
            {
                if (mineField[row + 1, col + 1] == '*')
                {
                    adjacentMinesCount++;
                }
            }
            return char.Parse(adjacentMinesCount.ToString());
        }
    }

    public class Result
    {
        string playerName;
        int points;

        public Result()
        {
        }

        public Result(string name, int points)
        {
            this.playerName = name;
            this.points = points;
        }

        public string Name
        {
            get { return this.playerName; }
            set { this.playerName = value; }
        }

        public int Points
        {
            get { return this.points; }
            set { this.points = value; }
        }
    }
}
