using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using UnityEngine.UI;
using strange.extensions.signal.impl;

namespace Views
{
    public class MainMenuView : View,IMainMenuView
    {
        [SerializeField]
        private Button startButton;
        [SerializeField]
        private Button quitButton;

        public Signal startGame { get; set; }
        public Signal quitGame { get; set; }

        public void Init()
        {
            InitalizeSignals();
            HookUpListeners();
        }

        #region Private Methods
        private void StartGame()
        {
            startGame.Dispatch();
        }

        private void QuitGame()
        {
            quitGame.Dispatch();
        }

        private void InitalizeSignals()
        {
            startGame = new Signal();
            quitGame = new Signal();
        }

        private void HookUpListeners()
        {
            startButton.onClick.AddListener(StartGame);
            quitButton.onClick.AddListener(QuitGame);
        }
        #endregion
    }
}