using System.IO;

namespace reitti
{
    class Program
    {
        static void Main(string[] args)
        {
            string kaikkiRivit = File.ReadAllText("metsa.txt");
            string[] riviArray = kaikkiRivit.Split("\n");
            string[ , ] merkkiArray = new string[323 , 32]; 
            
            for (int i = 0; i < riviArray.Length; i++) {
                for (int j = 0; j < riviArray[i].Length; j++) {
                    merkkiArray[i,j] = (riviArray[i][j].ToString());
                    System.Console.Write(merkkiArray[i,j]);
                }
                System.Console.WriteLine();
            }

            System.Console.WriteLine(whereIsNextCoord((32, 32), merkkiArray));

            // prep done, program logic goes here

            (int, int) coords = (0, 0);
            int numberOfTrees = 0;
            for (int i = 0; i < 322; i++) {
                merkkiArray[coords.Item1, coords.Item2] = "X";
                coords = whereIsNextCoord(coords, merkkiArray);
                if (isTree(merkkiArray, coords)) {
                    numberOfTrees++;
                }
                
            }

            // printArr(merkkiArray);

            System.Console.WriteLine(numberOfTrees);
            
            


        }

        static bool isTree(string[,] arrToWalk, (int, int) coords) {
            if (arrToWalk[coords.Item1, coords.Item2] == "#") {
                return true;
            }
            else {
                return false;
            }
        }

        static (int, int) whereIsNextCoord((int, int) currentCoords, string[,] arrToCheck) {
            (int, int) naiveGoal = (currentCoords.Item1 + 1, currentCoords.Item2 + 3);
            if (naiveGoal.Item2 < 32) {
                System.Console.WriteLine("did not have to go over, at coord {0}, array row {1}", naiveGoal.Item2, naiveGoal.Item1);
                return naiveGoal;
            }
            else {
                int montakoYli = naiveGoal.Item2 - 32;
                System.Console.WriteLine("had to go over, at coord {0}", montakoYli);
                return (naiveGoal.Item1, montakoYli);
            }
        }

        static void printArr(string[,] arr) {
            

            int rowLength = arr.GetLength(0);
            int colLength = arr.GetLength(1);

            for (int i = 0; i < rowLength; i++)
                {
                    for (int j = 0; j < colLength; j++)
                        {
                            System.Console.Write(string.Format("{0}", arr[i, j]));
                }
                System.Console.WriteLine();
            }
        }
    }
}
