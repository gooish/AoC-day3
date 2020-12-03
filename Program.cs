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
            if (naiveGoal.Item2 < arrToCheck[naiveGoal.Item1, 0].Length) {
                return naiveGoal;
            }
            else {
                int montakoYli = naiveGoal.Item2 - arrToCheck[1, 0].Length;
                return (naiveGoal.Item1, montakoYli);
            }
        }
    }
}
