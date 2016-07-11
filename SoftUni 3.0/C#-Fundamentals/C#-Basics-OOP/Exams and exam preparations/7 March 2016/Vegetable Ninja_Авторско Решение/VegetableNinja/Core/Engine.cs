namespace VegetableNinja.Core
{
    using System.Collections.Generic;
    using System.Linq;

    using VegetableNinja.Interfaces;

    public class Engine : IEngine
    {
        private readonly IInputReader consoleReader;

        private readonly IOutputWriter consoleWriter;

        private readonly IGameController gameController;

        public Engine(IInputReader consoleReader, IOutputWriter consoleWriter, IGameController gameController)
        {
            this.consoleReader = consoleReader;
            this.consoleWriter = consoleWriter;
            this.gameController = gameController;
        }

        public void Run()
        {
            string firstNinjaName = this.consoleReader.ReadLine();
            string secondNinjaName = this.consoleReader.ReadLine();

            int[] matrixDimensions = this.consoleReader.ReadLine().Split().Select(int.Parse).ToArray();

            this.gameController.Database.SeedField(this.ReadMatrix(matrixDimensions[0]), firstNinjaName, secondNinjaName);

            this.gameController.InitialiseGameData(firstNinjaName);

            while (true)
            {
                string currentInputLine = this.consoleReader.ReadLine();
                this.gameController.ProcessInput(currentInputLine);

                if (this.gameController.WinnerNinja != null)
                {
                    break;
                }
            }

            this.consoleWriter.WriteLine(this.gameController.WinnerNinja.ToString());
        }

        private List<string> ReadMatrix(int rows)
        {
            List<string> resultMatrix = new List<string>();

            for (int row = 0; row < rows; row++)
            {
                resultMatrix.Add(this.consoleReader.ReadLine());
            }

            return resultMatrix;
        } 
    }
}
