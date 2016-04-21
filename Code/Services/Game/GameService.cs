using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using Managers;
using Signals;
using Views;
using Contexts;
using strange.extensions.injector.api;

namespace Services
{
    public class GameService : View, IGameService
    {
        [Inject]
        public IGameManager gameManager { get; set; }

        [Inject]
        public IInjectionBinder injectionBinder { get; set; }

        #region Private Variables
        private GameObject gameManagerGO { get; set; }
        private GameObject playerGO { get; set; }
        private GameObject trackGO { get; set; }

        private Transform startingPointTransform { get; set; }

        private CameraChaseComponentView cameraChaseView { get; set; }
        private PlayerView playerView { get; set; }
        #endregion

        public void Init()
        {
            gameManagerGO = GameObject.FindGameObjectWithTag("GameManager");
            //TODO: This is so we don't have to go through start menu, comment out if want to test with start menu screen.
            LoadNewGameObjectsAndSetParent();
            GetViewReferencesForAnyLoadedGameObjects();
            HookUpInjectionsForViews();
            gameManager.SetNewGameElements(playerGO, trackGO);
        }

        public void LoadNewGameObjectsAndSetParent()
        {
            trackGO = Instantiate(Resources.Load("Prefabs/Track", typeof(GameObject))) as GameObject;
            trackGO.transform.SetParent(gameManagerGO.gameObject.transform);
            startingPointTransform = GameObject.FindGameObjectWithTag("StartPosition").transform;

            playerGO = Instantiate(Resources.Load("Prefabs/Player", typeof(GameObject)),startingPointTransform.position,startingPointTransform.rotation) as GameObject;
            playerGO.transform.SetParent(gameManagerGO.gameObject.transform);
            //TODO: Set the Camera where it should be set
        }

        private void GetViewReferencesForAnyLoadedGameObjects()
        {
            cameraChaseView = trackGO.GetComponentInChildren<CameraChaseComponentView>();
            playerView = playerGO.GetComponent<PlayerView>();
        }

        private void HookUpInjectionsForViews()
        {
            injectionBinder.Bind<IPlayerView>().ToValue(playerView);
            injectionBinder.Bind<ICameraChaseComponentView>().ToValue(cameraChaseView);
        }
    }
}