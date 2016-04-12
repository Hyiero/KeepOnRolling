using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using Views;
using Signals;

namespace Mediators
{
    public class MainMenuMediator : EventMediator
    {
        #region Injectors
        [Inject]
        public IMainMenuView view { get; set; }

        [Inject]
        public LaunchNewGameSignal launchNewGameSignal { get; set; }

        [Inject]
        public QuitGameSignal quitGameSignal { get; set; }
        #endregion

        public override void OnRegister()
        {
            view.Init();
            view.startGame.AddListener(StartGame);
            view.quitGame.AddListener(QuitGame);
        }

        private void StartGame()
        {
            launchNewGameSignal.Dispatch();
        }

        private void QuitGame()
        {
            quitGameSignal.Dispatch();
        }
    }
}