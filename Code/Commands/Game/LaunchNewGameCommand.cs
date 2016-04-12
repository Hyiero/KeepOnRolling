using UnityEngine;
using System.Collections;
using strange.extensions.command.impl;
using Managers;
using UnityEngine.SceneManagement;
using Services;

namespace Commands
{
    public class LaunchNewGameCommand : Command
    {
        [Inject]
        public IGuiService guiService { get; set; }

        public override void Execute()
        {
            guiService.StartNewGame();
            SceneManager.LoadScene((int)Constants.Scenes.Game);
        }
    }
}