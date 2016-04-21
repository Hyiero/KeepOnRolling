using UnityEngine;
using System.Collections;
using strange.extensions.command.impl;
using Managers;
using UnityEngine.SceneManagement;
using Services;
using Signals;

namespace Commands
{
    public class LaunchNewGameCommand : Command
    {
        [Inject]
        public IGuiService guiService { get; set; }

        [Inject]
        public IGameService gameService { get; set; }

        public override void Execute()
        {
            SceneManager.LoadScene((int)Constants.Scenes.Game);
            guiService.StartNewGame();
            //TODO: Need to make a gameService which will load prefabbed objects into the scene, and then need to research how to bind objects when they are added into the scene
            //TODO: This is the code to load the ball and put it under the GameManager,which will live under the context
            gameService.LoadNewGameObjectsAndSetParent();
        }
    }
}