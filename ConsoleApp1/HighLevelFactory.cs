using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Menu;
using GameCollection.Administration;
using GameCollection.Games.RockPaperScissors;
using GameCollection.Games.BlackJack;

namespace GameCollection
{
    class HighLevelFactory
    {
        public MenuNodeFascade getMainMenu()
        {
            return new MenuNodeFascade(getGameMenuInstance(), getGameOptionsInstance(), getGameFactoryInstance());
        }

        public MenuNodeFascade getMenuNodeInstance(IGameFactory passedFactory, IMenu passedMenu, IOptions passedOptions, MenuNodeFascade parentNode = null, HighLevelFactory passedHighFactory = null)
        {
            if(passedHighFactory == null)
            {
                passedHighFactory = this;
            }

            return new MenuNodeFascade(passedMenu, passedOptions, passedFactory, parentNode, passedHighFactory);
        }

        public GameMenu getGameMenuInstance()
        {
            return new GameMenu();
        }

        public GameOptions getGameOptionsInstance()
        {
            return new GameOptions();
        }

        public GameFactory getGameFactoryInstance()
        {
            return new GameFactory();
        }

        public RPSFactory getRPSFactoryInstance()
        {
            return new RPSFactory();
        }

        public BlackJackFactory getBlackJackFactoryInstance()
        {
            return new BlackJackFactory();
        }
    }
}
