using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;

namespace Managers
{
    public class GameManager : View,IGameManager
    {
        [SerializeField]
        private GameObject playerGO;
        [SerializeField]
        private GameObject trackGO;

        public void SetGameObjectReference(GameObject player,GameObject track)
        {
            playerGO = player;
            trackGO = track;
        }
    }
}