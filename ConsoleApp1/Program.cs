using System;
using GameCollection.Games;
using GameCollection.Menu;

namespace GameCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            IGameInterface selectedGame;

            HighLevelFactory highLevelFactory = new HighLevelFactory();

            MenuNodeFascade mainMenu = highLevelFactory.getMainMenu();

            bool stillPlaying = true;

            while (stillPlaying)
            {
                Console.Clear();
                selectedGame = mainMenu.Run();

                if (selectedGame != null)
                {
                    Console.Clear();
                    selectedGame.Play();
                }
                else
                {
                    Console.WriteLine("Quitting...");
                    Console.WriteLine("Goodbye");
                    Console.ReadKey();
                    stillPlaying = false;
                }
            }
        }
    }
}
