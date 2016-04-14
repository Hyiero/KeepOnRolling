using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using Managers;
using Signals;

namespace Services
{
    public class GameService : View, IGameService
    {
        [Inject]
        public IGameManager gameManager { get; set; }

        private GameObject gameManagerGO { get; set; }

        private Transform startingPointTransform { get; set; }

        public void Init()
        {
            gameManagerGO = GameObject.FindGameObjectWithTag("GameManager");
            //TODO: This is so we don't have to go through start menu, comment out if want to test with start menu screen.
            LoadNewGameObjects();
        }

        public void LoadNewGameObjects()
        {
            GameObject trackGO = Instantiate(Resources.Load("Prefabs/Track", typeof(GameObject))) as GameObject;
            trackGO.transform.SetParent(gameManagerGO.gameObject.transform);
            startingPointTransform = GameObject.FindGameObjectWithTag("StartPosition").transform;
            GameObject playerGO = Instantiate(Resources.Load("Prefabs/Player", typeof(GameObject)),startingPointTransform.position,startingPointTransform.rotation) as GameObject;
            playerGO.transform.SetParent(gameManagerGO.gameObject.transform);
            //TODO: Set the Camera where it should be set
            gameManager.SetNewGameElements(playerGO,trackGO);
        }
    }
}