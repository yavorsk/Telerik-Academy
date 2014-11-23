using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portals
{
    class Program
    {
        static Cube[,] matrix;
        static long maxPower;
        static long maxPrevPower;

        static void Main()
        {
            string[] startingLocInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] startingLocation = new int[2];
            startingLocation[0] = int.Parse(startingLocInput[0]);
            startingLocation[1] = int.Parse(startingLocInput[1]);

            string[] matrixSizesInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int R = int.Parse(matrixSizesInput[0]);
            int C = int.Parse(matrixSizesInput[1]);

            matrix = new Cube[R, C];

            for (int i = 0; i < R; i++)
            {
                string[] currentLineInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < currentLineInput.Length; j++)
                {
                    if (currentLineInput[j] == "#")
                    {
                        matrix[i, j] = new Cube(false, false, 0, i, j);
                    }
                    else
                    {
                        int currentPower = int.Parse(currentLineInput[j]);

                        matrix[i, j] = new Cube(true, false, currentPower, i, j);
                    }
                }
            }

            Cube currenCube = matrix[startingLocation[0], startingLocation[1]];
            currenCube.Passable = false;

            maxPower = 0;

            Solve(currenCube, 0);

            Console.WriteLine(maxPower);
        }

        private static void Solve(Cube currenCube, long currentPower)
        {
            if (!RightIsValidMove(currenCube) && !LeftIsValidMove(currenCube) && !DownIsValidMove(currenCube) && !UpIsValidMove(currenCube))
            {
                //var maxPowerForCurrentPath = currentPower +currenCube.PortalPower;

                if (currentPower + currenCube.PortalPower >= maxPower)
                {
                    maxPower = currentPower + currenCube.PortalPower;
                    return;
                }
            }

            if (RightIsValidMove(currenCube))
            {
                currentPower += currenCube.PortalPower;
                var nextCube = matrix[currenCube.Row, currenCube.Col + currenCube.PortalPower];
                nextCube.Passable = false;
                Solve(nextCube, currentPower);
                currentPower -= currenCube.PortalPower;
                nextCube.Passable = true;
            }

            if (DownIsValidMove(currenCube))
            {
                currentPower += currenCube.PortalPower;
                var nextCube = matrix[currenCube.Row + currenCube.PortalPower, currenCube.Col];
                nextCube.Passable = false;
                Solve(nextCube, currentPower);
                currentPower -= currenCube.PortalPower;
                nextCube.Passable = true;
            }
            if (LeftIsValidMove(currenCube))
            {
                currentPower += currenCube.PortalPower;
                var nextCube = matrix[currenCube.Row, currenCube.Col - currenCube.PortalPower];
                nextCube.Passable = false;
                Solve(nextCube, currentPower);
                currentPower -= currenCube.PortalPower;
                nextCube.Passable = true;
            }
            if (UpIsValidMove(currenCube))
            {
                currentPower += currenCube.PortalPower;
                var nextCube = matrix[currenCube.Row - currenCube.PortalPower, currenCube.Col];
                nextCube.Passable = false;
                Solve(nextCube, currentPower);
                currentPower -= currenCube.PortalPower;
                nextCube.Passable = true;
            }
        }

        private static bool UpIsValidMove(Cube currenCube)
        {
            if (currenCube.Row - currenCube.PortalPower < 0)
            {
                return false;
            }
            if (!matrix[currenCube.Row - currenCube.PortalPower, currenCube.Col].Passable)
            {
                return false;
            }

            return true;
        }

        private static bool LeftIsValidMove(Cube currenCube)
        {
            if (currenCube.Col - currenCube.PortalPower < 0)
            {
                return false;
            }
            if (!matrix[currenCube.Row, currenCube.Col - currenCube.PortalPower].Passable)
            {
                return false;
            }

            return true;
        }

        private static bool DownIsValidMove(Cube currenCube)
        {
            if (currenCube.Row + currenCube.PortalPower >= matrix.GetLength(0))
            {
                return false;
            }
            if (!matrix[currenCube.Row + currenCube.PortalPower, currenCube.Col].Passable)
            {
                return false;
            }

            return true;
        }

        private static bool RightIsValidMove(Cube currenCube)
        {
            if (currenCube.Col + currenCube.PortalPower >= matrix.GetLength(1))
            {
                return false;
            }
            if (!matrix[currenCube.Row, currenCube.Col + currenCube.PortalPower].Passable)
            {
                return false;
            }

            return true;
        }

        private static bool HasValidMoves(Cube currenCube)
        {
            if (currenCube.Row - currenCube.PortalPower < 0)
            {
                return false;
            }
            if (currenCube.Row + currenCube.PortalPower >= matrix.GetLength(0))
            {
                return false;
            }
            if (currenCube.Col - currenCube.PortalPower < 0)
            {
                return false;
            }
            if (currenCube.Col + currenCube.PortalPower >= matrix.GetLength(1))
            {
                return false;
            }

            if (!matrix[currenCube.Row + currenCube.PortalPower, currenCube.Col].Passable)
            {
                return false;
            }
            if (!matrix[currenCube.Row - currenCube.PortalPower, currenCube.Col].Passable)
            {
                return false;
            }
            if (!matrix[currenCube.Row, currenCube.Col + currenCube.PortalPower].Passable)
            {
                return false;
            }
            if (!matrix[currenCube.Row, currenCube.Col - currenCube.PortalPower].Passable)
            {
                return false;
            }

            return true;
        }

        public class Cube
        {
            public Cube(bool passable, bool visited, int power, int r, int c)
            {
                this.Passable = passable;
                this.Visited = visited;
                this.PortalPower = power;
                this.Row = r;
                this.Col = c;
            }

            public bool Passable { get; set; }

            public bool Visited { get; set; }

            public int PortalPower { get; set; }

            public int Row { get; set; }
            public int Col { get; set; }
        }
    }
}
