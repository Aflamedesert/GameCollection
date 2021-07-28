using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Games;
using GameCollection.Games.RockPaperScissors;
using GameCollection.Menu;

namespace GameCollection.Administration
{
    class GameFactory : IGameNodeFactory
    {
        string[] gamesList;

        MenuNodeFascade selfNode;

        HighLevelFactory highFactory;

        public GameFactory()
        {
            gamesList = new string[]
            {
                "Rock, Paper, Scissors",
                "BlackJack",
                "Quit"
            };
        }

        public void setSelfNode(MenuNodeFascade passedSelfNode)
        {
            selfNode = passedSelfNode;
        }

        public void setHighLevelFactory(HighLevelFactory passedHighFactory)
        {
            highFactory = passedHighFactory;
        }

        public string[] getOptionsList()
        {
            return gamesList;
        }

        //Functions that have to do with creation of game objects

        public IGameInterface SelectGame(string input)
        {
            return SelectGame(Convert.ToInt32(input));
        }

        public IGameInterface SelectGame(int input)
        {

            IGameInterface game;

            if (input == 1)
            {
                game = SubMenu(highFactory.getRPSFactoryInstance());
            }
            else if(input == 2)
            {
                game = SubMenu(highFactory.getBlackJackFactoryInstance());
            }
            else
            {
                game = null;
            }

            return game;
        }

        private IGameInterface SubMenu(IGameFactory passedFactory)
        {
            CreateNode(passedFactory);
            IGameInterface subMenuGame = runChildNode();
            return subMenuGame;
        }

        private void CreateNode(IGameFactory passedFactory)
        {
            selfNode.createChildNode(passedFactory);
        }

        private IGameInterface runChildNode()
        {
            IGameInterface selectedGame = selfNode.runChildNode();
            return selectedGame;
        }
    }
}
