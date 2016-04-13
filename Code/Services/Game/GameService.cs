using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using Managers;

namespace Services
{
    public class GameService : View, IGameService
    {
        [Inject]
        public IGameManager gameManager { get; set; }

        private GameObject gameManagerGO { get; set; }

        public void Init()
        {
            gameManagerGO = GameObject.FindGameObjectWithTag("GameManager");
        }

        public void LoadNewGameObjects()
        {
            GameObject playerGO = Instantiate(Resources.Load("Prefabs/Player", typeof(GameObject))) as GameObject;
            playerGO.transform.SetParent(gameManagerGO.gameObject.transform);
            GameObject trackGO = Instantiate(Resources.Load("Prefabs/Track", typeof(GameObject))) as GameObject;
            trackGO.transform.SetParent(gameManagerGO.gameObject.transform);
            gameManager.SetGameObjectReference(playerGO,trackGO);
        }
    }
}