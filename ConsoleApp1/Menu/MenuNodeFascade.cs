using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollection.Administration;
using GameCollection.Games;

namespace GameCollection.Menu
{
    public class MenuNodeFascade
    {
        IMenu menu;

        IOptions options;

        IGameFactory factory;

        MenuNodeFascade previousNode;

        MenuNodeFascade childNode;

        HighLevelFactory highFactory;

        public MenuNodeFascade(IMenu passedMenu, IOptions passedOptions, IGameFactory passedFactory, MenuNodeFascade passedPreviousNode = null, HighLevelFactory passedHighFactory = null)
        {
            menu = passedMenu;
            options = passedOptions;
            factory = passedFactory;
            previousNode = passedPreviousNode;

            if(passedHighFactory == null)
            {
                highFactory = new HighLevelFactory();
            }
            else
            {
                highFactory = passedHighFactory;
            }
            
            Setup();
        }

        private void Setup()
        {
            if(factory is IGameNodeFactory)
            {
                IGameNodeFactory nodeFactory = factory as IGameNodeFactory;
                nodeFactory.setSelfNode(this);
                nodeFactory.setHighLevelFactory(highFactory);
            }

            options.setFactory(factory);
            menu.setOptions(options);
        }

        public IGameInterface Run()
        {
            IGameInterface selectedGame = menu.Run();

            if(selectedGame == null)
            {
                if (hasParent())
                {
                    selectedGame = runParentNode();
                }
            }

            return selectedGame;
        }

        public IGameInterface runParentNode()
        {
            return previousNode.Run();
        }

        public bool hasParent()
        {
            if(previousNode != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void createChildNode(IGameFactory passedFactory, IMenu passedMenu = null, IOptions passedOptions = null)
        {
            if(passedMenu == null)
            {
                passedMenu = highFactory.getGameMenuInstance();
            }

            if(passedOptions == null)
            {
                passedOptions = highFactory.getGameOptionsInstance();
            }

            childNode = highFactory.getMenuNodeInstance(passedFactory, passedMenu, passedOptions, this, highFactory);
        }

        public IGameInterface runChildNode()
        {
            return childNode.Run();
        }
    }
}
