using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using Services;
using Views;

namespace Managers
{
    public class GameManager : View,IGameManager
    {
        //[Inject]
        //public IGameService gameService { get; set; }

        [SerializeField]
        private GameObject playerGO;
        [SerializeField]
        private GameObject trackGO;

        public void SetNewGameElements(GameObject player,GameObject track)
        {
            playerGO = player;
            trackGO = track;
        }
    }
}